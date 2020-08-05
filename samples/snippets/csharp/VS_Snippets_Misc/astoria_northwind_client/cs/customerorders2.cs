using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Services.Client;
using NorthwindClient.Northwind;

namespace NorthwindClient
{
    public partial class CustomerOrders2 : Form
    {

        private NorthwindEntities context;
        private const string svcUri = "http://localhost:12345/Northwind.svc/";

        public CustomerOrders2()
        {
            InitializeComponent();
        }

        private void CustomerOrders_Load(object sender, EventArgs e)
        {
            // Initialize the context for the data service.
            context = new NorthwindEntities(new Uri(svcUri));

            //<snippetCustomersOrders2Binding>
            // Create a new collection that contains all customers and related orders.
            DataServiceCollection<Customer> trackedCustomers =
                new DataServiceCollection<Customer>(context.Customers.Expand("Orders"));
            //</snippetCustomersOrders2Binding>
            try
            {
                customersBindingSource.DataSource = trackedCustomers;
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show("The query could not be completed:\n" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("The following error occurred:\n" + ex.ToString());
            }
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
