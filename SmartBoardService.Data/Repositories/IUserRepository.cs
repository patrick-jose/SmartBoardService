using SmartBoardService.Data.DTOs;

namespace SmartBoardService.Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> InsertUserAsync(UserDTO user);
        Task<bool> InsertUsersAsync(List<UserDTO> users);
        Task<bool> UpdateUserAsync(UserDTO user);
        Task<bool> UpdateUsersAsync(List<UserDTO> users);
    }
}