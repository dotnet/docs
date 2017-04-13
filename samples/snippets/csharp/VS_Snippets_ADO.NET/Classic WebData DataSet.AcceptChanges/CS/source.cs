using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{

// <Snippet1>
private void AcceptChanges()
{
   DataSet myDataSet;
   myDataSet = new DataSet();

   // Not shown: methods to fill the DataSet with data.
   DataTable t;
   t = myDataSet.Tables["Suppliers"];

   // Add a DataRow to a table.
   DataRow myRow;
   myRow = t.NewRow();
   myRow["CompanyID"] = "NWTRADECO";
   myRow["CompanyName"] = "NortWest Trade Company";

   // Add the row.
   t.Rows.Add( myRow );

   // Calling AcceptChanges on the DataSet causes AcceptChanges to be
   // called on all subordinate objects.
   myDataSet.AcceptChanges();
}
// </Snippet1>

}