using SmartBoardService.Data.DTOs;

namespace SmartBoardService.Data.Repositories
{
    public interface IBoardRepository
    {
        Task<bool> InsertBoardAsync(BoardDTO board);
        Task<bool> UpdateBoardAsync(BoardDTO board);
    }
}