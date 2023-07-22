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

public record CreateAddressCommand(Address Address) : IRequest<IResult>
{
    public sealed class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, IResult>
    {
        private readonly IAddressRepository _addressRepository;
        private ClaimsPrincipal User { get; set; }

        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            var httpContext = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext;

            if (httpContext != null)
                User = httpContext.User;
        }

        [TransactionScopeAspectAsync]
        [LogAspect(typeof(PostgreSqlLogger))]
        [SecuredOperation]
        public async Task<IResult> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            if (User is null)
                return new ErrorResult(Messages.UserNotFound);

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.EndsWith(TokenConsts.UserId))?.Value);

            var addressCount = await _addressRepository
                .GetCountAsync(expression: x => x.UserId == userId,
                    cancellationToken: cancellationToken);

            if (addressCount > 3)
                return new ErrorResult(Messages.MaxAddressCountError);


            var address = request.Address;
            address.UserId = userId;


            _addressRepository.Add(address);
            await _addressRepository.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}