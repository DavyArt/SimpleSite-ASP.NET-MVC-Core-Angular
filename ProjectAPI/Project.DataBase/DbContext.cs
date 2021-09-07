using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Project.DataBase.Repository;

namespace Project.DataBase
{
    public class DbContext : IDbContext, IDisposable
    {
        public string Path { get; }

        private SqlConnection connection;

        public DbContext(string connectionString)
        {
            Path = connectionString;

            connection = new SqlConnection(Path);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void ExecuteNonQueryCommand(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = connection;
            sqlCommand.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = connection;

            var reader = sqlCommand.ExecuteReader();

            return reader;
        }
    }
}
