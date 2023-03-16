using System;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Data.Repositories;
using SmartBoardService.Utils;

namespace SmartBoardService.Tests.Repository
{
    [TestClass]
    public class BoardRepositoryTests
    {
        private IBoardRepository _boardRepository;
        private ILogWriter _log;

        [TestMethod]
        public async Task UpdateBoardAsyncTest()
        {
            _log = new LogWriter();
            _boardRepository = new BoardRepository(_log);

            var dto = new BoardDTO()
            {
                Id = 3,
                Name = "Teste integração update",
                Active = false
            };

            var result = await _boardRepository.UpdateBoardAsync(dto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertBoardAsyncTest()
        {
            _log = new LogWriter();
            _boardRepository = new BoardRepository(_log);

            var dto = new BoardDTO()
            {
                Name = "Teste integração",
                Active = true
            };

            var result = await _boardRepository.InsertBoardAsync(dto);

            Assert.IsTrue(result);
        }
    }
}

