using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public UserRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<bool> InsertUserAsync(UserDTO user)
        {
            try
            {
                string commandText = @$"insert into smartboard.user (name, password)
                                        values (@name, @password)";

                var queryArgs = new { name = user.Name, password = user.Password };

                var result = await _dbConnection.connection.ExecuteAsync(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return result == 1;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            try
            {
                string commandText = @$"update smartboard.user
                                        set name = @name,
                                        password = @password
                                        where id = @id";

                var queryArgs = new { name = user.Name, password = user.Password, id = user.Id };

                var result = await _dbConnection.connection.ExecuteAsync(commandText, queryArgs);

                _dbConnection.CloseConnection();

                return result == 1;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

