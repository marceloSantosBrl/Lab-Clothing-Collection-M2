using System.ComponentModel.DataAnnotations;

namespace Lab_Clothing_Collection_M2.Entities;

public enum UserType
{
    Administrator,
    Manager,
    Creator,
    Other
}

public enum UserStatus
{
    Active,
    Inactive
}

public class User : Person
{
    [Required(ErrorMessage = "The Email field is required.")]
    [MaxLength(100, ErrorMessage = "The Email field must contain at most 100 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The UserType field is required.")]
    public UserType UserType { get; set; }

    [Required(ErrorMessage = "The UserStatus field is required.")]
    public UserStatus UserStatus { get; set; }

    public User(string name, string gender, DateOnly birthday,
        string phoneNumber, UserType userType, UserStatus userStatus, string email) :
        base(name, gender, birthday, phoneNumber)
    {
        UserType = userType;
        UserStatus = userStatus;
        this.Email = email;
    }
}