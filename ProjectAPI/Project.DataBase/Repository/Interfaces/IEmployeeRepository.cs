using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataBase.Models;

namespace Project.DataBase.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Select();
        void Add(Employee item);
        void Update(Employee item);
        void Delete(int employeeId);
    }
}
