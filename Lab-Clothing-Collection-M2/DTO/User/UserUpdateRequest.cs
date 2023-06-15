using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.DTO.User;

public class UserUpdateRequest
{
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public UserType? UserType { get; set; }
    public string? PhoneNumber { get; set; }
}