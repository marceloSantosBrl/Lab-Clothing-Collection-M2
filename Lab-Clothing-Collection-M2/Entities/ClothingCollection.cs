using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Entities;

public enum Season
{
    Fall,
    Winter,
    Spring,
    Summer
}

public enum SystemActivity
{
    Active,
    Inactive
}

[Index(nameof(Name),IsUnique = true)]
public class ClothingCollection
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required.")]
    [MaxLength(150, ErrorMessage = "The Name field must contain at most 150 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The User field is required.")]
    public User User { get; set; }
    
    [Required(ErrorMessage = "The UserId field is required.")]
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [Required(ErrorMessage = "The Brand field is required.")]
    [MaxLength(100, ErrorMessage = "The Brand field must contain at most 100 characters.")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "The Budget field is required.")]
    public decimal Budget { get; set; }

    [Required(ErrorMessage = "The LaunchYear field is required.")]
    public DateTime LaunchYear { get; set; }

    [Required(ErrorMessage = "The Season field is required.")]
    public Season Season { get; set; }

    [Required(ErrorMessage = "The SystemActivity field is required.")]
    public SystemActivity SystemActivity { get; set; }
}