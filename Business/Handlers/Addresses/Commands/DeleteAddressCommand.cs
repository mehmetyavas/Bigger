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
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Addresses.Commands;

public record DeleteAddressCommand(int Id) : IRequest<IResult>
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, IResult>
    {
        private readonly IAddressRepository _addressRepository;

        private ClaimsPrincipal User { get; }

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            var httpContext = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext;
            if (httpContext != null)
            {
                User = httpContext.User;
            }
        }


        [SecuredOperation]
        [TransactionScopeAspectAsync]
        [LogAspect(typeof(PostgreSqlLogger))]
        public async Task<IResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            if (User is null)
                return new ErrorDataResult<Address>(Messages.UserNotFound);

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.EndsWith(TokenConsts.UserId))?.Value);
            
            var record = await _addressRepository
                .GetAsync(x =>
                    x.Id == request.Id &&
                    x.UserId == userId);

            if (record is null)
                return new ErrorDataResult<Address>(Messages.RecordNotFound);

            _addressRepository.Delete(record);

            await _addressRepository.SaveChangesAsync();


            return new SuccessResult();
        }
    }
};