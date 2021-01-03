using Northwind.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model.Entities
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
       // public byte[] Picture { get; set; }

        public ICollection<Products> Products { get; set; }

        public Categories()
        {
            Products = new HashSet<Products>();

        }

        public override string ToString()
        {
            return CategoryName;
        }

    }
}
