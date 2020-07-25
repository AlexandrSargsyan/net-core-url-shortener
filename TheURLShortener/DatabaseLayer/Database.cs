using System.Data.SqlClient;
using TheURLShortener.Models;

namespace TheURLShortener.DatabaseLayer
{
    public class Database : IDatabase
    {
        private readonly string _connectionString;
        public Database(IConnectionStringProvider provider)
        {
            _connectionString = provider.ConnectionString;
        }

        public string GetUrl(string alias)
        {
            var url = string.Empty;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @$"SELECT URL FROM dbo.URLs WHERE Alias ='{alias}'";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    url = reader.GetString(0);
                }
            }

            return url;
        }

        public int Insert(URLEntity uRLEntity)
        {
            var id = -1;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @$"INSERT INTO dbo.URLs VALUES (N'{uRLEntity.Alias}',N'{uRLEntity.Url}') SELECT @@IDENTITY";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader.GetDecimal(0);
                }
            }

            return id;
        }

        
    }
}