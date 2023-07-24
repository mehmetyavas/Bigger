using Business.Handlers.Addresses.Commands;
using Entities.Concrete;
using FluentValidation;

namespace Business.Handlers.Addresses.ValidationRules;

public class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressValidator()
    {
        RuleFor(x => x.Address.UserId).NotEmpty().NotNull();
        RuleFor(x => x.Address.Street).NotEmpty().NotNull();
        RuleFor(x => x.Address.Title).NotEmpty().NotNull();
        RuleFor(x => x.Address.City).NotEmpty().NotNull();
        RuleFor(x => x.Address.FullAddress).NotEmpty().NotNull();
        RuleFor(x => x.Address.Country).NotEmpty().NotNull();
        RuleFor(x => x.Address.PostalCode).NotEmpty().NotNull();
    }
}