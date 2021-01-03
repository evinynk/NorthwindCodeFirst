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
    public partial class FrmSupplier : Form
    {
        NorthwindServices northwindServices = new NorthwindServices();
        public FrmSupplier()
        {
            InitializeComponent();
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            List<SupplierDto> list = northwindServices.getSupplierList();

            foreach (SupplierDto supplier in list)
            {
                string[] row = new string[] { supplier.Name, supplier.ContactName,
                                                supplier.Title, supplier.Country
                                            };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = supplier;
                lstViewSupplier.Items.Add(lvi);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            SupplierDto supplierDto = new SupplierDto();
            supplierDto.Name = txtCompanyName.Text;
            supplierDto.ContactName = txtContactName.Text;
            supplierDto.Title = txtTitle.Text;
            supplierDto.Country = txtCountry.Text;
           

            if (northwindServices.AddSupplier(supplierDto))
            {
                MessageBox.Show(" Eklendi");
                txtCompanyName.Text = "";
                txtContactName.Text = "";
                txtCountry.Text = "";
                txtTitle.Text = "";
                

                lstViewSupplier.Items.Clear();
                FrmSupplier_Load(new object(), new EventArgs());

            }
            else
            {
                MessageBox.Show("Product Eklenemedi!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SupplierDto supplierDto = new SupplierDto();

            ListViewItem selectedItem = lstViewSupplier.FocusedItem;
            if (selectedItem != null)
            {
                supplierDto = (SupplierDto)selectedItem.Tag;
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {

                        if (northwindServices.RemoveSupplier(supplierDto))
                        {
                            MessageBox.Show("Kayıt başarıyla silindi!");
                            lstViewSupplier.Items.Clear();
                            FrmSupplier_Load(new object(), new EventArgs());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bu kayıt tabloları etkilediği için silinemez!");
                    }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SupplierDto supplierDto = new SupplierDto();

            ListViewItem selectedItem = lstViewSupplier.FocusedItem;

            if (selectedItem != null)
            {
                supplierDto = (SupplierDto)selectedItem.Tag;
                if (MessageBox.Show("Güncellemek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {
                        supplierDto.ContactName = txtContactName.Text;
                        supplierDto.Name = txtCompanyName.Text;
                        supplierDto.Title = txtTitle.Text;
                        supplierDto.Country = txtCountry.Text;
                       

                        bool result = northwindServices.UpdateSupplier(supplierDto);

                        if (result)
                        {
                            MessageBox.Show("Başarıyla Güncellendi");
                            lstViewSupplier.Items.Clear();
                            FrmSupplier_Load(new object(), new EventArgs());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("HATA!");
                    }
            }

        }

        private void lstViewSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierDto supplierDto = (SupplierDto)lstViewSupplier.FocusedItem.Tag;

            txtCompanyName.Text = supplierDto.Name;
            txtContactName.Text = supplierDto.ContactName;
            txtCountry.Text = supplierDto.Country;
            txtTitle.Text = supplierDto.Title;
       
        }
    }
}
