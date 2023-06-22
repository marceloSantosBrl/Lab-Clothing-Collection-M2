using Lab_Clothing_Collection_M2.DTO.ClothingModel;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Mappings;

public static class ModelsMapping
{
    public static ClothingModel ModelRequestToEntity(ModelRequest request)
    {
        return new ClothingModel
        {
            ClothingCollectionId = request.CollectionId ??
                                   throw new ArgumentException("CollectionId field can't be null", nameof(request)),
            Name = request.Name ??
                   throw new ArgumentException("Name field can't be null", nameof(request)),
            ClothingLayout = request.ClothingLayout ??
                             throw new ArgumentException("ClothingLayout Field can't be null", nameof(request)),
            ClothingType = request.ClothingType ??
                           throw new ArgumentException("ClothingType Field can't be null", nameof(request))
        };
    }

    public static ModelResponse ModelEntityToResponse(ClothingModel entity)
    {
        return new ModelResponse
        {
            CollectionId = entity.ClothingCollectionId,
            Id = entity.Id,
            Name = entity.Name,
            ClothingType = entity.ClothingType,
            ClothingLayout = entity.ClothingLayout
        };
    }
}