using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public CommentRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<bool> InsertCommentAsync(CommentDTO comment)
        {
            try
            {
                string commandText = @$"insert into smartboard.comment (taskid, writerid, content, datecreation)
                                        values (@taskid, @writerid, @content, @datecreation)";

                var queryArgs = new
                {
                    taskId = comment.TaskId,
                    datecreation = comment.DateCreation,
                    content = comment.Content,
                    writerid = comment.WriterId
                };

                Console.WriteLine(queryArgs);

                var result = await _dbConnection.connection.ExecuteAsync(commandText, queryArgs);

                _dbConnection.CloseConnection();

                Console.WriteLine("Data inserted! ----------> " + queryArgs);

                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

