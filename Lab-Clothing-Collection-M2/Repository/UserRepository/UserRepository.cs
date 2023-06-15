using FluentValidation;
using Lab_Clothing_Collection_M2.Context;
using Lab_Clothing_Collection_M2.DTO.User;
using Lab_Clothing_Collection_M2.Entities;
using Lab_Clothing_Collection_M2.Mappings;
using Lab_Clothing_Collection_M2.Validators;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Repository.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly ClothingContext _context;
    private readonly UserValidator _validator;

    public UserRepository(ClothingContext context, UserValidator userValidator, UserValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<UserResponse> AddUser(UserRequest user)
    {
        var userEntity = UserMappings.UserRequestToEntity(user);
        await _validator.ValidateAndThrowAsync(userEntity);
        _context.Users.Add(userEntity);
        var recordsChanged = await _context.SaveChangesAsync();
        if (recordsChanged == 0)
        {
            throw new DbUpdateException();
        }
        return UserMappings.UserEntityToResponse(userEntity);
    }

    public async Task<UserResponse> UpdateUser(int userId, UserUpdateRequest request)
    {
        var userEntity = await _context.Users.
            FirstAsync(u => u.Id == userId);
        userEntity.UserType = request.UserType ?? userEntity.UserType;
        userEntity.Gender = request.Gender ?? userEntity.Gender;
        userEntity.Name = request.Name ?? userEntity.Name;
        userEntity.BirthDate = request.BirthDate ?? userEntity.BirthDate;
        userEntity.PhoneNumber = request.PhoneNumber ?? userEntity.PhoneNumber;
        await _validator.ValidateAndThrowAsync(userEntity);
        var recordsChanged = await _context.SaveChangesAsync();
        if (recordsChanged == 0)
        {
            throw new DbUpdateException("Failure to update the database");
        }

        return UserMappings.UserEntityToResponse(userEntity);
    }

    public async Task<UserResponse> UpdateStatusUser(int userId, UserStatusUpdateRequest request)
    {
        var userEntity = await _context.Users
            .FirstAsync(u => u.Id == userId);
        userEntity.UserStatus = request.UserStatus;
        await _validator.ValidateAndThrowAsync(userEntity);
        var recordsChanged = await _context.SaveChangesAsync();
        if (recordsChanged == 0)
        {
            throw new DbUpdateException("Failure to update the database");
        }

        return UserMappings.UserEntityToResponse(userEntity);
    }

    public async Task<IEnumerable<UserResponse>> GetUsersStatus(string? param)
    {
        return param switch
        {
            null => await _context.Users.Select(u => UserMappings.UserEntityToResponse(u)).ToListAsync(),
            "ATIVO" => await _context.Users.Where(u => u.UserStatus == UserStatus.Active)
                .Select(u => UserMappings.UserEntityToResponse(u))
                .ToListAsync(),
            "INATIVO" => await _context.Users.Where(u => u.UserStatus == UserStatus.Inactive)
                .Select(u => UserMappings.UserEntityToResponse(u))
                .ToListAsync(),
            _ => throw new ArgumentException($"argument {param} is not allowed", nameof(param))
        };
    }

    public async Task<UserResponse> GetUserById(int id)
    {
        var userEntity = await _context.Users.FirstAsync(u => u.Id == id);
        return UserMappings.UserEntityToResponse(userEntity);
    }
}