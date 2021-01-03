
using Northwind.DAL.Entities;
using Nortwind.DAL.Context;
using Nortwind.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.Repositories.Concrate
{
    public class EmployeeRepository : BaseRepository<Employees>, IEmployeeRepository
    {
       // DataBaseContext ctx = new DataBaseContext();

        public EmployeeRepository(DataBaseContext context):base(context)
        {
            
        }
      

        public List<Employees> GetByLastName(string LastName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employees> GetTopEmployees(int count)
        {
            throw new NotImplementedException();
        }

        //List<Employees> IBaseRepository<Employees>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

       
    }
}
