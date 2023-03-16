using SmartBoardService.Data.DTOs;

namespace SmartBoardService.Data.Repositories
{
    public interface ITaskRepository
    {
        Task<bool> InsertTaskAsync(TaskDTO task);
        Task<bool> UpdateTaskAsync(TaskDTO task);
        Task<bool> UpdateTasksAsync(List<TaskDTO> task);
    }
}