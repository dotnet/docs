//<snippetWpfDataBindingCustom>
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
using System.Collections.Specialized;

namespace NorthwindClient
{
    public partial class CustomerOrdersCustom : Window
    {
        private NorthwindEntities context;
        private DataServiceCollection<Customer> trackedCustomers;
        private const string customerCountry = "Germany";
        private const string svcUri = "http://localhost:12345/Northwind.svc/";

        public CustomerOrdersCustom()
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
                trackedCustomers = new DataServiceCollection<Customer>(customerQuery,
                    TrackingMode.AutoChangeTracking,"Customers",
                    OnPropertyChanged, OnCollectionChanged);

                // Bind the root StackPanel element to the collection;
                // related object binding paths are defined in the XAML.
                this.LayoutRoot.DataContext = trackedCustomers;
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

        //<snippetCustomersOrdersDeleteRelated>
        // Method that is called when the CollectionChanged event is handled.
        private bool OnCollectionChanged(
            EntityCollectionChangedParams entityCollectionChangedinfo)
        {
            if (entityCollectionChangedinfo.Action ==
                NotifyCollectionChangedAction.Remove)
            {
                // Delete the related items when an order is deleted.
                if (entityCollectionChangedinfo.TargetEntity.GetType() == typeof(Order))
                {
                    // Get the context and object from the supplied parameter.
                    DataServiceContext context = entityCollectionChangedinfo.Context;
                    Order deletedOrder = entityCollectionChangedinfo.TargetEntity as Order;

                    if (deletedOrder.Order_Details.Count == 0)
                    {
                        // Load the related OrderDetails.
                        context.LoadProperty(deletedOrder, "Order_Details");
                    }

                    // Delete the order and its related items;
                    foreach (Order_Detail item in deletedOrder.Order_Details)
                    {
                        context.DeleteObject(item);
                    }

                    // Delete the order and then return true since the object is already deleted.
                    context.DeleteObject(deletedOrder);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // Use the default behavior.
                return false;
            }
        }
        //</snippetCustomersOrdersDeleteRelated>

        // Method that is called when the PropertyChanged event is handled.
        private bool OnPropertyChanged(EntityChangedParams entityChangedInfo)
        {
            // Validate a changed order to ensure that changes are not made
            // after the order ships.
            if ((entityChangedInfo.Entity.GetType() == typeof(Order)) &&
                ((Order)(entityChangedInfo.Entity)).ShippedDate < DateTime.Today)
            {
                throw new ApplicationException(string.Format(
                    "The order {0} cannot be changed because it shipped on {1}.",
                    ((Order)(entityChangedInfo.Entity)).OrderID,
                    ((Order)(entityChangedInfo.Entity)).ShippedDate));
            }
            return false;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (customerIDComboBox.SelectedItem != null)
            {
                // Get the Orders binding collection.
                DataServiceCollection<Order> trackedOrders =
                    ((Customer)(customerIDComboBox.SelectedItem)).Orders;

                // Remove the currently selected order.
                trackedOrders.Remove((Order)(ordersDataGrid.SelectedItem));
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
//</snippetWpfDataBindingCustom>