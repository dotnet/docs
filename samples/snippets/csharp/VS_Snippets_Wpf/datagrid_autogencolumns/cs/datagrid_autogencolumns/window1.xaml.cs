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

namespace DataGrid_AutoGenColumns
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            AdventureWorksLT2008DataSet.CustomerDataTable dt = GetData();

            DG1.DataContext = dt;
        }

        public AdventureWorksLT2008DataSet.CustomerDataTable GetData()
        {
            AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter custadapter = new DataGrid_AutoGenColumns.AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();
            AdventureWorksLT2008DataSet.CustomerDataTable custdata = new AdventureWorksLT2008DataSet.CustomerDataTable();
            custadapter.Fill(custdata);

            return custdata;
        }
        
        //<Snippet2>
        //Access and update columns during autogeneration
        private void DG1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            //Cancel the column you don't want to generate
            if (headername == "MiddleName")
            {
                e.Cancel = true;
            }

            //update column details when generating
            if (headername == "FirstName")
            {
                e.Column.Header = "First Name";
            }
            else if (headername == "LastName")
            {
                e.Column.Header = "Last Name";
            }
            else if (headername == "EmailAddress")
            {
                e.Column.Header = "Email";
               
            }

        }
        //</Snippet2>
    }
}
