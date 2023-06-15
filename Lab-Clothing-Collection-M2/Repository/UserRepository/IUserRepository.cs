using Lab_Clothing_Collection_M2.DTO.User;

namespace Lab_Clothing_Collection_M2.Repository.UserRepository;

public interface IUserRepository
{
    public Task<UserResponse> AddUser(UserRequest user);
    public Task<UserResponse> UpdateUser(int userId, UserUpdateRequest request);
    public Task<UserResponse> UpdateStatusUser(int userId, UserStatusUpdateRequest request);
    public Task<IEnumerable<UserResponse>> GetUsersStatus(string? param);
    public Task<UserResponse> GetUserById(int id);
}