using FluentValidation;
using Lab_Clothing_Collection_M2.Context;
using Lab_Clothing_Collection_M2.DTO.ClothingCollection;
using Lab_Clothing_Collection_M2.Entities;
using Lab_Clothing_Collection_M2.Mappings;
using Lab_Clothing_Collection_M2.Validators;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Repository.CollectionRepository;

public class CollectionRepository : ICollectioRepository
{
    private readonly ClothingContext _context;
    private readonly CollectionValidator _validator;

    public CollectionRepository(ClothingContext context, CollectionValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<CollectionResponse> AddClothingCollection(CollectionRequest request)
    {
        var userEntity = await _context.Users.FirstAsync(u => u.Id == request.UserId);
        var collectionEntity = CollectionMappings.CollectionRequestToEntity(request);
        collectionEntity.User = userEntity;
        await _validator.ValidateAndThrowAsync(collectionEntity);
        _context.ClothingCollections.Add(collectionEntity);
        var recordsChanged = await _context.SaveChangesAsync();
        if (recordsChanged == 0)
        {
            throw new ApplicationException("Failure to update the database");
        }

        var collectionResponse = CollectionMappings.CollectionEntityToResponse(collectionEntity);
        collectionResponse.UserId = request.UserId;
        return collectionResponse;
    }

    public async Task<CollectionResponse> UpdateClothingCollection(int id, CollectionUpdateRequest request)
    {
        var collection = await _context.ClothingCollections.FirstAsync(c => c.Id == id);
        collection.Name = request.Name ?? collection.Name;
        collection.Brand = request.Brand ?? collection.Brand;
        collection.Budget = request.Budget ?? collection.Budget;
        collection.LaunchYear = request.LaunchYear ?? collection.LaunchYear;
        collection.Season = request.Season ?? collection.Season;
        collection.SystemActivity = request.SystemActivity ?? collection.SystemActivity;
        if (request.UserId != null)
        {
            try
            {
                collection.User = await _context.Users.FirstAsync(u => u.Id == request.UserId);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"The userId value: {request.UserId} doesnt exist in the database",
                    nameof(request.UserId));
            }
        }

        await _validator.ValidateAndThrowAsync(collection);
        await _context.SaveChangesAsync();
        return CollectionMappings.CollectionEntityToResponse(collection);
    }

    public async Task<CollectionResponse> UpdateClothingStatus(int id, CollectionStatusUpdateRequest request)
    {
        var entity = await _context.ClothingCollections.FirstAsync(c => c.Id == id);
        entity.SystemActivity = request.SystemActivity;
        await _validator.ValidateAndThrowAsync(entity);
        await _context.SaveChangesAsync();
        return CollectionMappings.CollectionEntityToResponse(entity);
    }

    public async Task<IEnumerable<CollectionResponse>> GetAllCollection(string? status)
    {
        return status switch
        {
            null => await _context.ClothingCollections.Select(c => CollectionMappings
                .CollectionEntityToResponse(c)).ToListAsync(),
            "ATIVO" => await _context.ClothingCollections
                .Where(c => c.SystemActivity == SystemActivity.Active)
                .Select(c => CollectionMappings.CollectionEntityToResponse(c))
                .ToListAsync(),
            "INATIVO" => await _context.ClothingCollections
                .Where(c => c.SystemActivity == SystemActivity.Inactive)
                .Select(c => CollectionMappings.CollectionEntityToResponse(c))
                .ToListAsync(),
            _ => throw new ArgumentException($"argument {status} is not allowed", nameof(status))
        };
    }

    public async Task<CollectionResponse> GetClothingCollection(int id)
    {
        var collectionEntity = await _context.ClothingCollections.FirstAsync(c => c.Id == id);
        return CollectionMappings.CollectionEntityToResponse(collectionEntity);
    }

    public async Task DeleteClothingCollection(int id)
    {
        var recordsChanged = await _context.Database.ExecuteSqlAsync($@"DELETE FROM ClothingCollections
                                        WHERE Id = {id}");
        if (recordsChanged == 0)
        {
            throw new DbUpdateException();
        }
    }
}