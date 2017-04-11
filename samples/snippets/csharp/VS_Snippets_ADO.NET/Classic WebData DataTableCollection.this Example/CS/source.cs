using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


public class Form1: Form
{
protected DataSet DataSet1;
protected DataGrid DataGrid1;

// <Snippet1>
 private void GetDataTableByIndex()
 {
    // presuming a DataGrid is displaying more than one table, get its DataSet.
    DataSet thisDataSet = (DataSet)DataGrid1.DataSource;
    // Get the DataTableCollection.
    DataTableCollection tablesCollection = thisDataSet.Tables;
    // Iterate through the collection to get each table name.
    for (int i = 0; i < tablesCollection.Count; i++)
       Console.WriteLine(tablesCollection[i].TableName);
 }
// </Snippet1>
}
