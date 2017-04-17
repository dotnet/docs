using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 private void CreateConstraint(DataSet dataSet)
 {
    // Create the ForignKeyConstraint with two DataColumn objects.
    DataColumn parentCol = dataSet.Tables["Customers"].Columns["id"];
    DataColumn childCol = dataSet.Tables["Orders"].Columns["OrderID"];
    ForeignKeyConstraint fkeyConstraint =
       new ForeignKeyConstraint("fkConstraint", parentCol, childCol);

    // Test against existing members using the Equals method.
    foreach(ForeignKeyConstraint testConstraint in 
        dataSet.Tables["Orders"].Constraints)
    {
       if(fkeyConstraint.Equals(testConstraint)){
          Console.WriteLine("Identical ForeignKeyConstraint!");
           // Insert code to delete the duplicate object, 
           // or stop the procedure.
       }
    }
 }
// </Snippet1>

}
