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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        Form FrmCustomer = new Form();
        Form FrmSupplier = new Form();
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;

            FrmSupplier.MdiParent = this;
            FrmCustomer.MdiParent = this;
            
            BackGroundColor();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void BackGroundColor()
        {
            foreach (Control control in this.Controls)
            {
                if ((control) is MdiClient)
                {
                    control.BackColor = System.Drawing.Color.CadetBlue;
                }
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomer newMDIChild = new FrmCustomer();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSupplier newMDIChild = new FrmSupplier();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete newMDIChild = new btnDelete();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void empployeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmployees newMDIChild = new FrmEmployees();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}
