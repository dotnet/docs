using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Common;

namespace NorthwindClient
{
    //<snippetCustomerAddressDefinition>
    [DataServiceKey("CustomerID")]
    public partial class CustomerAddress
    {
        private string _customerID;
        private string _address;
        private string _city;
        private string _region;
        private string _postalCode;
        private string _country;

        public string CustomerID
        {
            get
            {
                return this._customerID;
            }

            set
            {
                this._customerID = value;
            }
        }
        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }
        public string Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return this._postalCode;
            }
            set
            {
                this._postalCode = value;
            }
        }
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }
    }

    public class CustomerAddressNonEntity
    {
        private string _companyName;
        private string _address;
        private string _city;
        private string _region;
        private string _postalCode;
        private string _country;

        public string CompanyName
        {
            get
            {
                return this._companyName;
            }
            set
            {
                this._companyName = value;
            }
        }
        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }
        public string Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return this._postalCode;
            }
            set
            {
                this._postalCode = value;
            }
        }
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }
    }
    //</snippetCustomerAddressDefinition>

    public partial class CustomerAddress
    {
        // Default constructor for initializers.
        public CustomerAddress()
        {
        }

        // Public constructors with propeties.
        public CustomerAddress(
        string customerID,
        string address,
        string city,
        string region,
        string postalCode,
        string country)
        {
         _customerID = customerID;
         _address = address;
         _city = city;
         _region = region;
         _postalCode = postalCode;
         _country = country;
        }
    }
}
