
using Northwind.Entities;
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
    public partial class FrmEmployees : Form
    {
        NorthwindServices northwindServices = new NorthwindServices();
        public FrmEmployees()
        {
            InitializeComponent();
        }
        //CategoryBusiness businessCategory;
        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeDto> list = northwindServices.getEmployeeList();

            foreach (EmployeeDto employee in list)
            {
                string[] row = new string[] { employee.FirstName, employee.LastName, employee.Title };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = employee;
                listViewEmployee.Items.Add(lvi);
            }

        }


        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {
            EmployeeDto employeeDto = new EmployeeDto();
            employeeDto.FirstName = txtFirstName.Text;
            employeeDto.LastName = txtLastName.Text;
            employeeDto.Title = txtTitle.Text;


            if (northwindServices.AddEmployee(employeeDto))
            {
                MessageBox.Show("Eklendi");
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtTitle.Text = "";
                listViewEmployee.Items.Clear();

                Form1_Load(new object(), new EventArgs());

            }
            else
            {
                MessageBox.Show("Employee Eklenemedi!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeDto employeeDto = new EmployeeDto();

            ListViewItem selectedItem = listViewEmployee.FocusedItem;

            if (selectedItem != null)
            {
                employeeDto = (EmployeeDto)selectedItem.Tag;
                if (MessageBox.Show("Güncellemek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {
                        employeeDto.FirstName = txtFirstName.Text;
                        employeeDto.LastName = txtLastName.Text;
                        employeeDto.Title = txtTitle.Text;
                        

                        bool result = northwindServices.UpdateEmployee(employeeDto);

                        if (result)
                        {
                            MessageBox.Show("Başarıyla Güncellendi");
                            listViewEmployee.Items.Clear();
                            Form1_Load(new object(), new EventArgs());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("HATA!");
                    }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            EmployeeDto employeeDto = new EmployeeDto();

            ListViewItem selectedItem = listViewEmployee.FocusedItem;
            if (selectedItem != null)
            {
                employeeDto = (EmployeeDto)selectedItem.Tag;
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    try
                    {

                        if (northwindServices.RemoveEmployee(employeeDto))
                        {
                            MessageBox.Show("Kayıt başarıyla silindi!");
                            listViewEmployee.Items.Clear();
                            Form1_Load(new object(), new EventArgs());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bu kayıt tabloları etkilediği için silinemez!");
                    }
            }
        }

        private void listViewEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeDto employeeDto = (EmployeeDto)listViewEmployee.FocusedItem.Tag;

            txtFirstName.Text = employeeDto.FirstName;
            txtLastName.Text = employeeDto.LastName;
            txtTitle.Text = employeeDto.Title;
           
        }
    }
}
        
 


      