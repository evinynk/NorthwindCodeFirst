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
    [Table("EmployeeTerritories")]
    public class EmployeeTerritories
    {

        [Key]
        [ForeignKey("Employees")]
        [Column(Order = 1)]
        public int EmployeeID { get; set; }
        public Employees Employees { get; set; }


        [Key]
        [ForeignKey("Territories")]
        [Column(Order = 2)]
        public string TerritoryID { get; set; }
        public Territories Territories { get; set; }


    }
}
