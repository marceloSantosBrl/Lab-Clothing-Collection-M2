using FluentValidation;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Validators;

public class UserValidator: AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty();
        RuleFor(user => user.Gender).NotEmpty();
        RuleFor(user => user.DocumentId).NotEmpty();
        RuleFor(user => user.PhoneNumber).NotEmpty();
        RuleFor(user => user.UserStatus).IsInEnum();
        RuleFor(user => user.UserType).IsInEnum();
        RuleFor(user => user.Email).EmailAddress();
    }
}