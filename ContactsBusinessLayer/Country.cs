using ContactsDataAccessLayer;
using System;
using System.Data;

namespace ContactBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; } 
        public string PhoneCode { get; set; }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";

            Mode = enMode.AddNew;

        }

        private clsCountry(int countryID, string countryName,string Code,string PhoneCode)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.Update;
        }

        private bool _AddNewCountry()
        {
            //Call Data Access Layer

            this.CountryID = clsCountryData.AddNewCountry(this.CountryName,this.Code,this.PhoneCode);

            return (this.CountryID != -1);
        }

        private bool _UpdateCountry()
        {
            //Call DataAccess Layer
            return clsCountryData.UpdateCountry(this.CountryID, this.CountryName,this.Code,this.PhoneCode);
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";
            string Code = "";
            string PhoneCode = "";

            if (clsCountryData.GetCountryInfoByID(CountryID, ref CountryName,ref Code,ref PhoneCode))
            {
                return new clsCountry(CountryID, CountryName,Code,PhoneCode);
            }
            else
            {
                return null;
            }

        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;
            string Code = "";
            string PhoneCode = "";

            if (clsCountryData.GetCountryInfoByName(CountryName, ref CountryID,ref Code,ref PhoneCode))
            {
                return new clsCountry(CountryID, CountryName,Code,PhoneCode);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCountry();

            }




            return false;
        }


        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public static bool DeleteCountry(int CountryID)
        {
            return clsCountryData.DeleteCountry(CountryID);
        }

        public static bool IsCountryExist(int CountryID)
        {
            return clsCountryData.IsCountryExist(CountryID);
        }

        public static bool IsCountryExist(string CountryName)
        {
            return clsCountryData.IsCountryExist(CountryName);
        }


    }


}
