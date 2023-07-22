using System;
using System.Collections.Generic;
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

public record GetAddressesQuery() : IRequest<IDataResult<List<Address>>>
{
    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, IDataResult<List<Address>>>
    {
        private ClaimsPrincipal User { get; set; }
        private readonly IAddressRepository _addressRepository;

        public GetAddressesQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;

            var httpContext = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext;
            if (httpContext != null)
            {
                User = httpContext.User;
            }
        }

        [SecuredOperation]
        public async Task<IDataResult<List<Address>>> Handle(GetAddressesQuery request,
            CancellationToken cancellationToken)
        {
            if (User is null)
                return new ErrorDataResult<List<Address>>(Messages.UserNotFound);

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type.EndsWith(TokenConsts.UserId))?.Value);

            var addresses = await _addressRepository
                .GetListAsync(expression: x => x.UserId == userId,
                    cancellationToken: cancellationToken);

            if (!addresses.Any())
                return new ErrorDataResult<List<Address>>(Messages.RecordNotFound);

            return new SuccessDataResult<List<Address>>(addresses.ToList());
        }
    }
};