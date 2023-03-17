using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public BoardRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<bool> InsertBoardAsync(BoardDTO board)
        {
            try
            {
                string commandText = @$"insert into smartboard.board (name, active)
                                        values (@name, @active)";

                var queryArgs = new { name = board.Name, active = board.Active };

                var result = await _dbConnection.connection.ExecuteAsync(commandText, queryArgs);

                _dbConnection.CloseConnection();

                Console.WriteLine("Data inserted! ----------> " + queryArgs);

                return result == 1;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateBoardAsync(BoardDTO board)
        {
            try
            {
                string commandText = @$"update smartboard.board
                                        set name = @name,
                                        active = @active
                                        where id = @id";

                var queryArgs = new { name = board.Name, active = board.Active, id = board.Id };

                var result = await _dbConnection.connection.ExecuteAsync(commandText, queryArgs);

                _dbConnection.CloseConnection();

                Console.WriteLine("Data updated! ----------> " + queryArgs);

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

