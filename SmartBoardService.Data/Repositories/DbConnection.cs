using System;
using Npgsql;
using SmartBoardService.Utils;

namespace SmartBoardService.Data.Repositories
{
    public class DbConnection : IDbConnection
    {
        private const string CONNECTION_STRING = "Host=smartboarddb;port=5432;Username=postgres;Password=postgrespw;Database=smartboarddb;Pooling=false;Timeout=300;CommandTimeout=300";
        public readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;

        internal DbConnection(ILogWriter log)
        {
            try
            {
                _log = log;
                connection = new NpgsqlConnection(CONNECTION_STRING);
                connection.Open();
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw;
            }
        }

        public void CloseConnection()
        {
            this.connection.Close();
        }

        public DbConnection GetConnection()
        {
            return this;
        }
    }
}

