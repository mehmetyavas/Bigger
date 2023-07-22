using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Handlers.Addresses.Commands;

public record UpdateAddressCommand(Address Address) : IRequest<IDataResult<Address>>
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, IDataResult<Address>>
    {
        private readonly IAddressRepository _addressRepository;

        private ClaimsPrincipal User { get; }

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            var httpContext = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext;
            if (httpContext != null)
            {
                User = httpContext.User;
            }
        }


        [LogAspect(typeof(PostgreSqlLogger))]
        [TransactionScopeAspectAsync]
        [SecuredOperation]
        public async Task<IDataResult<Address>> Handle(UpdateAddressCommand request,
            CancellationToken cancellationToken)
        {
            if (User is null)
                return new ErrorDataResult<Address>(Messages.UserNotFound);

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.EndsWith(TokenConsts.UserId))?.Value);
            var record = await _addressRepository
                .GetAsync(x =>
                    x.Id == request.Address.Id &&
                    x.UserId == userId);

            if (record is null)
                return new ErrorDataResult<Address>(Messages.RecordNotFound);

            record.City = request.Address.City ?? record.City;
            record.Country = request.Address.Country ?? record.Country;
            record.Street = request.Address.Street ?? record.Street;
            record.FullAddress = request.Address.FullAddress ?? record.FullAddress;
            record.PostalCode = request.Address.PostalCode ?? record.PostalCode;
            record.Title = request.Address.Title ?? record.Title;

            _addressRepository.Update(record);

            await _addressRepository.SaveChangesAsync();

            return new SuccessDataResult<Address>(record);
        }
    }
};