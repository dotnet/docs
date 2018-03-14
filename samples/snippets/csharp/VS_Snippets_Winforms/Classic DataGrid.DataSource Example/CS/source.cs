using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{

static void Main(){}

 protected DataGrid dataGrid1;
// <Snippet1>
private void BindToDataView(DataGrid myGrid){
    // Create a DataView using the DataTable.
    DataTable myTable = new DataTable("Suppliers");
    // Insert code to create and populate columns.
    DataView myDataView = new DataView(myTable);
    myGrid.DataSource = myDataView;
 }
 private void BindToDataSet(DataGrid myGrid){
    // Create a DataSet.
    DataSet myDataSet = new DataSet("myDataSet");
    // Insert code to populate DataSet with several tables.
    myGrid.DataSource = myDataSet;
    // Use the DataMember property to specify the DataTable.
    myGrid.DataMember = "Suppliers";
 }
 private DataView GetDataViewFromDataSource(){
    // Create a DataTable variable, and set it to the DataSource.
    DataView myDataView;
    myDataView = (DataView) dataGrid1.DataSource;
    return myDataView;
 }
 private DataSet GetDataSetFromDataSource(){
    // Create a DataSet variable, and set it to the DataSource.
    DataSet myDataSet;
    myDataSet = (DataSet) dataGrid1.DataSource;
    return myDataSet;
 }

// </Snippet1>
}
