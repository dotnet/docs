using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//<snippetCustomersOrdersUsing>
using System.Data.Services.Client;
using NorthwindClient.Northwind;
//</snippetCustomersOrdersUsing>

namespace NorthwindClient
{
    public partial class CustomerOrders : Form
    {

        //<snippetCustomersOrdersDefinition>
        private NorthwindEntities context;
        private DataServiceCollection<Customer> trackedCustomers;
        private const string customerCountry = "Germany";
        private const string svcUri = "http://localhost:12345/Northwind.svc/";
        //</snippetCustomersOrdersDefinition>

        public CustomerOrders()
        {
            InitializeComponent();
        }

        private void CustomerOrders_Load(object sender, EventArgs e)
        {
            //<snippetCustomersOrdersDataBinding>
            // Initialize the context for the data service.
            context = new NorthwindEntities(new Uri(svcUri));
            try
            {
                // Create a LINQ query that returns customers with related orders.
                var customerQuery = from cust in context.Customers.Expand("Orders")
                                    where cust.Country == customerCountry
                                    select cust;

                //<snippetCustomersOrdersDataBindingSpecific>
                // Create a new collection for binding based on the LINQ query.
                trackedCustomers = new DataServiceCollection<Customer>(customerQuery);

                //Bind the Customers combobox to the collection.
                customersComboBox.DisplayMember = "CustomerID";
                customersComboBox.DataSource = trackedCustomers;
                //</snippetCustomersOrdersDataBindingSpecific>
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show("The query could not be completed:\n" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("The following error occurred:\n" + ex.ToString());
            }
            //</snippetCustomersOrdersDataBinding>
        }

        private void customersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected customer.
            Customer selectedCustomer = (Customer)this.customersComboBox.SelectedItem;

            // Bind the grid to the related Orders collection.
            ordersDataGridView.DataSource = selectedCustomer.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
