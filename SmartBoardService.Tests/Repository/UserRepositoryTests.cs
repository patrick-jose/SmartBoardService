using System;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Data.Repositories;
using SmartBoardService.Utils;

namespace SmartBoardService.Tests.Repository
{
    [TestClass]
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;
        private ILogWriter _log;
        private DbConnection _dbConnection;

        internal void StartServices()
        {
            _log = new LogWriter();
            _dbConnection = new DbConnection(_log);
            _userRepository = new UserRepository(_log, _dbConnection);
        }

        [TestMethod]
        public async Task UpdateUserAsyncTest()
        {
            StartServices();

            var dto = new UserDTO()
            {
                Id = 2,
                Name = "Marcio",
                Password = "marciopw"
            };

            var result = await _userRepository.UpdateUserAsync(dto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertUserAsyncTest()
        {
            StartServices();

            var dto = new UserDTO()
            {
                Id = 2,
                Name = "Insert Test",
                Password = "testpw"
            };

            var result = await _userRepository.InsertUserAsync(dto);

            Assert.IsTrue(result);
        }
    }
}

