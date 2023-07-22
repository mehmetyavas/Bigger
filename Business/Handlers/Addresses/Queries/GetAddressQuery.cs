using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Addresses.Queries;

public record GetAddressQuery(int Id) : IRequest<IDataResult<Address>>
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, IDataResult<Address>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [SecuredOperation]
        public async Task<IDataResult<Address>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository
                .GetAsync(x => x.Id == request.Id, cancellationToken);

            return new SuccessDataResult<Address>(address);
        }
    }
};