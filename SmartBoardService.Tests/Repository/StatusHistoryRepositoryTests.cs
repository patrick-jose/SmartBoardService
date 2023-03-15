using System;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Data.Repositories;
using SmartBoardService.Utils;

namespace SmartBoardService.Tests.Repository
{
    [TestClass]
    public class StatusHistoryRepositoryTests
    {
        private IStatusHistoryRepository _statusHistoryRepository;
        private ILogWriter _log;

        [TestMethod]
        public async Task UpdateStatusHistoryAsyncTest()
        {
            _log = new LogWriter();
            _statusHistoryRepository = new StatusHistoryRepository(_log);

            var dto = new StatusHistoryDTO()
            {
                Id = 2,
                Name = "Marcio",
                Password = "marciopw"
            };

            var result = await _statusHistoryRepository.UpdateStatusHistoryAsync(dto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateStatusHistorysAsyncTest()
        {
            _log = new LogWriter();
            _statusHistoryRepository = new StatusHistoryRepository(_log);

            var list = new List<StatusHistoryDTO>();
            var dto1 = new StatusHistoryDTO()
            {
                Id = 2,
                Name = "Fabricio",
                Password = "fabriciopw"
            };
            var dto2 = new StatusHistoryDTO()
            {
                Id = 1,
                Name = "Patrick",
                Password = "patrickpw"
            };

            list.Add(dto1);
            list.Add(dto2);

            var result = await _statusHistoryRepository.UpdateStatusHistorysAsync(list);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertStatusHistoryAsyncTest()
        {
            _log = new LogWriter();
            _statusHistoryRepository = new StatusHistoryRepository(_log);

            var dto = new StatusHistoryDTO()
            {
                Id = 2,
                Name = "Insert Test",
                Password = "testpw"
            };

            var result = await _statusHistoryRepository.InsertStatusHistoryAsync(dto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertStatusHistorysAsyncTest()
        {
            _log = new LogWriter();
            _statusHistoryRepository = new StatusHistoryRepository(_log);

            var list = new List<StatusHistoryDTO>();
            var dto1 = new StatusHistoryDTO()
            {
                Name = "Test Multiple 1",
                Password = "testpw"
            };
            var dto2 = new StatusHistoryDTO()
            {
                Name = "Test Multiple 2",
                Password = "test2pw"
            };

            list.Add(dto1);
            list.Add(dto2);

            var result = await _statusHistoryRepository.InsertStatusHistorysAsync(list);

            Assert.IsTrue(result);
        }
    }
}

