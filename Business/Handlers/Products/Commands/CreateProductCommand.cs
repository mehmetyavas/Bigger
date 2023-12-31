using System;
using System.Threading;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Handlers.Products.ValidationRules;
using Business.Services.Image;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Products.Commands;

public record CreateProductCommand : IRequest<IDataResult<object>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public IFormFile Image { get; set; }
    public decimal Price { get; set; }
    public string StockCode { get; set; }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;

        public CreateProductCommandHandler(IProductRepository productRepository, IImageService imageService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
            _imageService.PathDir = "product";
        }

        //[SecuredOperation]
        [ValidationAspect(typeof(CreateProductValidator))]
        [TransactionScopeAspectAsync]
        [LogAspect(typeof(PostgreSqlLogger))]
        public async Task<IResult> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var record = await Record(request);
            _productRepository.Add(record);

            await _productRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        private async Task<Product> Record(CreateProductCommand request)
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