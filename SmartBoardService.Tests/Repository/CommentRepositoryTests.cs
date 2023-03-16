using System;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Data.Repositories;
using SmartBoardService.Utils;

namespace SmartBoardService.Tests.Repository
{
    [TestClass]
    public class CommentRepositoryTests
    {
        private ICommentRepository _commentRepository;
        private ILogWriter _log;

        [TestMethod]
        public async Task InsertCommentAsyncTest()
        {
            _log = new LogWriter();
            _commentRepository = new CommentRepository(_log);

            var dto = new CommentDTO()
            {
                TaskId = 30,
                Content = "Teste de integração",
                DateCreation = DateTime.Now,
                WriterId = 1 
            };

            var result = await _commentRepository.InsertCommentAsync(dto);

            Assert.IsTrue(result);
        }
    }
}

