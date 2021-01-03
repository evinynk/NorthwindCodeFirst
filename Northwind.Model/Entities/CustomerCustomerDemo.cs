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
    [Table("CustomerCustomerDemo")]
    public class CustomerCustomerDemo
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CustomerDemographics")]
        public string CustomerTypeID { get; set; }
        public CustomerDemographics CustomerDemographics { get; set; }


        [Key]
        [ForeignKey("Customers")]
        [Column(Order = 2)]
        public string CustomerID { get; set; }
        public Customers Customers { get; set; }
    }
}
