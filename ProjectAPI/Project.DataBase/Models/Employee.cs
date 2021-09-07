using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Position { get; set; }
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}
