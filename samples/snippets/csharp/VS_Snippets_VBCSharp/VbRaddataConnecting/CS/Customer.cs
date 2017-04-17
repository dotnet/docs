//<Snippet1>
namespace ObjectBindingWalkthrough
{
    /// <summary>
    /// A single customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Creates a new customer
        /// </summary>
        public Customer()
        {
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="companyName"></param>
        /// <param name="contactName"></param>
        /// <param name="contactTitle"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="region"></param>
        /// <param name="postalCode"></param>
        /// <param name="country"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        public Customer(string customerID, string companyName,
           string contactName, string contactTitle,
           string address, string city, string region,
           string postalCode, string country,
           string phone, string fax)
        {
            customerIDValue = customerID;
        }

        private string customerIDValue;
        /// <summary>
        /// The ID that uniquely identifies this customer
        /// </summary>
        public string CustomerID
        {
            get { return customerIDValue; }
            set { customerIDValue = value; }
        }

        private string companyNameValue;
        /// <summary>
        /// The name for this customer
        /// </summary>
        public string CompanyName
        {
            get { return companyNameValue; }
            set { companyNameValue = value; }
        }

        private string contactNameValue;
        /// <summary>
        /// The name for this customer's contact
        /// </summary>
        public string ContactName
        {
            get { return contactNameValue; }
            set { contactNameValue = value; }
        }

        private string contactTitleValue;
        /// <summary>
        /// The title for this contact
        /// </summary>
        public string ContactTitle
        {
            get { return contactTitleValue; }
            set { contactTitleValue = value; }
        }

        private string addressValue;
        /// <summary>
        /// The address for this customer
        /// </summary>
        public string Address
        {
            get { return addressValue; }
            set { addressValue = value; }
        }

        private string cityValue;
        /// <summary>
        /// The city for this customer
        /// </summary>
        public string City
        {
            get { return cityValue; }
            set { cityValue = value; }
        }

        private string regionValue;
        /// <summary>
        /// The region for this customer
        /// </summary>
        public string Region
        {
            get { return regionValue; }
            set { regionValue = value; }
        }

        private string postalCodeValue;
        /// <summary>
        /// The postal code for this customer
        /// </summary>
        public string PostalCode
        {
            get { return postalCodeValue; }
            set { postalCodeValue = value; }
        }

        private string countryValue;
        /// <summary>
        /// The country for this customer
        /// </summary>
        public string Country
        {
            get { return countryValue; }
            set { countryValue = value; }
        }

        private string phoneValue;
        /// <summary>
        /// The phone number for this customer
        /// </summary>
        public string Phone
        {
            get { return phoneValue; }
            set { phoneValue = value; }
        }

        private string faxValue;
        /// <summary>
        /// The fax number for this customer
        /// </summary>
        public string Fax
        {
            get { return faxValue; }
            set { faxValue = value; }
        }

        private System.ComponentModel.BindingList<Order> ordersCollection = 
            new System.ComponentModel.BindingList<Order>();

        public System.ComponentModel.BindingList<Order> Orders
        {
            get { return ordersCollection; }
            set { ordersCollection = value; }
        }

        public override string ToString()
        {
            return this.CompanyName + " (" + this.CustomerID + ")";
        }
    }
}
//</Snippet1>
