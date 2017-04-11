using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

public class Sample
{

    static DataSet DataSet1;

    //<Snippet1>
    private void CreateRelation()
    {
        // Code to get the DataSet not shown here.
        // Get the DataColumn objects from two DataTable 
        // objects in a DataSet.
        DataColumn[] parentCols = new DataColumn[] 
            {DataSet1.Tables["Customers"].Columns["CustID"],
            DataSet1.Tables["Customers"].Columns["OrdID"]};
        DataColumn[] childCols= new DataColumn[] 
            {DataSet1.Tables["Orders"].Columns["CustID"],
            DataSet1.Tables["Orders"].Columns["OrdID"]};

        // Create DataRelation.
        DataRelation CustOrderRel = new DataRelation(
            "CustomersOrders", parentCols, childCols);

        // Add the relation to the DataSet.
        DataSet1.Relations.Add(CustOrderRel);
    }
    //</Snippet1>
}
 

