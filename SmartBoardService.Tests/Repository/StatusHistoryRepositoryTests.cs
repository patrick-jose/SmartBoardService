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
                ActualSectionId = 7 ,
                PreviousSectionId = 6 ,
                DateModified = DateTime.Now,
                UserId = 3 
            };

            var result = await _statusHistoryRepository.InsertStatusHistoryAsync(dto);

            Assert.IsTrue(result);
        }
    }
}

