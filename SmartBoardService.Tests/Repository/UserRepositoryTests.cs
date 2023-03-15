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

        [TestMethod]
        public async Task UpdateUserAsyncTest()
        {
            _log = new LogWriter();
            _userRepository = new UserRepository(_log);

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
        public async Task UpdateUsersAsyncTest()
        {
            _log = new LogWriter();
            _userRepository = new UserRepository(_log);

            var list = new List<UserDTO>();
            var dto1 = new UserDTO()
            {
                Id = 2,
                Name = "Fabricio",
                Password = "fabriciopw"
            };
            var dto2 = new UserDTO()
            {
                Id = 1,
                Name = "Patrick",
                Password = "patrickpw"
            };

            list.Add(dto1);
            list.Add(dto2);

            var result = await _userRepository.UpdateUsersAsync(list);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertUserAsyncTest()
        {
            _log = new LogWriter();
            _userRepository = new UserRepository(_log);

            var dto = new UserDTO()
            {
                Id = 2,
                Name = "Insert Test",
                Password = "testpw"
            };

            var result = await _userRepository.InsertUserAsync(dto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task InsertUsersAsyncTest()
        {
            _log = new LogWriter();
            _userRepository = new UserRepository(_log);

            var list = new List<UserDTO>();
            var dto1 = new UserDTO()
            {
                Name = "Test Multiple 1",
                Password = "testpw"
            };
            var dto2 = new UserDTO()
            {
                Name = "Test Multiple 2",
                Password = "test2pw"
            };

            list.Add(dto1);
            list.Add(dto2);

            var result = await _userRepository.InsertUsersAsync(list);

            Assert.IsTrue(result);
        }
    }
}

