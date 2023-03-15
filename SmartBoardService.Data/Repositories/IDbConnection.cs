namespace SmartBoardService.Data.Repositories
{
    public interface IDbConnection
    {
        void CloseConnection();
        DbConnection GetConnection();
    }
}