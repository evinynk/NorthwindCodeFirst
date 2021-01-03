//susing Northwind.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Entities
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }


        [Key]
        [Column(Order = 1)]
        [ForeignKey("Orders")]
        public int OrdersID { get; set; }
        public Orders Orders { get; set; }


        [Key]
        [Column(Order = 2)]
        [ForeignKey("Products")]
        public int ProductsID { get; set; }
        public Products Products { get; set; }



    }
}
