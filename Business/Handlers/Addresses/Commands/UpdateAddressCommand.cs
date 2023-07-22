using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Addresses.Commands;

public record UpdateAddressCommand(Address Address) : IRequest<IResult>
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, IResult>
    {
        private IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        [LogAspect(typeof(PostgreSqlLogger))]
        [TransactionScopeAspectAsync]
        [SecuredOperation]
        public async Task<IResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var record = await _addressRepository.GetAsync(x => x.Id == request.Address.Id);

            record.City = request.Address.City ?? record.City;
            record.Country = request.Address.Country ?? record.Country;
            record.Street = request.Address.Street ?? record.Street;
            record.FullAddress = request.Address.FullAddress ?? record.FullAddress;
            record.PostalCode = request.Address.PostalCode ?? record.PostalCode;
            record.Title = request.Address.Title ?? record.Title;

            _addressRepository.Update(record);

            await _addressRepository.SaveChangesAsync();

            return new SuccessResult();
        }
    }
};