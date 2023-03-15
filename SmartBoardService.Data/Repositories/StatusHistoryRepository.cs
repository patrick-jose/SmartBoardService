using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class StatusHistoryRepository : IStatusHistoryRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public StatusHistoryRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<bool> InsertStatusHistoryAsync(StatusHistoryDTO statusHistory)
        {
            try
            {
                string commandText = @$"insert into smartboard.statusHistory (taskid, datemodified, previoussectionid, userid, actualsectionid)
                                        values (@taskid, @datemodified, @previoussectionid, @userid, @actualsectionid)";

                var queryArgs = new
                {
                    taskId = statusHistory.TaskId,
                    dateModified = statusHistory.DateModified,
                    previousSectionId = statusHistory.PreviousSection.Id,
                    userid = statusHistory.User.Id,
                    actualsectionid = statusHistory.ActualSection.Id
                };

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

        public async Task<bool> InsertStatusHistoriesAsync(List<StatusHistoryDTO> statusHistories)
        {
            try
            {
                var result = new List<bool>();

                foreach (var statusHistory in statusHistories)
                {
                    result.Add(await this.InsertStatusHistoryAsync(statusHistory));
                }

                return !result.Contains(false);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }
    }
}

