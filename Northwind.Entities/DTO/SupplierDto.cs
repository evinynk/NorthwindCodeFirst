using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTO
{
    public class SupplierDto
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
    }
}
