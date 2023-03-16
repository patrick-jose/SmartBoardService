using SmartBoardService.Data.DTOs;

namespace SmartBoardService.Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> InsertUserAsync(UserDTO user);
        Task<bool> UpdateUserAsync(UserDTO user);
    }
}