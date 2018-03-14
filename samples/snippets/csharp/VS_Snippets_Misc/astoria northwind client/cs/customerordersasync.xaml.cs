//<snippetWpfDataBindingAsync>
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
using NorthwindClient.Northwind;
using System.Data.Services.Client;
using System.Windows.Threading;

namespace NorthwindClient
{
    /// <summary>
    /// Interaction logic for OrderItems.xaml
    /// </summary>
    public partial class CustomerOrdersAsync : Window
    {
        private NorthwindEntities context;
        private DataServiceCollection<Customer> customerBinding;
        private const string customerCountry = "Germany";
     
        // Change this URI to the service URI for your implementation.
        private const string svcUri = "http://localhost:12345/Northwind.svc/";

        // Delegate that returns void for the query result callback.
        private delegate void OperationResultCallback();

        public CustomerOrdersAsync()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize the context.
            context = new NorthwindEntities(new Uri(svcUri));

            // Define a query that returns customers and orders for a specific country.
            DataServiceQuery<Customer> query = context.Customers.Expand("Orders")
                .AddQueryOption("filter", "Country eq '" + customerCountry + "'");

            try
            {
                // Begin asynchronously saving changes using the 
                // specified handler and query object state.
                query.BeginExecute(OnQueryCompleted, query);
            }
            catch (DataServiceClientException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OnQueryCompleted(IAsyncResult result)
        {
            // Get the original query object from the state cache.
            DataServiceQuery<Customer> query =
                   (DataServiceQuery<Customer>)result.AsyncState;


            // Use the Dispatcher to ensure that the query returns in the UI thread.
            this.Dispatcher.BeginInvoke(new OperationResultCallback(delegate
            {
                try
                {
                    // Instantiate the binding collection using the 
                    // results of the query execution.
                    customerBinding = new DataServiceCollection<Customer>(
                        query.EndExecute(result));
                    
                    // Bind the collection to the root element of the UI.
                    this.LayoutRoot.DataContext = customerBinding;
                }
                catch (DataServiceRequestException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }),null);
        }
        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Start the asynchronous call to save changes.
                context.BeginSaveChanges(OnSaveChangesCompleted, null);
            }
            catch (DataServiceClientException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void OnSaveChangesCompleted(IAsyncResult result)
        {
            // Use the Dispatcher to ensure that the operation returns in the UI thread.
            this.Dispatcher.BeginInvoke(new OperationResultCallback(delegate
            {
                try
                {
                    // Complete the save changes operation.
                    context.EndSaveChanges(result);
                }
                catch (DataServiceRequestException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }), null);
        }
    }
}
//</snippetWpfDataBindingAsync>