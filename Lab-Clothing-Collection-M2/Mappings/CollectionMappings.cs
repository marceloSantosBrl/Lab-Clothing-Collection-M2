using Lab_Clothing_Collection_M2.DTO.ClothingCollection;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Mappings;

public static class CollectionMappings
{
    public static ClothingCollection CollectionRequestToEntity(CollectionRequest request)
    {
        return new ClothingCollection
        {
            Name = request.Name ??
            throw new ArgumentException("LaunchYear field can't be null", nameof(request)),
            Brand = request.Brand ??
                    throw new ArgumentException("Brand field can't be null", nameof(request)),
            Budget = request.Budget ??
                     throw new ArgumentException("Budget field can't be null", nameof(request)),
            UserId = request.UserId ??
                     throw new ArgumentException("UserId field can't be null", nameof(request)),
            LaunchYear = request.LaunchYear ??
                         throw new ArgumentException("LaunchYear field can't be null", nameof(request)),
            Season = request.Season ??
                     throw new ArgumentException("Season field can't be null", nameof(request)),
            SystemActivity = request.SystemActivity ??
                             throw new ArgumentException("SystemActivity field can't be null", nameof(request))
        };
    }

    public static CollectionResponse CollectionEntityToResponse(ClothingCollection entity)
    {
        return new CollectionResponse
        {
            UserId = entity.UserId,
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