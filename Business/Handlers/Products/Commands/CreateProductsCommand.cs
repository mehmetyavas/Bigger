using System;
using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Services.Image;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Business.Handlers.Products.Commands;

public record CreateProductsCommand : IRequest<IDataResult<object>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public IFormFile Image { get; set; }
    public decimal Price { get; set; }
    public Guid StockCode { get; set; }

    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, IDataResult<object>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;

        public CreateProductsCommandHandler(IProductRepository productRepository, IImageService imageService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
        }

        [SecuredOperation]
        [TransactionScopeAspectAsync]
        [LogAspect(typeof(PostgreSqlLogger))]
        // ValidationAspect
        public async Task<IDataResult<object>> Handle(CreateProductsCommand request,
            CancellationToken cancellationToken)
        {
            _imageService.PathDir = "image";


            var record = await Record(request);
            _productRepository.Add(record);

            await _productRepository.SaveChangesAsync();

            return new SuccessDataResult<object>();
        }

        private async Task<Product> Record(CreateProductsCommand request)
        {
            var redord = new Product
            {
                Title = request.Title,
                Description = request.Description,
                Slug = request.Slug,
                BaseImageUrl = await _imageService.SaveImageAsync(request.Image),
                Price = request.Price,
                StockCode = request.StockCode,
                CreatedAt = DateTime.Now
            };
            return redord;
        }
    }
};