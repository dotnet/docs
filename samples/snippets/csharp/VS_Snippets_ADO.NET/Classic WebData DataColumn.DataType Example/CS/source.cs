using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;

// <Snippet1>
public DataTable MakeDataTable(){
    
    DataTable myTable;
    DataRow myNewRow; 
    // Create a new DataTable.
    myTable = new DataTable("My Table");

    // Create DataColumn objects of data types.
    DataColumn colString = new DataColumn("StringCol");
    colString.DataType = System.Type.GetType("System.String");
    myTable.Columns.Add(colString); 
 
    DataColumn colInt32 = new DataColumn("Int32Col");
    colInt32.DataType = System.Type.GetType("System.Int32");
    myTable.Columns.Add(colInt32);

    DataColumn colBoolean = new DataColumn("BooleanCol");
    colBoolean.DataType = System.Type.GetType("System.Boolean");
    myTable.Columns.Add(colBoolean);

    DataColumn colTimeSpan = new DataColumn("TimeSpanCol");
    colTimeSpan.DataType = System.Type.GetType("System.TimeSpan");
    myTable.Columns.Add(colTimeSpan);

    DataColumn colDateTime = new DataColumn("DateTimeCol");
    colDateTime.DataType = System.Type.GetType("System.DateTime");
    myTable.Columns.Add(colDateTime);

    DataColumn colDecimal = new DataColumn("DecimalCol");
    colDecimal.DataType = System.Type.GetType("System.Decimal");
    myTable.Columns.Add(colDecimal);

    DataColumn colByteArray = new DataColumn("ByteArrayCol");
    colByteArray.DataType = System.Type.GetType("System.Byte[]");
    myTable.Columns.Add(colByteArray);


    // Populate one row with values.
    myNewRow = myTable.NewRow();

    myNewRow["StringCol"] = "Item Name";
    myNewRow["Int32Col"] = 2147483647;
    myNewRow["BooleanCol"] = true;
    myNewRow["TimeSpanCol"] = new TimeSpan(10,22,10,15,100);
    myNewRow["DateTimeCol"] = System.DateTime.Today;
    myNewRow["DecimalCol"] = 64.0021;
    myNewRow["ByteArrayCol"] = new Byte[] { 1, 5, 120 };
    myTable.Rows.Add(myNewRow);
    return myTable;  
 }
       // </Snippet1>
}