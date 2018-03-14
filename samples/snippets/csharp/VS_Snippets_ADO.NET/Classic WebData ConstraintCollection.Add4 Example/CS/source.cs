using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddForeignConstraint(
        DataSet dataSet, DataTable table)
    {
        try
        {
            DataColumn[] parentColumns = new DataColumn[2];
            DataColumn[] childColumns = new DataColumn[2];
            // Get the tables from the DataSet.
            DataTable customersTable = dataSet.Tables["Customers"];
            DataTable ordersTable = dataSet.Tables["Orders"];
 
            // Set Columns.
            parentColumns[0]=customersTable.Columns["id"];
            parentColumns[1]=customersTable.Columns["Name"];
            childColumns[0] = ordersTable.Columns["CustomerID"];
            childColumns[1] = ordersTable.Columns["CustomerName"];
 
            // Create ForeignKeyConstraint
            table.Constraints.Add("CustOrdersConstraint",
                parentColumns, childColumns);
        }
        catch(Exception ex)
        {
            // In case the constraint already exists, 
            // catch the collision here and respond.
            Console.WriteLine("Exception of type {0} occurred.", 
                ex.GetType());
        }
    }
    // </Snippet1>

}
