using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataBase.Models;

namespace Project.DataBase.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> Select();
        Company GetByCompanyId(int companyId);
        void Add(Company item);
        void Update(Company item);
        void Delete(int companyId);
    }
}
