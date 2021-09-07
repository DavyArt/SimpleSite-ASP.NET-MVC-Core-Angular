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
    public class CompanyRepository : ICompanyRepository
    {
        IDbContext _context;

        public CompanyRepository(IDbContext context)
        {
            _context = context;
        }

        public void Update(Company item)
        {
            SqlCommand sqlCom = new SqlCommand("UPDATE Company SET Name = @Name WHERE CompanyId = @CompanyId");

            sqlCom.Parameters.Add("Name", SqlDbType.VarChar, 50).Value = item.Name;
            sqlCom.Parameters.Add("CompanyId", SqlDbType.Int).Value = item.Id;

            _context.ExecuteNonQueryCommand(sqlCom);
        }

        public void Delete(int companyId)
        {
            SqlCommand sqlCom = new SqlCommand("DELETE Company WHERE CompanyId = @CompanyId");

            sqlCom.Parameters.Add("CompanyId", SqlDbType.Int).Value = companyId;

            _context.ExecuteNonQueryCommand(sqlCom);
        }

        public void Add(Company item)
        {
            SqlCommand sqlCom = new SqlCommand("INSERT INTO Company(Name) VALUES (@Name)");

            sqlCom.Parameters.Add("Name", SqlDbType.VarChar, 50).Value = item.Name;

            _context.ExecuteNonQueryCommand(sqlCom);
        }

        public IEnumerable<Company> Select()
        {
            SqlCommand sqlCom = new SqlCommand("SELECT CompanyId, Name FROM Company");

            var list = new List<Company>();
            var reader = _context.ExecuteReader(sqlCom);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new Company()
                    {
                        Id = (int)reader["CompanyId"],
                        Name = (string)reader["Name"]
                    });
                }
            }

            return list;
        }

        public Company GetByCompanyId(int companyId)
        {
            SqlCommand sqlCom = new SqlCommand("SELECT CompanyId, Name FROM Company WHERE CompanyId = @CompanyId");

            sqlCom.Parameters.Add("CompanyId", SqlDbType.Int).Value = companyId;

            var company = new Company();
            var reader = _context.ExecuteReader(sqlCom);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    company = new Company()
                    {
                        Id = (int)reader["CompanyId"],
                        Name = (string)reader["Name"]
                    };
                }
            }

            return company;
        }
    }
}
