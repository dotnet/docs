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
//
using System.Collections.ObjectModel;
using System.Data;

namespace ComboBoxColumnSample2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter ctadapter = new AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();
            AdventureWorksLT2008DataSet.CustomerDataTable dt = new AdventureWorksLT2008DataSet.CustomerDataTable();
            
        
        public Window1()
        {
            InitializeComponent();
            ctadapter.Fill(dt);
            ObservableCollection<Customer> mydata = GetData();

            DG1.DataContext = dt;
            cbc1.ItemsSource = dt;
            CB.DataContext = dt;
            

           

        }


        public class Customer
        {
            //private string _firstname;
            //private string _lastname;
            //private Uri _emailaddress;
            //private bool _isgoldmember;
            //private OrderStatus _orderstatus;
            //private BitmapImage bi = new BitmapImage(new Uri("empphoto.jpg"));

            
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Uri Email { get; set; }
            public bool IsGold { get; set; }
            public OrderStatus Status { get; set; }
            //public BitmapImage EmployeePhoto {
            //    get { return bi; }
                
            //    }

        }

        public ObservableCollection<Customer> GetData()
        {
            


            OrderStatus[] custstatus = {OrderStatus.New, OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.New, OrderStatus.Processing,
                                      OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.New};
            bool[] IsGoldMember = { true, true, false, true, false, true, true, false, true, false };


            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

            int i;
            for (i = 0; i < 10; i++)
            {
                DataRow r = dt.Rows[i];
                Customer c = new Customer();
                c.FirstName = (string)r["FirstName"];
                c.LastName = (string)r["LastName"];
                c.Email = new Uri("mailto:" + (string)r["EmailAddress"]);
                c.IsGold = IsGoldMember[i];
                c.Status = custstatus[i];
                customers.Add(c);
            }

            return customers;

        }




    }
    public enum OrderStatus { None, New, Processing, Shipped, Received };
}
