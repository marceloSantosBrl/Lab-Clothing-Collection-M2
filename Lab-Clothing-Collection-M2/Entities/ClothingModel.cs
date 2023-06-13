using System.ComponentModel.DataAnnotations;

namespace Lab_Clothing_Collection_M2.Entities;

public enum ClothingType
{
    Bermuda,
    Biquine,
    Bolsa,
    Bone,
    Calca,
    Calcado,
    Camisa,
    Chapeu,
    Saia
}

public enum ClothingLayout
{
    Bordado,
    Estampado,
    Liso
}

public class ClothingModel
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(150)] public string Name { get; set; }
    [Required] public ClothingCollection ClothingCollection { get; set; }
    [Required] public ClothingType ClothingType { get; set; }
    [Required] public ClothingLayout ClothingLayout { get; set; }

    public ClothingModel(string name, ClothingCollection clothingCollection, ClothingType clothingType,
        ClothingLayout clothingLayout)
    {
        Name = name;
        ClothingCollection = clothingCollection;
        ClothingType = clothingType;
        ClothingLayout = clothingLayout;
    }
}