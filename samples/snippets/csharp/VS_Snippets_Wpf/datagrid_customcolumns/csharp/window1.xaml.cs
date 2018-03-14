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
//<SnippetUsing>
//Additional using statements
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
//</SnippetUsing>


namespace DataGrid_CustomColumns
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    //<SnippetTop>
    public partial class Window1 : NavigationWindow
    {
        //</SnippetTop>
        //<SnippetAll2>
        public Window1()
        {
            InitializeComponent();

            //GetData() creates a collection of Customer data from a database
            ObservableCollection<Customer> custdata = GetData();
            
            //Bind the DataGrid to the customer data
            DG1.DataContext = custdata;
           
        }
        //</SnippetAll2>

        //<SnippetCustomerClass>
        //Defines the customer object
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Uri Email { get; set; }
            public bool IsMember { get; set; }
            public OrderStatus Status { get; set; }

        }
        //</SnippetCustomerClass>

        //<SnippetGetDataTop>
        public ObservableCollection<Customer> GetData()
        {
            //</SnippetGetDataTop>
            AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter ctadapter = new DataGrid_CustomColumns.AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();
            AdventureWorksLT2008DataSet.CustomerDataTable dt = new AdventureWorksLT2008DataSet.CustomerDataTable();
            ctadapter.Fill(dt);
            
            
            OrderStatus[] custstatus= {OrderStatus.New, OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.New, OrderStatus.Processing,
                                      OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.New};
            bool[] IsMember = { true, true, false, true, false, true, true, false, true, false };


            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

            int i;
            for (i = 0; i < 10; i++)
            {
                DataRow r = dt.Rows[i];
                Customer c = new Customer();
                c.FirstName = (string)r["FirstName"];
                c.LastName = (string)r["LastName"];
                c.Email = new Uri("mailto:"+(string)r["EmailAddress"]);
                c.IsMember = IsMember[i];
                c.Status = custstatus[i];
                customers.Add(c);
            }


            return customers;
        //<SnippetGetDataEnd>
        }
        //</SnippetGetDataEnd>

    
       
    //<SnippetAllEnd>   
    }
    //</SnippetAllEnd> 

    //<SnippetEnum>
    public enum OrderStatus { None, New, Processing, Shipped, Received };
    //</SnippetEnum>

    //<SnippetHyperlink3>
    //Converts the mailto uri to a string with just the customer alias
    public class EmailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string email = value.ToString();
                int index = email.IndexOf("@");
                string alias = email.Substring(7, index-7);
                return alias;
            }
            else
            {
                string email = "";
                return email;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Uri email = new Uri((string)value);
            return email;
        }
    }
    //</SnippetHyperlink3>


}
