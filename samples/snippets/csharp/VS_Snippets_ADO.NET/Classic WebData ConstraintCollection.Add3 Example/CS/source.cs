using System;
using System.Data;

public class Form1
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddForeignConstraint(DataSet dataSet)
    {
        try
        {
            DataColumn parentColumn = 
                dataSet.Tables["Suppliers"].Columns["SupplierID"];
            DataColumn childColumn = 
                dataSet.Tables["Products"].Columns["SupplierID"];
            dataSet.Tables["Products"].Constraints.Add
                ("ProductsSuppliers", parentColumn, childColumn);
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
