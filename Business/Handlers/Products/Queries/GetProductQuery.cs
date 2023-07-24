using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;

namespace Business.Handlers.Products.Queries;

public record GetProductQuery(string Query) : IRequest<IDataResult<Product>>
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IDataResult<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IDataResult<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var query = int.TryParse(request.Query, out int id);

            var product = await _productRepository
                .GetAsync(x => query
                    ? x.Id == id
                    : x.Slug == request.Query, cancellationToken);


            return new SuccessDataResult<Product>(product);
        }
    }
}