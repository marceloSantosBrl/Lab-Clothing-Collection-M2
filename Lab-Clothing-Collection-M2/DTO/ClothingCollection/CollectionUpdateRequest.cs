using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.DTO.ClothingCollection;

public class CollectionUpdateRequest
{
    public string? Name { get; set; }
    public int? UserId { get; set; }
    public string? Brand { get; set; }
    public decimal? Budget { get; set; }
    public DateTime? LaunchYear { get; set; }
    public Season? Season { get; set; }
    public SystemActivity? SystemActivity { get; set; }
}