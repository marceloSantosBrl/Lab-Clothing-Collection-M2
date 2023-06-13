using System.ComponentModel.DataAnnotations;

namespace Lab_Clothing_Collection_M2.Entities;

public class Person
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }
    [Required] [MaxLength(40)] public string Gender { get; set; }
    [Required] public DateOnly Birthday { get; set; }
    [MaxLength(20)] public string? Cpf { get; set; }
    [MaxLength(30)] public string? Cnpj { get; set; }
    [Required] [MaxLength(30)] public string PhoneNumber { get; set; }

    public Person()
    {
        
    }
    
    public Person(string name, string gender, DateOnly birthday, string phoneNumber)
    {
        Name = name;
        Gender = gender;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
    }
}
    