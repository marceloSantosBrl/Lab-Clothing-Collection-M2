using System.ComponentModel.DataAnnotations;

namespace Lab_Clothing_Collection_M2.Entities;

public enum UserType
{
    Administrador,
    Gerente,
    Criador,
    Outro
}

public enum UserStatus
{
    Ativo,
    Inativo
}

public class User : Person
{
    [Required] [MaxLength(100)] public string Email { get; set; }
    [Required] public UserType UserType { get; set; }
    [Required] public UserStatus UserStatus { get; set; }

    public User(string name, string gender, DateOnly birthday,
        string phoneNumber, UserType userType, UserStatus userStatus, string email) :
        base(name, gender, birthday, phoneNumber)
    {
        UserType = userType;
        UserStatus = userStatus;
        this.Email = email;
    }
}