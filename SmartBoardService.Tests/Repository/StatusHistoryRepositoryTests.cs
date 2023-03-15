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
        public async Task InsertStatusHistoryAsyncTest()
        {
            _log = new LogWriter();
            _statusHistoryRepository = new StatusHistoryRepository(_log);

            var dto = new StatusHistoryDTO()
            {
                TaskId = 30,
                ActualSection = new SectionDTO() { Id = 7 },
                PreviousSection = new SectionDTO() { Id = 6 },
                DateModified = DateTime.Now,
                User = new UserDTO() { Id = 3 }
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
                TaskId = 31,
                ActualSection = new SectionDTO() { Id = 8 },
                PreviousSection = new SectionDTO() { Id = 5 },
                DateModified = DateTime.Now,
                User = new UserDTO() { Id = 1 }
            };
            var dto2 = new StatusHistoryDTO()
            {
                TaskId = 32,
                ActualSection = new SectionDTO() { Id = 10 },
                PreviousSection = new SectionDTO() { Id = 6 },
                DateModified = DateTime.Now,
                User = new UserDTO() { Id = 2 }
            };

            list.Add(dto1);
            list.Add(dto2);

            var result = await _statusHistoryRepository.InsertStatusHistorysAsync(list);

            Assert.IsTrue(result);
        }
    }
}

