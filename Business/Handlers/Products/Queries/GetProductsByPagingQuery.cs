using Core.Utilities.Results;
using MediatR;

namespace Business.Handlers.Products.Queries;

public record GetProductsByPagingQuery:IRequest<IDataResult<object>>
{
    
}