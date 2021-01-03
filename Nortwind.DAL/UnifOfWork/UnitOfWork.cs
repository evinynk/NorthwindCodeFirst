using Nortwind.DAL.Context;
using Nortwind.DAL.Repositories.Abstract;
using Nortwind.DAL.Repositories.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DAL.UnifOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataBaseContext _dataBaseContext;
     
        /// <summary>
        /// **Dependency Injection
        /// DataBaseContext classından instance almak için
        /// bu classın constructor ını kullanıp iki class arasındaki bağımlılığı azalttım.
        /// </summary>
        /// <param name="context"></param>

        public UnitOfWork(DataBaseContext context)
        {
            _dataBaseContext = context;
            EmployeeRepository = new EmployeeRepository(_dataBaseContext);
            SupplierRepository = new SupplierRepository(_dataBaseContext);
            CustomerRepository = new CustomerRepository(_dataBaseContext);
            ProductRepository = new ProductRepository(_dataBaseContext);
        }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public ISupplierRepository SupplierRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IProductRepository ProductRepository { get; set; }

        /// <summary>
        /// 
        /// Repositorydeki metotları UnitOfWorkde SaveChanges() ettim.
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return _dataBaseContext.SaveChanges();
        }

        /// <summary>
        /// IDisposable interface ini implememente ettim
        /// Ram üzerinden hemen silmek istediğimiz verileri ve işlemleri bu metodun içine yazarak 
        /// garbage collector un silinmesini sağlayabiliriz.
        /// </summary>
        public void Dispose()
        {
            _dataBaseContext.Dispose();
        }
    }
}
