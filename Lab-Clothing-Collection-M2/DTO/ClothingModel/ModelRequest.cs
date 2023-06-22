using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.DTO.ClothingModel;

public class ModelRequest
{
    public string? Name { get; set; }
    public int? CollectionId { get; set; }
    public ClothingType? ClothingType { get; set; }
    public ClothingLayout? ClothingLayout { get; set; }
}