using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;


namespace SDKSample
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>

  public partial class Window1 : Window
  {
      public Window1()
      {
          this.InitializeComponent();
      }
      
      private string appPath;
      private string AppDataPath
      {
          get
          {
              if (string.IsNullOrEmpty(appPath))
              {
                  appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
              }
              return appPath;
          }
      }

    //<Snippet1>
    DataSet myDataSet;

    private void OnInit(object sender, EventArgs e)
    {
      string mdbFile = Path.Combine(AppDataPath, "BookData.mdb");
      string connString = string.Format(
          "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}", mdbFile);
      OleDbConnection conn = new OleDbConnection(connString);
      OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM BookTable;", conn);

      myDataSet = new DataSet();
      adapter.Fill(myDataSet, "BookTable");

      // myListBox is a ListBox control.
      // Set the DataContext of the ListBox to myDataSet
      myListBox.DataContext = myDataSet;
    }
    //</Snippet1>

    private void OnClick(object sender, RoutedEventArgs e)
    {
      DataTable myDataTable = myDataSet.Tables["BookTable"];
      DataRow row = myDataTable.NewRow();

      row["Title"] = "Microsoft C# Language Specifications";
      row["ISBN"] = "0-7356-1448-2";
      row["NumPages"] = 431;
      myDataTable.Rows.Add(row);
    }
  }
}
