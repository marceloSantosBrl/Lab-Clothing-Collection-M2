using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Entities;

[Index(nameof(DocumentId),IsUnique = true)]
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
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "The DocumentId field is required.")]
    [MaxLength(30, ErrorMessage = "The DocumentId field must contain at most 30 characters.")]
    public string DocumentId { get; set; }

    [Required(ErrorMessage = "The PhoneNumber field is required.")]
    [MaxLength(30, ErrorMessage = "The PhoneNumber field must contain at most 30 characters.")]
    public string PhoneNumber { get; set; }
}