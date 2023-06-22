using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Entities;

public enum ClothingType
{
    Shorts,
    Bikini,
    Purse,
    Cap,
    Pants,
    Shoe,
    Shirt,
    Hat,
    Skirt
}

public enum ClothingLayout
{
    Needlework,
    DiePressed,
    Plain
}

[Index(nameof(Name), IsUnique = true)]
public class ClothingModel
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "The Name field is required.")]
    [MaxLength(150, ErrorMessage = "The Name field must contain at most 150 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The ClothingCollection field is required.")]
    public ClothingCollection ClothingCollection { get; set; }

    [Required(ErrorMessage = "The ClothingCollectionId field is required.")]
    [ForeignKey("ClothingCollection")]
    public int ClothingCollectionId { get; set; }
    
    [Required(ErrorMessage = "The ClothingType field is required.")]
    public ClothingType ClothingType { get; set; }

    [Required(ErrorMessage = "The ClothingLayout field is required.")]
    public ClothingLayout ClothingLayout { get; set; }
}