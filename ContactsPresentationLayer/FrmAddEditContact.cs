using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;                                               
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactBusinessLayer;

namespace ContactsConsoleApp_PresentationLayer
{
    public partial class frmAddEditContact : Form
    {

        public enum enMode {AddNew = 0,Update = 1 };
        private enMode _Mode;

        int _ContactID;
        clsContacts _Contact;


        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (_ContactID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

        }

        private void _FillCountriesToComboInBox()
        {
            DataTable DtCountries = clsCountry.GetAllCountries();

            foreach(DataRow Row in DtCountries.Rows)
            {
                CbCountry.Items.Add(Row["CountryName"]);

            }

        }

        private void _LoadData()
        {
            _FillCountriesToComboInBox();
            CbCountry.SelectedIndex = 0;

            if(_Mode ==  enMode.AddNew)
            {
                lblMode.Text = "Add New Contact";
                _Contact = new clsContacts();
                return;
            }

            _Contact = clsContacts.Find(_ContactID);
            
            if (_Contact == null)
            {
                MessageBox.Show("this form will be closed because No Contact with ID = " + _ContactID);
                this.Close();

                return;
            }
            

            lblMode.Text = "Edit Contact ID " + _ContactID;
            lblContactID.Text = _ContactID.ToString();
            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            txtAddress.Text = _Contact.Address;
            dtpDateOfBirth.Value = _Contact.DateOfBirth;

            if (_Contact.ImagePath != null)
            {
                pictureBox1.ImageLocation = _Contact.ImagePath;
            }

            llRemoveImage.Visible = (_Contact.ImagePath != "");

            //select the country in the comboBox
            CbCountry.SelectedIndex = CbCountry.FindString(clsCountry.Find(_Contact.CountryID).CountryName);

           
        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(CbCountry.Text).CountryID;

            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.DateOfBirth = dtpDateOfBirth.Value;
            _Contact.CountryID = CountryID;

            if (pictureBox1.ImageLocation != null)
            {
                _Contact.ImagePath = pictureBox1.ImageLocation;
            }
            else
                _Contact.ImagePath = "";

            if (_Contact.Save())
                MessageBox.Show("Data Saved Successfully");
            else
                MessageBox.Show("Error: Data Is Not Saved.");

            _Mode = enMode.Update;
            lblMode.Text = "Edit Contact ID = " + _ContactID;
            lblContactID.Text = _Contact.ID.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llSetPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                string selectedFilePath = openFileDialog1.FileName;
                pictureBox1.Load(selectedFilePath);
                
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            llRemoveImage.Visible = false;

        }
    }
}
