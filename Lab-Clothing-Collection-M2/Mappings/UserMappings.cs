using System.Text;
using Lab_Clothing_Collection_M2.DTO.User;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Mappings;

public static class UserMappings
{
    public static string GetFormattedId(string? unformattedId)
    {
        if (unformattedId == null)
        {
            throw new ArgumentException("unformattedId field can't be null", nameof(unformattedId));
        }
        var charArray = unformattedId.ToCharArray();
        var strBuilder = new StringBuilder();
        foreach (var t in charArray)
        {
            if (char.IsNumber(t))
            {
                strBuilder.Append(t);
            }
        }
        return strBuilder.ToString() ?? 
               throw new ArgumentException("The provided string is empty", nameof(unformattedId));
    }

    public static User UserRequestToEntity(UserRequest request)
    {
        return new User
        {
            BirthDate = request.BirthDate ?? 
                        throw new ArgumentException("Birthday field can't be null", nameof(request)),
            DocumentId = GetFormattedId(request.DocumentId),
            Email = request.Email ??
                    throw new ArgumentException("Email field can't be null", nameof(request)),
            Gender = request.Gender ??
                     throw new ArgumentException("Gender field can't be null", nameof(request)),
            Name = request.Name ??
                   throw new ArgumentException("Name field can't be null", nameof(request)),
            PhoneNumber = request.PhoneNumber??
                          throw new ArgumentException("PhoneNumber field can't be null", nameof(request)),
            UserStatus = request.UserStatus??
                         throw new ArgumentException("UserStatus field can't be null", nameof(request)),
            UserType = request.UserType??
                       throw new ArgumentException("UserType field can't be null", nameof(request))
        };
    }

    public static UserResponse UserEntityToResponse(User response)
    {
        return new UserResponse
        {
            Id = response.Id,
            BirthDate = response.BirthDate,
            DocumentId = response.DocumentId,
            Email = response.Email,
            Gender = response.Gender,
            Name = response.Gender,
            PhoneNumber = response.PhoneNumber,
            UserStatus = response.UserStatus,
            UserType = response.UserType
        };
    }
}