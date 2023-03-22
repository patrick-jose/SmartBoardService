using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public SectionRepository(ILogWriter log, DbConnection dbConnection)
        {
            _log = log;
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertSectionAsync(SectionDTO section)
        {
            try
            {
                string commandText = @$"insert into smartboard.section
                                        (name, boardid, position, active)
                                        values (@name, @boardid, @position, @active)";

                var queryArgs = new
                {
                    name = section.Name,
                    boardid = section.BoardId,
                    position = section.Position,
                    active = section.Active
                };

                Console.WriteLine(queryArgs);

                var result = await _dbConnection.connection.ExecuteAsync(commandText, queryArgs);

                _dbConnection.CloseConnection();

                Console.WriteLine("Data inserted! ----------> " + queryArgs);

                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateSectionAsync(SectionDTO section)
        {
            try
            {
                string commandText = @$"update smartboard.section
                                        set name = @name,
                                        position = @position,
                                        active = @active
                                        where id = @id";

                var queryArgs = new
                {
                    id = section.Id,
                    name = section.Name,
                    position = section.Position,
                    active = section.Active
                };

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

        public async Task<bool> UpdateSectionsAsync(List<SectionDTO> sections)
        {
            try
            {
                var result = new List<bool>();

                foreach (var section in sections)
                {
                    result.Add(await this.UpdateSectionAsync(section));
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

