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
    public class ProductRepository : BaseRepository<Products>, IProductRepository
    {
        public ProductRepository(DataBaseContext context) : base(context)
        {

        }

        public List<Products> TopUnitPrice(Expression<Func<Products, bool>> pred)
        {
            return null;
           // return _context.Set<Products>().Where(pred).Take < 3 >;
        }
    }
}
