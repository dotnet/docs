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



namespace DataGrid_ColumnsManipulation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //<SnippetAdd1>
        public Window1()
        {
            //</SnippetAdd1>
            InitializeComponent();

            AdventureWorksLT2008DataSet.CustomerDataTable dt = GetData();

            DG1.DataContext = dt;

            DG2.DataContext = dt;

            //<SnippetAdd2>
            //Create a new column to add to the DataGrid
            DataGridTextColumn textcol = new DataGridTextColumn();
            //Create a Binding object to define the path to the DataGrid.ItemsSource property
            //The column inherits its DataContext from the DataGrid, so you don't set the source
            Binding b = new Binding("LastName");
            //Set the properties on the new column
            textcol.Binding = b;
            textcol.Header = "Last Name";
            //Add the column to the DataGrid
            DG2.Columns.Add(textcol);
            
        }
        //</SnippetAdd2>

        public AdventureWorksLT2008DataSet.CustomerDataTable GetData()
        {
            AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter custadapter = new AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter();
            AdventureWorksLT2008DataSet.CustomerDataTable custdata = new AdventureWorksLT2008DataSet.CustomerDataTable();
            custadapter.Fill(custdata);

            return custdata;
        }

        //<SnippetVisible2>
        private void DG1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Set properties on the columns during auto-generation
            switch (e.Column.Header.ToString())
            {
                case "LastName":
                    e.Column.CanUserSort = false;
                    e.Column.Visibility = Visibility.Visible;
                    break;
                case "FirstName":
                    e.Column.Visibility = Visibility.Visible;
                    break;
                case "CompanyName":
                    e.Column.Visibility = Visibility.Visible;
                    break;
                case "EmailAddress":
                    e.Column.Visibility = Visibility.Visible;
                    break;
                default:
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Make each column in the collection visible
            foreach (DataGridColumn col in DG1.Columns)
            {
                col.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //Get the columns collection
            ObservableCollection<DataGridColumn> columns = DG1.Columns;

            //set the visibility for each column so only 4 columns are visible
            foreach (DataGridColumn col in columns)
            {
                switch (col.Header.ToString())
                {
                    case "LastName":
                        col.Visibility = Visibility.Visible;
                        break;
                    case "FirstName":
                        col.Visibility = Visibility.Visible;
                        break;
                    case "CompanyName":
                        col.Visibility = Visibility.Visible;
                        break;
                    case "EmailAddress":
                        col.Visibility = Visibility.Visible;
                        break;
                    default:
                        col.Visibility = Visibility.Collapsed;
                        break;
                }
            }

        }
        //</SnippetVisible2>

        //<SnippetDelete2>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Delete the first column whether visible or not
            DG1.Columns.RemoveAt(0);

        }
        //</SnippetDelete2>

        
    }
}
