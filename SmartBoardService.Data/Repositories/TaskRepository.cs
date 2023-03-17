using System;
using Dapper;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ILogWriter _log;
        private readonly DbConnection _dbConnection;

        public TaskRepository(ILogWriter log)
        {
            _log = log;
            _dbConnection = new DbConnection(_log);
        }

        public async Task<bool> InsertTaskAsync(TaskDTO task)
        {
            try
            {
                string commandText = @$"insert into smartboard.task
                                        (name, description, datecreation, creatorid, sectionid, blocked, assigneeid, position, active)
                                        values (@name, @description, @datecreation, @creatorid, @sectionid, @blocked, @assigneeid, @position, @active)";

                var queryArgs = new
                {
                    name = task.Name,
                    description = task.Description,
                    creatorid = task.CreatorId,
                    sectionid = task.SectionId,
                    blocked = task.Blocked,
                    assigneeid = task.AssigneeId,
                    position = task.Position,
                    active = task.Active,
                    datecreation = task.DateCreation
                };

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

        public async Task<bool> UpdateTaskAsync(TaskDTO task)
        {
            try
            {
                string commandText = @$"update smartboard.task
                                        set name = @name,
                                        description = @description,
                                        sectionid = @sectionid,
                                        blocked = @blocked,
                                        assigneeid = @assigneeid,
                                        position = @position,
                                        active = @active
                                        where id = @id";

                var queryArgs = new
                {
                    id = task.Id,
                    name = task.Name,
                    description = task.Description,
                    sectionid = task.SectionId,
                    blocked = task.Blocked,
                    assigneeid = task.AssigneeId,
                    position = task.Position,
                    active = task.Active
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

        public async Task<bool> UpdateTasksAsync(List<TaskDTO> tasks)
        {
            try
            {
                var result = new List<bool>();

                foreach (var task in tasks)
                {
                    result.Add(await this.UpdateTaskAsync(task));
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

