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
        private DbConnection _dbConnection;

        internal void StartServices()
        {
            _log = new LogWriter();
            _dbConnection = new DbConnection(_log);
            _boardRepository = new BoardRepository(_log, _dbConnection);
        }

        [TestMethod]
        public async Task UpdateBoardAsyncTest()
        {
            StartServices();

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
            StartServices();

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

