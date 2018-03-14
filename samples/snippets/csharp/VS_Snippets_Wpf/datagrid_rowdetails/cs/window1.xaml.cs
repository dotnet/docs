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
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdventureWorksLT2008Entities advenWorksEntities = new AdventureWorksLT2008Entities();
            
            ObjectQuery<Customer> customers = advenWorksEntities.Customers;

            var query =
            from customer in customers
            orderby customer.CompanyName
            select new { 
                customer.LastName, 
                customer.FirstName, 
                customer.CompanyName, 
                customer.Title, 
                customer.EmailAddress, 
                customer.Phone, 
                customer.SalesPerson };

            dataGrid1.ItemsSource = query.ToList();
        }
    }
}
