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

namespace DataGrid_CellSelection
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string clipboard = "Fake Company Name";

        public Window1()
        {
            InitializeComponent();

            AdventureWorksLT2008DataSet.CustomerDataTable dt = GetData();

            DG1.DataContext = dt;
        }

        public AdventureWorksLT2008DataSet.CustomerDataTable GetData()
        {
            AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter custadapter = new AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();
            AdventureWorksLT2008DataSet.CustomerDataTable custdata = new AdventureWorksLT2008DataSet.CustomerDataTable();
            custadapter.Fill(custdata);

            return custdata;
        }



        //<Snippet2>
        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the newly selected rows
            System.Collections.IList selectedrows = e.AddedItems;

            //Get the object associated with each newly selected row
            foreach (DataRowView row in selectedrows)
            {
                bool editable = row.DataView.AllowEdit;
                if (editable == true)
                {
                    //Copy a new value into the CompanyName, where clipboard contains a string
                    AdventureWorksLT2008DataSet.CustomerRow cr = (AdventureWorksLT2008DataSet.CustomerRow)row.Row;
                    cr.BeginEdit();
                    cr.CompanyName = clipboard;
                    cr.EndEdit();
                }
            }
        }
        //</Snippet2>

        //<Snippet3>
        private void DG1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //Get the newly selected cells
            IList<DataGridCellInfo> selectedcells = e.AddedCells;

            //Get the value of each newly selected cell
            foreach (DataGridCellInfo di in selectedcells)
            {
                //Cast the DataGridCellInfo.Item to the source object type
                //In this case the ItemsSource is a DataTable and individual items are DataRows
                DataRowView dvr = (DataRowView)di.Item;

                //Clear values for all newly selected cells
                AdventureWorksLT2008DataSet.CustomerRow cr = (AdventureWorksLT2008DataSet.CustomerRow)dvr.Row;
                cr.BeginEdit();
                cr.SetField(di.Column.DisplayIndex, "");
                cr.EndEdit();

            }
        }
        //</Snippet3>
    }
}
