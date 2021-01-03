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
    public partial class FrmCustomer : Form
    {
        NorthwindServices northwindServices = new NorthwindServices();
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            List<CustomerDto> list = northwindServices.getCustomerList();

            foreach (CustomerDto customer in list)
            {
                string[] row = new string[] { customer.CustomerId, customer.CompanyName, customer.ContactName, customer.City };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = customer;
                lstViewCustomer.Items.Add(lvi);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerDto customerDto = new CustomerDto();
            customerDto.CustomerId = txtId.Text;
            customerDto.CompanyName = txtCompanyName.Text;
            customerDto.ContactName = txtContactName.Text;
            customerDto.City = txtCity.Text;


            if (northwindServices.AddCustomer(customerDto))
            {
                MessageBox.Show(" Eklendi!");
                txtId.Text = "";
                txtCompanyName.Text = "";
                txtContactName.Text = "";
                txtCity.Text = "";
                lstViewCustomer.Items.Clear();
                FrmCustomer_Load(new object(), new EventArgs());

            }
            else
            {
                MessageBox.Show("Customer Eklenemedi!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerDto customerDto = new CustomerDto();

            ListViewItem selectedItem = lstViewCustomer.FocusedItem;
            if (selectedItem != null)
            {
                customerDto = (CustomerDto)selectedItem.Tag;
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {

                    if (northwindServices.RemoveCustomer(customerDto))
                    {
                        MessageBox.Show("Kayıt başarıyla silindi!");
                        lstViewCustomer.Items.Clear();
                    FrmCustomer_Load(new object(), new EventArgs());
                    }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bu kayıt tabloları etkilediği için silinemez!");
                    }
                //else
                //    {
                //        MessageBox.Show("Kayıt Silinmedi!");
                //    }


                }

            }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CustomerDto customerDto = new CustomerDto();

            ListViewItem selectedItem = lstViewCustomer.FocusedItem;

            if (selectedItem != null)
            {
                customerDto = (CustomerDto)selectedItem.Tag;
                if (MessageBox.Show("Güncellemek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {
                        customerDto.CustomerId = txtId.Text;
                        customerDto.CompanyName = txtCompanyName.Text;
                        customerDto.ContactName = txtContactName.Text;
                        customerDto.City = txtCity.Text;


                        bool result = northwindServices.UpdateCustomer(customerDto);

                        if (result)
                        {
                            MessageBox.Show("Başarıyla Güncellendi");
                            lstViewCustomer.Items.Clear();
                            FrmCustomer_Load(new object(), new EventArgs());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("HATA!");
                    }
            }

            }

        private void lstViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerDto customer = lstViewCustomer.FocusedItem.Tag as CustomerDto;

            txtId.Text = customer.CustomerId;
            txtCompanyName.Text = customer.CompanyName;
            txtContactName.Text = customer.ContactName;
            txtCity.Text = customer.City;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<CustomerDto> customerDtolist = new List<CustomerDto>();
            List<CustomerDto> list = northwindServices.FilterCustomerByCity(txtGetCity.Text);      //service.GetByCountry(txtGetCountry.Text);
            lstViewCustomer.Items.Clear();
           
            foreach (CustomerDto customer in list)
            {
                string[] row = new string[] { customer.CustomerId,customer.CompanyName,customer.ContactName,customer.City };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = customer;
                lstViewCustomer.Items.Add(lvi);
            }
        }

        
    }
}
