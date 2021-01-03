//using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Entities
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdersID { get; set; }


        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        [ForeignKey("Customers")]
        public string CustomerID { get; set; }
        public Customers Customers { get; set; }

        [ForeignKey("Employees")]
        public int EmployeesID { get; set; }
        public Employees Employees { get; set; }

        [ForeignKey("Shippers")]
        public int ShipVia { get; set; }
        public Shippers Shippers { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
