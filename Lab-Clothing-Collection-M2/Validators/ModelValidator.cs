using FluentValidation;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Validators;

public class ModelValidator: AbstractValidator<ClothingModel>
{
    public ModelValidator()
    {
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.ClothingType).IsInEnum();
        RuleFor(m => m.ClothingLayout).IsInEnum();
    }
}