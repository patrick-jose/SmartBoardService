﻿using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class StatusHistoryRepository : IStatusHistoryRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public StatusHistoryRepository(ILogWriter log, DbConnection dbConnection)
        {
            _log = log;
            _dbConnection = dbConnection;
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
                    previousSectionId = statusHistory.PreviousSectionId,
                    userid = statusHistory.UserId,
                    actualsectionid = statusHistory.ActualSectionId
                };

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
    }
}

