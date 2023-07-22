using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Handlers.Addresses.Queries;

public record GetAddressQuery(int Id) : IRequest<IDataResult<Address>>
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, IDataResult<Address>>
    {
        private readonly IAddressRepository _addressRepository;
        private ClaimsPrincipal User { get; }

        public GetAddressQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            var httpContext = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext;
            if (httpContext != null)
            {
                User = httpContext.User;
            }
        }

        [SecuredOperation]
        public async Task<IDataResult<Address>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            if (User is null)
                return new ErrorDataResult<Address>(Messages.UserNotFound);

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.EndsWith(TokenConsts.UserId))?.Value);

            var address = await _addressRepository
                .GetAsync(x => x.Id == request.Id
                               && x.UserId == userId, cancellationToken);

            if (address is null)
                return new ErrorDataResult<Address>(Messages.RecordNotFound);

            return new SuccessDataResult<Address>(address);
        }
    }
};