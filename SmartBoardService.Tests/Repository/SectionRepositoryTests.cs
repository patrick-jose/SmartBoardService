using System;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Data.Repositories;
using SmartBoardService.Utils;

namespace SmartBoardService.Tests.Repository
{
    [TestClass]
    public class SectionRepositoryTests
    {
        private ISectionRepository _sectionRepository;
        private ILogWriter _log;
        private DbConnection _dbConnection;

        internal void StartServices()
        {
            _log = new LogWriter();
            _dbConnection = new DbConnection(_log);
            _sectionRepository = new SectionRepository(_log, _dbConnection);
        }

        [TestMethod]
        public async Task UpdateSectionAsyncTest()
        {
            StartServices();

            var dto = new SectionDTO()
            {
                Active = false,
                Name = "Teste integração",
                Id = 6,
                Position = 2
            };

            var result = await _sectionRepository.UpdateSectionAsync(dto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateSectionsAsyncTest()
        {
            StartServices();

            var dto1 = new SectionDTO()
            {
                Active = true,
                Id = 5,
                Name = "Teste integração multiplos updates 1",
                Position = 4
            };

            var dto2 = new SectionDTO()
            {
                Active = true,
                Id = 10,
                Name = "Teste integração multiplos updates 2",
                Position = 1
            };

            var dtos = new List<SectionDTO>();
            dtos.Add(dto1);
            dtos.Add(dto2);

            var result = await _sectionRepository.UpdateSectionsAsync(dtos);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertSectionAsyncTest()
        {
            StartServices();

            var dto = new SectionDTO()
            {
                Active = true,
                Name = "Teste integração",
                Position = 1,
                BoardId = 3
            };

            var result = await _sectionRepository.InsertSectionAsync(dto);

            Assert.IsTrue(result);
        }
    }
}

