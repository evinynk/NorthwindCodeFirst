using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Entities
{
    [Table("Territories")]
    public class Territories
    {
        [Key]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }

        [ForeignKey("Region")]
        public int RegionID { get; set; }
        public Region Region { get; set; }
        public ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }

    }
}
