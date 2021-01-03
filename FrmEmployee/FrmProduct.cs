using Northwind.BLL.DTO;
using Northwind.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmEmployee
{
    public partial class btnDelete : Form
    {
        NorthwindServices northwindServices = new NorthwindServices();
        public btnDelete()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
           //NorthwindServicesteki getProductList ile dataları aldım
            List<ProductDto> list = northwindServices.getProductList();

            foreach (ProductDto product in list)
            {
                string[] row = new string[] { product.UrunAdi, product.Fiyat.ToString(), product.Stok.ToString()};
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = product;
                listViewProduct.Items.Add(lvi);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductDto productDto = new ProductDto();
            productDto.UrunAdi = txtProductName.Text;
            productDto.Fiyat = Convert.ToDecimal(nudPrice.Value);
            productDto.Stok = Convert.ToInt32(nudStock.Value);
           

            if (northwindServices.AddProduct(productDto))
            {
                MessageBox.Show("Ürünler Eklendi");
                //txtProductName.Text = "";
                //nudPrice.Value = "";
                //nudStock.Value = "";
                
                listViewProduct.Items.Clear();
                FrmProduct_Load(new object(), new EventArgs());

            }
            else
            {
                MessageBox.Show("Product Eklenemedi!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDto productDto = new ProductDto();

            ListViewItem selectedItem = listViewProduct.FocusedItem;
            if (selectedItem != null)
            {
                productDto = (ProductDto)selectedItem.Tag;
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {

                        if (northwindServices.RemoveProduct(productDto))
                        {
                            MessageBox.Show("Kayıt başarıyla silindi!");
                            listViewProduct.Items.Clear();
                            FrmProduct_Load(new object(), new EventArgs());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bu kayıt tabloları etkilediği için silinemez!");
                    }
            }
        }

        private void listViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDto productDto = listViewProduct.FocusedItem.Tag as ProductDto;

            txtProductName.Text = productDto.UrunAdi;
            nudPrice.Value = Convert.ToDecimal(productDto.Fiyat);
            nudStock.Value = Convert.ToInt32(productDto.Stok);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductDto> productDtolist = new List<ProductDto>();
            List<ProductDto> list = northwindServices.FilterProductByUnitPrice(Convert.ToDecimal(txtGetPrice.Text));      //service.GetByCountry(txtGetCountry.Text);
            listViewProduct.Items.Clear();

            foreach (ProductDto product in list)
            {
                string[] row = new string[] { product.UrunAdi,product.Fiyat.ToString(), product.Stok.ToString()  };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = product;
                listViewProduct.Items.Add(lvi);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductDto productDto = new ProductDto();

            ListViewItem selectedItem = listViewProduct.FocusedItem;

            if (selectedItem != null)
            {
               
                if (MessageBox.Show("Güncellemek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {
                        productDto = (ProductDto)selectedItem.Tag;

                        productDto.UrunAdi = txtProductName.Text;
                        productDto.Fiyat = nudPrice.Value;
                        productDto.Stok = (int)nudStock.Value;
                       


                        bool result = northwindServices.UpdateProduct(productDto);

                        if (result)
                        {
                            MessageBox.Show("Başarıyla Güncellendi");
                            listViewProduct.Items.Clear();
                            FrmProduct_Load(new object(), new EventArgs());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("HATA!");
                    }
            }
        }
    }
}
