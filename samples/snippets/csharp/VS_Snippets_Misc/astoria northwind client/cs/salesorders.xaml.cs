//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using NorthwindClient.Northwind;
//using System.Data.Services.Client;
//using System.Windows.Threading;

 //using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Shapes;using System;
//using System.Linq;
//using System.Windows.Controls;
//using System.Text;
//using System.Collections.Generic;
//<snippetWpfDataBindingCode>
using System;
using System.Linq;
using System.Windows;
using System.Data.Services.Client;
using NorthwindClient.Northwind;

namespace NorthwindClient
{
    /// <summary>
    /// Interaction logic for SalesOrders.xaml
    /// </summary>
    public partial class SalesOrders : Window
    {
        private NorthwindEntities context;
        private string customerId = "ALFKI";
        private Uri svcUri = new Uri("http://localhost:12345/Northwind.svc");

        private void OrdersForm_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Instantiate the DataServiceContext.
                context = new NorthwindEntities(svcUri);

                // Define a query that returns Orders and 
                // Order_Details for a specific customer.
                var ordersQuery = from o in context.Orders.Expand("Order_Details")
                                  where o.Customer.CustomerID == customerId
                                  select o;

                // Create an DataServiceCollection<T> based on 
                // execution of the query for Orders.
                DataServiceCollection<Order> customerOrders =
                    new DataServiceCollection<Order>(ordersQuery);

                //<snippetWpfDataBindingCodeShort>
                // Make the ObservableEntityCollection<T> the binding source for the Grid.
                this.orderItemsGrid.DataContext = customerOrders;
                //</snippetWpfDataBindingCodeShort>
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Save changes made to objects tracked by the context.
                context.SaveChanges();
            }
            catch (DataServiceRequestException ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        public SalesOrders()
        {
            InitializeComponent();
        }
    }
}
//</snippetWpfDataBindingCode>
