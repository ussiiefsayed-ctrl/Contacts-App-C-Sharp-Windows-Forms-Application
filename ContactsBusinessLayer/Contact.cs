using ContactsDataAccessLayer;
using System;
using System.Data;

namespace ContactBusinessLayer
{

    public class clsContacts
    {

        public enum enMode { AddNew = 0 , Update = 1}
        public enMode Mode = enMode.AddNew; 
        
        public int ID{ set; get; }
        public string FirstName{ set; get; }
        public string LastName { set; get; }
        public string Email { set;get; }

        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string ImagePath { set; get; }
        public int CountryID { set; get; }
        public clsContacts()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }
        private clsContacts(int Id ,string FirstName,string LastName,string Email,string Phone,string Address,
            DateTime DateOfBirth,int CountryID,string ImagePath)
        {
            this.ID = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        static public clsContacts Find(int Id)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "",ImagePath = "";
            DateTime BirthOfDate = DateTime.Now;
            int CountryID = 0;

            if(clsContactsDataAccess.GetContactInfoById(Id,ref FirstName, ref LastName,ref Email
                ,ref Phone,ref Address,ref BirthOfDate,ref CountryID,ref ImagePath))
            {
                return new clsContacts(Id, FirstName, LastName, Email, Phone
                    , Address, BirthOfDate, CountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }
        private bool _AddNewContact()
        {
            //Call Data Access Layer
            
            this.ID = clsContactsDataAccess.AddNewContact(this.FirstName,this.LastName,this.Email,
                this.Phone,this.Address,this.DateOfBirth,this.CountryID,this.ImagePath);

            return (ID != -1);
        }
        private bool _UpdateContact()
        {

            //Call Data Access Layer
            
            return clsContactsDataAccess.UpdateContact(this.ID,this.FirstName,this.LastName,this.Email,this.Phone,
                   this.Address,this.DateOfBirth,this.CountryID,this.ImagePath);

        }
        public bool Save()
        {
           
            switch (Mode)
            {
                case enMode.AddNew:

                if(_AddNewContact())
                {
                        Mode = enMode.Update;
                        return true;
                }
                else
                {
                        return false;
                }

                case enMode.Update:

                return _UpdateContact();

            }
            return false;   
        }
        public static bool DeleteContact(int ContactID)
        {
            return clsContactsDataAccess.DeleteContact(ContactID);
        }
        public static bool IsContactExist(int ContactID)
        {
            return clsContactsDataAccess.IsContactExist(ContactID);
        }
        public static DataTable GetAllContacts()
        {

            return clsContactsDataAccess.GetAllContacts();
        }

    }

}
