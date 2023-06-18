using Lab_Clothing_Collection_M2.DTO.ClothingCollection;

namespace Lab_Clothing_Collection_M2.Repository.CollectionRepository;

public interface ICollectioRepository
{
    public Task<CollectionResponse> AddClothingCollection(CollectionRequest request);
    public Task<CollectionResponse> UpdateClothingCollection(int id, CollectionUpdateRequest request);
    public Task<CollectionResponse> UpdateClothingStatus(int id, CollectionStatusUpdateRequest request);
    public Task<IEnumerable<CollectionResponse>> GetAllCollection(string? status);
    public Task<CollectionResponse> GetClothingCollection(int id);
    public Task DeleteClothingCollection(int id);
}