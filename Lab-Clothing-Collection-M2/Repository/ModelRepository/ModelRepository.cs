using FluentValidation;
using Lab_Clothing_Collection_M2.Context;
using Lab_Clothing_Collection_M2.DTO.ClothingModel;
using Lab_Clothing_Collection_M2.Entities;
using Lab_Clothing_Collection_M2.Mappings;
using Lab_Clothing_Collection_M2.Validators;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Repository.ModelRepository;

public class ModelRepository : IModelRepository
{
    private readonly ClothingContext _context;
    private readonly ModelValidator _validator;

    public ModelRepository(ClothingContext context, ModelValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<ModelResponse> AddModel(ModelRequest request)
    {
        var modelEntity = ModelsMapping.ModelRequestToEntity(request);
        await _validator.ValidateAndThrowAsync(modelEntity);
        _context.ClothingModels.Add(modelEntity);
        await _context.SaveChangesAsync();
        return ModelsMapping.ModelEntityToResponse(modelEntity);
    }

    public async Task<ModelResponse> UpdateModel(int id, ModelRequest request)
    {
        var modelEntity = await _context.ClothingModels
            .Include(m => m.ClothingCollection)
            .FirstAsync(m => m.Id == id);
        modelEntity.Name = request.Name ?? modelEntity.Name;
        modelEntity.ClothingLayout = request.ClothingLayout ?? modelEntity.ClothingLayout;
        modelEntity.ClothingType = request.ClothingType ?? modelEntity.ClothingType;
        modelEntity.ClothingCollectionId = request.CollectionId ?? modelEntity.ClothingCollectionId;
        await _validator.ValidateAndThrowAsync(modelEntity);
        await _context.SaveChangesAsync();
        return ModelsMapping.ModelEntityToResponse(modelEntity);
    }

    public async Task<IEnumerable<ModelResponse>> GetAllModels(string? layout)
    {
        return layout switch
        {
            null => await _context
                .ClothingModels
                .Select(m => ModelsMapping.ModelEntityToResponse(m))
                .ToListAsync(),
            "BORDAOD" => await _context.ClothingModels
                .Where(m => m.ClothingLayout == ClothingLayout.Needlework)
                .Select(m => ModelsMapping.ModelEntityToResponse(m))
                .ToListAsync(),
            "ESTAMPA" => await _context.ClothingModels
                .Where(m => m.ClothingLayout == ClothingLayout.DiePressed)
                .Select(m => ModelsMapping.ModelEntityToResponse(m))
                .ToListAsync(),
            "LISO" => await _context.ClothingModels
                .Where(m => m.ClothingLayout == ClothingLayout.DiePressed)
                .Select(m => ModelsMapping.ModelEntityToResponse(m))
                .ToListAsync(),
            _ => throw new ArgumentException($"Layout value: {layout} is invalid", nameof(layout))
        };
    }

    public async Task<ModelResponse> GetModel(int id)
    {
        return await _context
            .ClothingModels
            .Where(m => m.Id == id)
            .Select(m => ModelsMapping.ModelEntityToResponse(m))
            .FirstAsync();
    }

    public async Task DeleteModel(int id)
    {
        var recordsChanged = await _context
            .Database
            .ExecuteSqlAsync($@"DELETE FROM dbo.ClothingModels
                                WHERE Id = {id}");
        if (recordsChanged == 0)
        {
            throw new ArgumentException($"Id {id} not existent in the database", nameof(id));
        }
    }
}