using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Project.DataBase.Models;
using Project.DataBase.Repository.Interfaces;

namespace Project.DataBase.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IDbContext _context;

        public EmployeeRepository(IDbContext context)
        {
            _context = context;
        }

        public void Update(Employee item)
        {
            SqlCommand sqlCom = new SqlCommand("UPDATE Employee SET CompanyId = @CompanyId, Position = @Position, F = @F, I = @I, " +
                                                              "O = @O, EmploymentDate = @EmploymentDate WHERE EmployeeId = @EmployeeId");

            sqlCom.Parameters.Add("EmployeeId", SqlDbType.Int).Value = item.Id;
            sqlCom.Parameters.Add("EmploymentDate", SqlDbType.Date).Value = item.EmploymentDate;
            sqlCom.Parameters.Add("CompanyId", SqlDbType.Int).Value = item.CompanyId;
            sqlCom.Parameters.Add("Position", SqlDbType.VarChar, 50).Value = item.Position;
            sqlCom.Parameters.Add("F", SqlDbType.VarChar, 50).Value = item.F;
            sqlCom.Parameters.Add("I", SqlDbType.VarChar, 50).Value = item.I;
            sqlCom.Parameters.Add("O", SqlDbType.VarChar, 50).Value = item.O;

            _context.ExecuteNonQueryCommand(sqlCom);
        }

        public void Delete(int employeeId)
        {
            SqlCommand sqlCom = new SqlCommand("DELETE Employee WHERE EmployeeId = @EmployeeId");

            sqlCom.Parameters.Add("EmployeeId", SqlDbType.Int).Value = employeeId;

            _context.ExecuteNonQueryCommand(sqlCom);
        }

        public void Add(Employee item)
        {
            SqlCommand sqlCom = new SqlCommand("INSERT INTO Employee(CompanyId, Position, F, I, O, EmploymentDate) " +
                                                        "VALUES (@CompanyId, @Position, @F, @I, @O, @EmploymentDate)");

            sqlCom.Parameters.Add("EmploymentDate", SqlDbType.Date).Value = item.EmploymentDate;
            sqlCom.Parameters.Add("CompanyId", SqlDbType.Int).Value = item.CompanyId;
            sqlCom.Parameters.Add("Position", SqlDbType.VarChar, 50).Value = item.Position;
            sqlCom.Parameters.Add("F", SqlDbType.VarChar, 50).Value = item.F;
            sqlCom.Parameters.Add("I", SqlDbType.VarChar, 50).Value = item.I;
            sqlCom.Parameters.Add("O", SqlDbType.VarChar, 50).Value = item.O;

            _context.ExecuteNonQueryCommand(sqlCom);
        }

        public IEnumerable<Employee> Select()
        {
            SqlCommand sqlCom = new SqlCommand("SELECT EmployeeId, CompanyId, Position, F, I, O, EmploymentDate FROM Employee");

            var list = new List<Employee>();
            var reader = _context.ExecuteReader(sqlCom);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        Id = (int)reader["EmployeeId"],
                        CompanyId = (int)reader["CompanyId"],
                        Position = (string)reader["Position"],
                        F = (string)reader["F"],
                        I = (string)reader["I"],
                        O = (string)reader["O"],
                        EmploymentDate = (DateTime)reader["EmploymentDate"]
                    });
                }
            }

            return list;
        }
    }
}
