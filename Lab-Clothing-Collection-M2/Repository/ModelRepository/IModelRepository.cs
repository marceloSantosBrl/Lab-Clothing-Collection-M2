using Lab_Clothing_Collection_M2.DTO.ClothingModel;

namespace Lab_Clothing_Collection_M2.Repository.ModelRepository;

public interface IModelRepository
{
    public Task<ModelResponse> AddModel(ModelRequest request);
    public Task<ModelResponse> UpdateModel(int id, ModelRequest request);
    public Task<IEnumerable<ModelResponse>> GetAllModels(string? layout);
    public Task<ModelResponse> GetModel(int id);
    public Task DeleteModel(int id);
}