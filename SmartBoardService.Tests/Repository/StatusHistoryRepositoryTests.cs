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
        private DbConnection _dbConnection;

        internal void StartServices()
        {
            _log = new LogWriter();
            _dbConnection = new DbConnection(_log);
            _statusHistoryRepository = new StatusHistoryRepository(_log, _dbConnection);
        }

        [TestMethod]
        public async Task InsertStatusHistoryAsyncTest()
        {
            StartServices();

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

