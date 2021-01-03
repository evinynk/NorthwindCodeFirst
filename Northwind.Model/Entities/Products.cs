//using Northwind.Entities;
using Northwind.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Entities
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }


        [ForeignKey("Categories")]
        public int? CategoryID { get; set; }

        [ForeignKey("Suppliers")]
        public int? ShipperID { get; set; }

        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool? Discontinued { get; set; }

        public Categories Categories { get; set; }

        public Suppliers Suppliers { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public override string ToString()
        {
            return ProductName;
        }
    }
}
