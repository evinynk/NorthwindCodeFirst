using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Northwind.DAL.Entities;
using Northwind.Model.Entities;

namespace Nortwind.DAL.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("north")
        {

        }
        public DbSet<Products> products { get; set; }

        public DbSet<Categories> categories { get; set; }

        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Shippers> shippers { get; set; }
        public DbSet<CustomerDemographics> customerdemographics { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<CustomerCustomerDemo> customercustomerdemo { get; set; }

        public DbSet<Employees> employees { get; set; }
        public DbSet<Region> region { get; set; }
        public DbSet<Territories> territories { get; set; }

        public DbSet<EmployeeTerritories> employeeterritories { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }





    }
}
