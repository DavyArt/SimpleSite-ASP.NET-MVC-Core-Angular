using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase
{
    public interface IDbContext
    {
        string Path { get; }
        void ExecuteNonQueryCommand(SqlCommand sqlCommand);
        SqlDataReader ExecuteReader(SqlCommand sqlCommand);
    }
}
