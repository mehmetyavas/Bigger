using Business.Handlers.Products.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Handlers.Products.ValidationRules;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.Image).NotEmpty().NotNull();
        RuleFor(x => x.Price).GreaterThan(0).NotEmpty().NotNull();
        RuleFor(x => x.StockCode).NotEmpty().NotNull();
        RuleFor(x => x.Slug).NotNull().NotEmpty();
    }
}