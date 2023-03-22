using System;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Data.Repositories;
using SmartBoardService.Utils;

namespace SmartBoardService.Tests.Repository
{
    [TestClass]
    public class TaskRepositoryTests
    {
        private ITaskRepository _taskRepository;
        private ILogWriter _log;
        private DbConnection _dbConnection;

        internal void StartServices()
        {
            _log = new LogWriter();
            _dbConnection = new DbConnection(_log);
            _taskRepository = new TaskRepository(_log, _dbConnection);
        }

        [TestMethod]
        public async Task UpdateTaskAsyncTest()
        {
            StartServices();

            var dto = new TaskDTO()
            {
                Id = 2,
                Name = "Teste integração",
                Active = true,
                AssigneeId = 2,
                Blocked = false,
                Description = "Descrição teste integrado",
                Position = 2,
                SectionId = 1
            };

            var result = await _taskRepository.UpdateTaskAsync(dto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateTasksAsyncTest()
        {
            StartServices();

            var dto1 = new TaskDTO()
            {
                Id = 4,
                Name = "Teste integração",
                Active = true,
                AssigneeId = 2,
                Blocked = false,
                Description = "Descrição teste integrado",
                Position = 3,
                SectionId = 1
            };

            var dto2 = new TaskDTO()
            {
                Id = 3,
                Name = "Teste integração 2",
                Active = true,
                AssigneeId = 2,
                Blocked = false,
                CreatorId = 2,
                Position = 4,
                SectionId = 1
            };

            var dtos = new List<TaskDTO>();
            dtos.Add(dto1);
            dtos.Add(dto2);

            var result = await _taskRepository.UpdateTasksAsync(dtos);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertTaskAsyncTest()
        {
            StartServices();

            var dto = new TaskDTO()
            {
                Name = "Teste integração",
                Active = true,
                AssigneeId = 2,
                Blocked = false,
                CreatorId = 2,
                DateCreation = DateTime.Now.AddDays(-12),
                Description = "Descrição teste integrado",
                Position = 3,
                SectionId = 3
            };

            var result = await _taskRepository.InsertTaskAsync(dto);

            Assert.IsTrue(result);
        }
    }
}

