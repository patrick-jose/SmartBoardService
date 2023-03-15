﻿using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class StatusHistoryRepository
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
                string commandText = @$"insert into smartboard.statusHistory (name, password)
                                        values (@name, @password)";

                var queryArgs = new { name = statusHistory.Name, password = statusHistory.Password };

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

        public async Task<bool> InsertStatusHistorysAsync(List<StatusHistoryDTO> statusHistorys)
        {
            try
            {
                var result = new List<bool>();

                foreach (var statusHistory in statusHistorys)
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

        public async Task<bool> UpdateStatusHistoryAsync(StatusHistoryDTO statusHistory)
        {
            try
            {
                string commandText = @$"update smartboard.statusHistory
                                        set name = @name,
                                        password = @password
                                        where id = @id";

                var queryArgs = new { name = statusHistory.Name, password = statusHistory.Password, id = statusHistory.Id };

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

        public async Task<bool> UpdateStatusHistorysAsync(List<StatusHistoryDTO> statusHistorys)
        {
            try
            {
                var result = new List<bool>();

                foreach (var statusHistory in statusHistorys)
                {
                    result.Add(await this.UpdateStatusHistoryAsync(statusHistory));
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
