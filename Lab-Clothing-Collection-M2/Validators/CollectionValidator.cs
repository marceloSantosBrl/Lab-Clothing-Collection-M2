using FluentValidation;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Validators;

public class CollectionValidator: AbstractValidator<ClothingCollection>
{
    public CollectionValidator()
    {
        RuleFor(c => c.Brand).NotEmpty();
        RuleFor(c => c.Budget).NotNull();
        RuleFor(c => c.UserId).NotNull();
        RuleFor(c => c.LaunchYear).NotNull();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Season).IsInEnum();
        RuleFor(c => c.SystemActivity).IsInEnum();
    }
}