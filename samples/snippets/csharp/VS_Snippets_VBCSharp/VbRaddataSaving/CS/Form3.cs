using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form3 : Form
    {
        //---------------------------------------------------------------------
        //<Snippet23>
        private void AddNewCustomers(Customer currentCustomer)
        {
            customersTableAdapter.Insert( 
                currentCustomer.CustomerID, 
                currentCustomer.CompanyName, 
                currentCustomer.ContactName, 
                currentCustomer.ContactTitle, 
                currentCustomer.Address, 
                currentCustomer.City, 
                currentCustomer.Region, 
                currentCustomer.PostalCode, 
                currentCustomer.Country, 
                currentCustomer.Phone, 
                currentCustomer.Fax);
        }
        //</Snippet23>


        //---------------------------------------------------------------------
        //<Snippet24>
        private void UpdateCustomer(Customer cust)
        {
            customersTableAdapter.Update(
                cust.CustomerID,
                cust.CompanyName,
                cust.ContactName,
                cust.ContactTitle,
                cust.Address,
                cust.City,
                cust.Region,
                cust.PostalCode,
                cust.Country,
                cust.Phone,
                cust.Fax,
                cust.origCustomerID,
                cust.origCompanyName,
                cust.origContactName,
                cust.origContactTitle,
                cust.origAddress,
                cust.origCity,
                cust.origRegion,
                cust.origPostalCode,
                cust.origCountry,
                cust.origPhone,
                cust.origFax);
        }
        //</Snippet24>


        //---------------------------------------------------------------------
        //<Snippet25>
        private void DeleteCustomer(Customer cust)
        {
            customersTableAdapter.Delete(
                cust.origCustomerID,
                cust.origCompanyName,
                cust.origContactName,
                cust.origContactTitle,
                cust.origAddress,
                cust.origCity,
                cust.origRegion,
                cust.origPostalCode,
                cust.origCountry,
                cust.origPhone,
                cust.origFax);
        }
        //</Snippet25>


        //---------------------------------------------------------------------
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //<Snippet9>
            try
            {
                this.Validate();
                this.customersBindingSource.EndEdit();
                this.customersTableAdapter.Update(this.northwindDataSet.Customers);
                MessageBox.Show("Update successful");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed");
            }
            //</Snippet9>
        }


        //---------------------------------------------------------------------
        public Form3()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------------
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }
    }
}