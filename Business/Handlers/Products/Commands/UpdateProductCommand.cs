using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Image;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Handlers.Products.Commands;

public record UpdateProductCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public IFormFile Image { get; set; }
    public decimal Price { get; set; }
    public string StockCode { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;

        public UpdateProductCommandHandler(IProductRepository productRepository, IImageService imageService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
            _imageService.PathDir = "product";
        }

        public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var record = await _productRepository.GetAsync(x => x.Id == request.Id);
            var recordImageUrl = record.BaseImageUrl;

            record.Title = request.Title ?? record.Title;
            record.StockCode = request.StockCode;
            record.Description = request.Description ?? record.Description;
            record.Price = request.Price;
            record.Slug = request.Slug ?? record.Slug;
            record.BaseImageUrl = await _imageService
                .UpdateImageAsync(request.Image, recordImageUrl);

            _productRepository.Update(record);
            await _productRepository.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}