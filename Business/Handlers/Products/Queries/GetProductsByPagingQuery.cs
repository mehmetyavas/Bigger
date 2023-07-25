using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;

namespace Business.Handlers.Products.Queries;

public record GetProductsByPagingQuery : IRequest<IDataResult<object>>
{
    public string Search { get; set; }
    public int Page { get; set; }
    public int Limit { get; set; }

    public class GetProductsByPagingQueryHandler : IRequestHandler<GetProductsByPagingQuery, IDataResult<object>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByPagingQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IDataResult<object>> Handle(GetProductsByPagingQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}