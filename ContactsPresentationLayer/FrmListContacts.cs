using ContactBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsConsoleApp_PresentationLayer
{
    public partial class FrmListContacts : Form
    {
        public FrmListContacts()
        {
            InitializeComponent();
        }

        private  void _RefreshAllContacts()
        {
            DgvAllContacts.DataSource = clsContacts.GetAllContacts();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditContact Frm = new frmAddEditContact((int)DgvAllContacts.CurrentRow.Cells[0].Value);
            Frm.ShowDialog();

            _RefreshAllContacts();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact[" + DgvAllContacts.CurrentRow.Cells[0].Value + "]", "ConfirmDelete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {




                if (clsContacts.DeleteContact((int)DgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully");
                    _RefreshAllContacts();
                }
                else
                    MessageBox.Show("Contact Not Deleted");
            
                    
            }
           
        }

        private void FrmListContacts_Load(object sender, EventArgs e)
        {
            _RefreshAllContacts();
        }
        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact Frm = new frmAddEditContact(-1);
            Frm.ShowDialog();

            _RefreshAllContacts();
        }


    }
}
