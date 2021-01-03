using Northwind.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.Repositories.Abstract
{
    public interface IEmployeeRepository : IBaseRepository<Employees>
    {
        IEnumerable<Employees> GetTopEmployees(int count);
        List<Employees> GetByLastName(string LastName);
        
    }
}
