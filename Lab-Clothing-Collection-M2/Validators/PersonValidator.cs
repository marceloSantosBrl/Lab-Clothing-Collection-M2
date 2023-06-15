using FluentValidation;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Validators;

public class PersonValidator: AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.Name).NotEmpty();
        RuleFor(person => person.Gender).NotEmpty();
        RuleFor(person => person.DocumentId).NotEmpty();
        RuleFor(person => person.PhoneNumber).NotEmpty();
    }
}