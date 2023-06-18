using System.Text;
using Lab_Clothing_Collection_M2.DTO.User;
using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.Mappings;

public static class UserMappings
{
    public static string GetFormattedId(string unformattedId)
    {
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
                        throw new ArgumentException("Birthday Field can't be null", nameof(request)),
            DocumentId = GetFormattedId(request.DocumentId),
            Email = request.Email,
            Gender = request.Gender,
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            UserStatus = request.UserStatus,
            UserType = request.UserType,
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