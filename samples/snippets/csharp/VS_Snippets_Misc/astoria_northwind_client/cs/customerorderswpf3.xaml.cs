//<snippetBindPagedData>
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
using System.Data.Services.Client;
using NorthwindClient.Northwind;

namespace NorthwindClient
{
    public partial class CustomerOrdersWpf3 : Window
    {
        private NorthwindEntities context;
        private DataServiceCollection<Customer> trackedCustomers;
        private const string customerCountry = "Germany";
        private const string svcUri = "http://localhost:12345/Northwind.svc/";

        public CustomerOrdersWpf3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize the context for the data service.
                context = new NorthwindEntities(new Uri(svcUri));

                // Create a LINQ query that returns customers with related orders.
                var customerQuery = from cust in context.Customers
                                    where cust.Country == customerCountry
                                    select cust;

                //<snippetBindPagedDataSpecific>
                // Create a new collection for binding based on the LINQ query.
                trackedCustomers = new DataServiceCollection<Customer>(customerQuery);

                // Load all pages of the response at once.
                while (trackedCustomers.Continuation != null)
                {
                    trackedCustomers.Load(
                        context.Execute<Customer>(trackedCustomers.Continuation.NextLinkUri));
                }
                //</snippetBindPagedDataSpecific>

                // Bind the root StackPanel element to the collection;
                // related object binding paths are defined in the XAML.
                LayoutRoot.DataContext = trackedCustomers;
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

        private void customerIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selectedCustomer =
                this.customerIDComboBox.SelectedItem as Customer;

            try
            {
                // Load the first page of related orders for the selected customer.
                context.LoadProperty(selectedCustomer, "Orders");

                // Load all remaining pages.
                while (selectedCustomer.Orders.Continuation != null)
                {
                    selectedCustomer.Orders.Load(
                        context.Execute<Order>(selectedCustomer.Orders.Continuation.NextLinkUri));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Save changes to the data service.
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
//</snippetBindPagedData>