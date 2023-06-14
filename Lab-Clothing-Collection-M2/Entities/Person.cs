using System.ComponentModel.DataAnnotations;

namespace Lab_Clothing_Collection_M2.Entities;

public class Person
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required.")]
    [MaxLength(100, ErrorMessage = "The Name field must contain at most 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Gender field is required.")]
    [MaxLength(40, ErrorMessage = "The Gender field must contain at most 40 characters.")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "The Birthday field is required.")]
    public DateOnly BirthDate { get; set; }

    [MaxLength(20, ErrorMessage = "The Cpf field must contain at most 20 characters.")]
    public string? Cpf { get; set; }

    [MaxLength(30, ErrorMessage = "The Cnpj field must contain at most 30 characters.")]
    public string? Cnpj { get; set; }

    [Required(ErrorMessage = "The PhoneNumber field is required.")]
    [MaxLength(30, ErrorMessage = "The PhoneNumber field must contain at most 30 characters.")]
    public string PhoneNumber { get; set; }

    public Person()
    {
    }

    public Person(string name, string gender, DateOnly birthDate, string phoneNumber)
    {
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }
}