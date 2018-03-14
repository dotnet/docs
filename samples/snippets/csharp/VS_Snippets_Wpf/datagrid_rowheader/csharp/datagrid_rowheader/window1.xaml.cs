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

using System.ComponentModel;

namespace DataGrid_RowHeader
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
            AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter custadapter = new AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();
            AdventureWorksLT2008DataSet.CustomerDataTable custdata = new AdventureWorksLT2008DataSet.CustomerDataTable();
            custadapter.Fill(custdata);

            return custdata;
        }

       

        
    }

    //<Snippet2>
    public class ConvertItemToIndex : IValueConverter
    {
        #region IValueConverter Members
        //Convert the Item to an Index
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                //Get the DataRowView that is being passed to the Converter
                System.Data.DataRowView drv = (System.Data.DataRowView)value;
                //Get the CollectionView from the DataGrid that is using the converter
                DataGrid dg = (DataGrid)Application.Current.MainWindow.FindName("DG1");
                CollectionView cv = (CollectionView)dg.Items;
                //Get the index of the DataRowView from the CollectionView
                int rowindex = cv.IndexOf(drv)+1;

                return rowindex.ToString();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
         //One way binding, so ConvertBack is not implemented
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    //</Snippet2>


    

}
