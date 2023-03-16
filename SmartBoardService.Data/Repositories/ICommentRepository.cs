using SmartBoardService.Data.DTOs;

namespace SmartBoardService.Data.Repositories
{
    public interface ICommentRepository
    {
        Task<bool> InsertCommentAsync(CommentDTO comment);
    }
}