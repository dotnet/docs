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
using System.Data;
using System.Configuration;

namespace DataGrid1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            AdventureWorksLT2008DataSet myData = new AdventureWorksLT2008DataSet();
            //CustomerGrid.ItemsSource = myData.Customer;
            AdventureWorksLT2008DataSet.CustomerDataTable custDataTable = new AdventureWorksLT2008DataSet.CustomerDataTable();

            AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter custTableAdapter = new DataGrid1.AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();

            custTableAdapter.Fill(custDataTable);

            //<Snippet2>
            //Set the DataGrid's DataContext to be a filled DataTable
            CustomerGrid.DataContext = custDataTable;
            //</Snippet2>
            
          
           

            
        }
    }
}
