using System;
using System.Data;

public class Sample
{

    public static void Main()
    {
        ConstraintCollectionChanged();
    }

    // <Snippet1>
    private static void ConstraintCollectionChanged()
    {
        // Demonstrate ConstraintCollection.CollectionChanged event.
        try
        {
            // Create Customers table.
            DataTable customersTable = new DataTable("Customers");
            customersTable.Columns.Add("id", typeof(int));
            customersTable.Columns.Add("Name", typeof(string));
            customersTable.Constraints.CollectionChanged += 
                new System.ComponentModel.CollectionChangeEventHandler( 
                Collection_Changed);

            // Create Orders table.
            DataTable ordersTable = new DataTable("Orders");
            ordersTable.Columns.Add("CustID", typeof(int));
            ordersTable.Columns.Add("CustName", typeof(string));
            ordersTable.Constraints.CollectionChanged += 
                new System.ComponentModel.CollectionChangeEventHandler(
                Collection_Changed);

            // Create unique constraint.
            UniqueConstraint constraint = new UniqueConstraint(
                customersTable.Columns["id"]);
            customersTable.Constraints.Add(constraint);
		
            // Create unique constraint and specify as primary key.
            ordersTable.Constraints.Add(
                "pKey", ordersTable.Columns["CustID"], true);

            // Remove constraints.
            customersTable.Constraints.RemoveAt(0);

            // Results in an Exception. You can't remove 
            // a primary key constraint.
            ordersTable.Constraints.RemoveAt(0);  
        }
        catch(Exception ex)
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                ex.GetType());
        }
    }

    private static void Collection_Changed(object sender, 
        System.ComponentModel.CollectionChangeEventArgs ex)
    {
        Console.WriteLine("List_Changed Event: '{0}'\t element={1}", 
            ex.Action, ex.Element);
    }
    // </Snippet1>

}
