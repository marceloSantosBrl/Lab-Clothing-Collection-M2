using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.DTO.ClothingModel;

public class ModelResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CollectionId { get; set; }
    public ClothingType ClothingType { get; set; }
    public ClothingLayout ClothingLayout { get; set; }
}