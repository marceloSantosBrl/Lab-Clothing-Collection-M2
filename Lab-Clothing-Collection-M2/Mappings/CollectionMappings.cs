using Lab_Clothing_Collection_M2.DTO.ClothingCollection;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Mappings;

public static class CollectionMappings
{
    public static ClothingCollection CollectionRequestToEntity(CollectionRequest request)
    {
        return new ClothingCollection
        {
            Name = request.Name,
            Brand = request.Brand,
            Budget = request.Budget,
            LaunchYear = request.LaunchYear ?? 
                         throw new ArgumentException("LaunchYear Field can't be null", nameof(request)),
            Season = request.Season,
            SystemActivity = request.SystemActivity
        };
    }

    public static CollectionResponse CollectionEntityToResponse(ClothingCollection entity)
    {
        return new CollectionResponse
        {
            Brand = entity.Brand,
            Budget = entity.Budget,
            Id = entity.Id,
            LaunchYear = entity.LaunchYear,
            Name = entity.Name,
            Season = entity.Season,
            SystemActivity = entity.SystemActivity
        };
    }
}