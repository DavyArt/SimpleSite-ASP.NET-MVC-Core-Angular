using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Project.DataBase;
using Project.DataBase.Models;
using Project.DataBase.Repository;
using Project.DataBase.Repository.Interfaces;
using Project.API.Services.Interfaces;

namespace Project.API.Services
{
    public class DbContextService : IDbContextService
    {
        private IDbContext _dbContext;
        private IEmployeeRepository _employee;
        private ICompanyRepository _company;

        public IEmployeeRepository Employee 
        { 
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_dbContext);
                }

                return _employee;
            }
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_dbContext);
                }

                return _company;
            }
        }

        public DbContextService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
