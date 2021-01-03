using Northwind.DAL.Entities;
using Nortwind.DAL.Context;
using Nortwind.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.Repositories.Concrate
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(DataBaseContext context) : base(context)
        {

        }

        public List<Customers> FilterByCity(Expression<Func<Customers, bool>> pred)
        {
            return _context.Set<Customers>().Where(pred).ToList();
        }

        //public List<Customers> GetByCity(string city)
        //{
        //    return _context.customers.Where(x => x.City == city).ToList();
        //}


        //public List<Customers> GetByLastName(string LastName)
        //{
        //    throw new NotImplementedException();
        //}





        //List<Employees> ICustomerRepository.GetByCity(string city)
        //{
        //    return _context.customers.Where(x => x.City == city).ToList();
        //}





    }
}
