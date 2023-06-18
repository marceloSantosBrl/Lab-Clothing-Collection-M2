using FluentValidation;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Validators;

public class CollectionValidator: AbstractValidator<ClothingCollection>
{
    public CollectionValidator()
    {
        RuleFor(c => c.Brand).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Season).IsInEnum();
        RuleFor(c => c.SystemActivity).IsInEnum();
        RuleFor(c => c.LaunchYear).NotNull();
    }
}