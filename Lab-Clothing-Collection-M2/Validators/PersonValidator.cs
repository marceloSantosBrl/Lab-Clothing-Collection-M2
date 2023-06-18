using FluentValidation;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Validators;

public class PersonValidator: AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Gender).NotEmpty();
        RuleFor(p => p.DocumentId).NotEmpty();
        RuleFor(p => p.PhoneNumber).NotEmpty();
        RuleFor(p => p.BirthDate).NotNull();
    }
}