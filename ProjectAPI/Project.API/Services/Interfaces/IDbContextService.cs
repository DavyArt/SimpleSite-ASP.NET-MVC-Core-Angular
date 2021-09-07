using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Project.DataBase.Models;
using Project.DataBase.Repository.Interfaces;

namespace Project.API.Services.Interfaces
{
    public interface IDbContextService
    {
        public IEmployeeRepository Employee { get; }
        public ICompanyRepository Company { get; }
    }
}