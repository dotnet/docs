using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void CreateRelation() 
    {
        // Get the DataColumn objects from two DataTable objects 
        // in a DataSet. Code to get the DataSet not shown here.
        DataColumn parentColumn = 
            DataSet1.Tables["Customers"].Columns["CustID"];
        DataColumn childColumn = 
            DataSet1.Tables["Orders"].Columns["CustID"];
        // Create DataRelation.
        DataRelation relCustOrder;
        relCustOrder = new DataRelation("CustomersOrders", 
            parentColumn, childColumn);
        // Add the relation to the DataSet.
        DataSet1.Relations.Add(relCustOrder);
    }
    // </Snippet1>

}
