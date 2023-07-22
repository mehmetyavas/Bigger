using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using MediatR;

namespace Business.Handlers.Addresses.Commands;

public record DeleteAddressCommand(int Id) : IRequest<IResult>
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, IResult>
    {
        [SecuredOperation]
        [TransactionScopeAspectAsync]
        [LogAspect(typeof(PostgreSqlLogger))]
        public Task<IResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
};