using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTO
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string UrunAdi { get; set; }
        public decimal? Fiyat { get; set; }
        public int? Stok { get; set; }

        //public override string ToString()
        //{
        //    return UrunAdi.ToString();
        //}
    }
}
