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
using System.Collections.ObjectModel;

namespace DataGrid_FrozenColumns
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 

    //<Snippet2>
    public partial class Window1 : Window
    {
        
        public static RoutedUICommand FreezeColumnCommand = new RoutedUICommand();

        

        public Window1()
        {
            InitializeComponent();
            //GetData connects to the database and returns the data in a table.
            AdventureWorksLT2008DataSet.SalesOrderDetailDataTable dt = GetData();

            DG1.DataContext = dt;
        }
        //</Snippet2>

        public AdventureWorksLT2008DataSet.SalesOrderDetailDataTable GetData()
        {
            AdventureWorksLT2008DataSetTableAdapters.SalesOrderDetailTableAdapter custadapter = new AdventureWorksLT2008DataSetTableAdapters.SalesOrderDetailTableAdapter();
            AdventureWorksLT2008DataSet.SalesOrderDetailDataTable custdata = new AdventureWorksLT2008DataSet.SalesOrderDetailDataTable();
            custadapter.Fill(custdata);

            return custdata;
        }

        //<Snippet3>
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           //Get the column header that started the command and move that column left to freeze it.
           System.Windows.Controls.Primitives.DataGridColumnHeader header = (System.Windows.Controls.Primitives.DataGridColumnHeader)e.OriginalSource;
           if (header.Column.IsFrozen ==true)
           {
               return;
           }
           else
           {
               header.Column.DisplayIndex = DG1.FrozenColumnCount;
               DG1.FrozenColumnCount++;
           }


        }
     
    }
    //</Snippet3>
}
