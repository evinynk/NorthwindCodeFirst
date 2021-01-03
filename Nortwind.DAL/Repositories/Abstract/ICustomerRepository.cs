using Northwind.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.Repositories.Abstract
{
    public interface ICustomerRepository : IBaseRepository<Customers>
    {
        //IEnumerable<Employees> GetTopCustomer(int count);
        //List<Employees> GetByLastName(string LastName);
    
      //  List<Customers> GetByCity(string city);
        List<Customers> FilterByCity(Expression<Func<Customers, bool>> pred);
    }
}

