using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;

namespace Business.Handlers.Addresses.Commands;

public record DeleteAddressCommand(int Id) : IRequest<IResult>
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, IResult>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        [SecuredOperation]
        [TransactionScopeAspectAsync]
        [LogAspect(typeof(PostgreSqlLogger))]
        public async Task<IResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var record = await _addressRepository.GetAsync(x => x.Id == request.Id);

            if (record is null)
                return new ErrorResult(Messages.RecordNotFound);
            
            _addressRepository.Delete(record);

            await _addressRepository.SaveChangesAsync();


            return new SuccessResult();
        }
    }
};