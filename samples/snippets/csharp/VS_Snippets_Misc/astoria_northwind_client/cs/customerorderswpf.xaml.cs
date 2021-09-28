//<snippetWpfDataBinding>
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
    public partial class CustomerOrdersWpf : Window
    {
        private NorthwindEntities context;
        private DataServiceCollection<Customer> trackedCustomers;
        private const string customerCountry = "Germany";
        private const string svcUri = "http://localhost:12345/Northwind.svc/";

        public CustomerOrdersWpf()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize the context for the data service.
                context = new NorthwindEntities(new Uri(svcUri));

                //<snippetMasterDetailBinding>
                // Create a LINQ query that returns customers with related orders.
                var customerQuery = from cust in context.Customers.Expand("Orders")
                                    where cust.Country == customerCountry
                                    select cust;

                // Create a new collection for binding based on the LINQ query.
                trackedCustomers = new DataServiceCollection<Customer>(customerQuery);

                // Bind the root StackPanel element to the collection;
                // related object binding paths are defined in the XAML.
                LayoutRoot.DataContext = trackedCustomers;
                //</snippetMasterDetailBinding>
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
        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            // Save changes to the data service.
            context.SaveChanges();
        }
    }
}
//</snippetWpfDataBinding>