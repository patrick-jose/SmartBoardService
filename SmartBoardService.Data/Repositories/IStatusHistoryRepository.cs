using SmartBoardService.Data.DTOs;

namespace SmartBoardService.Data.Repositories
{
    public interface IStatusHistoryRepository
    {
        Task<bool> InsertStatusHistoryAsync(StatusHistoryDTO statusHistory);
    }
}