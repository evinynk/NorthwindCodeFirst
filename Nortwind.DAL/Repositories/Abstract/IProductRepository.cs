using Northwind.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.Repositories.Abstract
{
    public interface IProductRepository : IBaseRepository<Products>
    {
        List<Products> TopUnitPrice(Expression<Func<Products, bool>> pred);
    }
}
