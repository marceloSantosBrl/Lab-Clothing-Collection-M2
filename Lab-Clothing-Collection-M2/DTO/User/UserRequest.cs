using Lab_Clothing_Collection_M2.Entities;

namespace Lab_Clothing_Collection_M2.DTO.User;

public class UserRequest
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public string DocumentId { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public UserType UserType { get; set; }
    public UserStatus UserStatus { get; set; }
}