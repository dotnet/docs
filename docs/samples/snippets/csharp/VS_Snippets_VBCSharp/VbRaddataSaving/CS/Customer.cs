using System;
using System.Collections.Generic;
using System.Text;

namespace CS
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(string customerID, string companyName,
           string contactName, string contactTitle,
           string address, string city, string region,
           string postalCode, string country,
           string phone, string fax)
        {
            customerIDValue = customerID;
        }

        private string customerIDValue;
        public string CustomerID
        {
            get { return customerIDValue; }
            set { customerIDValue = value; }
        }

        private string companyNameValue;
        public string CompanyName
        {
            get { return companyNameValue; }
            set { companyNameValue = value; }
        }

        private string contactNameValue;
        public string ContactName
        {
            get { return contactNameValue; }
            set { contactNameValue = value; }
        }

        private string contactTitleValue;
        public string ContactTitle
        {
            get { return contactTitleValue; }
            set { contactTitleValue = value; }
        }

        private string addressValue;
        public string Address
        {
            get { return addressValue; }
            set { addressValue = value; }
        }

        private string cityValue;
        public string City
        {
            get { return cityValue; }
            set { cityValue = value; }
        }

        private string regionValue;
        public string Region
        {
            get { return regionValue; }
            set { regionValue = value; }
        }

        private string postalCodeValue;
        public string PostalCode
        {
            get { return postalCodeValue; }
            set { postalCodeValue = value; }
        }

        private string countryValue;
        public string Country
        {
            get { return countryValue; }
            set { countryValue = value; }
        }

        private string phoneValue;
        public string Phone
        {
            get { return phoneValue; }
            set { phoneValue = value; }
        }

        private string faxValue;
        public string Fax
        {
            get { return faxValue; }
            set { faxValue = value; }
        }

        private System.ComponentModel.BindingList<Order> ordersCollection = new System.ComponentModel.BindingList<Order>();

        public System.ComponentModel.BindingList<Order> Orders
        {
            get { return ordersCollection; }
            set { ordersCollection = value; }
        }

        public override string ToString()
        {
            return this.CompanyName + " (" + this.CustomerID + ")";
        }


        public string origCustomerID;
        public string origCompanyName;
        public string origContactName;
        public string origContactTitle;
        public string origAddress;
        public string origCity;
        public string origRegion;
        public string origPostalCode;
        public string origCountry;
        public string origPhone;
        public string origFax;
    }
}
