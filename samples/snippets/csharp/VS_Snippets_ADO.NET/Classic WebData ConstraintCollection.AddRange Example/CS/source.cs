using System;
using System.Data;

public class Sample
{

    // <Snippet1>
    public static void ConstraintAddRange(DataSet dataSet)
    {
        try
        {
            // Reference the tables from the DataSet.
            DataTable customersTable = dataSet.Tables["Customers"];
            DataTable ordersTable = dataSet.Tables["Orders"];

            // Create unique and foreign key constraints.
            UniqueConstraint uniqueConstraint = new 
                UniqueConstraint(customersTable.Columns["CustomerID"]);
            ForeignKeyConstraint fkConstraint = new 
                ForeignKeyConstraint("CustOrdersConstraint",
                customersTable.Columns["CustomerID"],
                ordersTable.Columns["CustomerID"]);

            // Add the constraints.
            customersTable.Constraints.AddRange(new Constraint[] 
                {uniqueConstraint, fkConstraint});
        }
        catch(Exception ex)
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                ex.GetType());
        }
    }
    // </Snippet1>

}
