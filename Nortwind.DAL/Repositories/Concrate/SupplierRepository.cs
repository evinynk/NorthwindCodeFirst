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
    public class SupplierRepository : BaseRepository<Suppliers>, ISupplierRepository
    {
        public SupplierRepository(DataBaseContext context) : base(context)
        {

        }

        public List<Suppliers> GetByCountry(string country)
        {

            return _context.suppliers.Where(x => x.Country == country).ToList();
        }

    }
}
