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

namespace ColumnsArtSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //Get the data into a table.
            //AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter ctadapter = new ColumnsArtSample.AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();
            //AdventureWorksLT2008DataSet.CustomerDataTable custtable = new AdventureWorksLT2008DataSet.CustomerDataTable();
            //ctadapter.Fill(custtable);
            
            // This is for the hyperlink column
            //DG1.DataContext = custtable;

            //Data for CheckBox column
            AdventureWorksLT2008DataSet1TableAdapters.SalesOrderHeaderTableAdapter orderadapter = new AdventureWorksLT2008DataSet1TableAdapters.SalesOrderHeaderTableAdapter();
            AdventureWorksLT2008DataSet1.SalesOrderHeaderDataTable ordertable = new AdventureWorksLT2008DataSet1.SalesOrderHeaderDataTable();
            orderadapter.Fill(ordertable);

            DG1.DataContext = ordertable;

    

        }
    }
}
