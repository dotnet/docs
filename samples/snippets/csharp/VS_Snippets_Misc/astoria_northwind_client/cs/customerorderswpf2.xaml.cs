using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//<snippetCustomersOrdersUsingWpf>
using System.Data.Services.Client;
using NorthwindClient.Northwind;
//</snippetCustomersOrdersUsingWpf>

namespace NorthwindClient
{
    public partial class CustomerOrdersWpf2 : Window
    {
        //<snippetCustomersOrdersDefinitionWpf>
        private NorthwindEntities context;
        private CollectionViewSource customersViewSource;
        private DataServiceCollection<Customer> trackedCustomers;
        private const string customerCountry = "Germany";
        private const string svcUri = "http://localhost:12345/Northwind.svc/";
        //</snippetCustomersOrdersDefinitionWpf>

        public CustomerOrdersWpf2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //<snippetCustomersOrdersDataBindingWpf>
            // Initialize the context for the data service.
            context = new NorthwindEntities(new Uri(svcUri));

            // Create a LINQ query that returns customers with related orders.
            var  customerQuery = from cust in context.Customers.Expand("Orders")
                                 where cust.Country == customerCountry
                                 select cust;

            // Create a new collection for binding based on the LINQ query.
            trackedCustomers = new DataServiceCollection<Customer>(customerQuery);

            try
            {
                // Get the customersViewSource resource and set the binding to the collection.
                customersViewSource =
                    ((CollectionViewSource)(this.FindResource("customersViewSource")));
                customersViewSource.Source = trackedCustomers;
                customersViewSource.View.MoveCurrentToFirst();
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show("The query could not be completed:\n" + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("The following error occurred:\n" + ex.ToString());
            }
            //</snippetCustomersOrdersDataBindingWpf>
        }
    }
}
