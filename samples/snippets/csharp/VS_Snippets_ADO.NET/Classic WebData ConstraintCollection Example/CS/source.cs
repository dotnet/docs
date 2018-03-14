using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void MakeTableWithUniqueConstraint()
    {
        DataTable table = new DataTable("table");
        DataColumn column = new DataColumn("UniqueColumn");
        column.Unique=true;
        table.Columns.Add(column);

        // Print count, name, and type.
        Console.WriteLine("Constraints.Count " 
            + table.Constraints.Count);
        Console.WriteLine(table.Constraints[0].ConstraintName);
        Console.WriteLine(table.Constraints[0].GetType() );

        // Add a second unique column.
        column = new DataColumn("UniqueColumn2");
        column.Unique=true;
        table.Columns.Add(column);

        // Print info again.
        Console.WriteLine("Constraints.Count " 
            + table.Constraints.Count);
        Console.WriteLine(table.Constraints[1].ConstraintName);
        Console.WriteLine(table.Constraints[1].GetType() );
    }
     
    private void MakeTableWithForeignConstraint()
    {
        // Create a DataSet.
        DataSet dataSet = new DataSet("dataSet");

        // Make two tables.
        DataTable customersTable= new DataTable("Customers");
        DataTable ordersTable = new DataTable("Orders");

        // Create four columns, two for each table.
        DataColumn name = new DataColumn("Name");
        DataColumn id = new DataColumn("ID");
        DataColumn orderId = new DataColumn("OrderID");
        DataColumn cDate = new DataColumn("OrderDate");
 
        // Add columns to tables.
        customersTable.Columns.Add(name);
        customersTable.Columns.Add(id);
        ordersTable.Columns.Add(orderId);
        ordersTable.Columns.Add(cDate);
 
        // Add tables to the DataSet.
        dataSet.Tables.Add(customersTable);
        dataSet.Tables.Add(ordersTable); 

        // Create a DataRelation for two of the columns.
        DataRelation myRelation = new 
            DataRelation("CustomersOrders",id,orderId,true);
        dataSet.Relations.Add(myRelation);

        // Print TableName, Constraints.Count, 
        // ConstraintName and Type.
        foreach(DataTable t in dataSet.Tables)
        {
            Console.WriteLine(t.TableName);
            Console.WriteLine("Constraints.Count " 
                + t.Constraints.Count);
            Console.WriteLine("ParentRelations.Count " 
                + t.ParentRelations.Count);
            Console.WriteLine("ChildRelations.Count " 
                + t.ChildRelations.Count);
            foreach(Constraint cstrnt in t.Constraints)
            {
                Console.WriteLine(cstrnt.ConstraintName);
                Console.WriteLine(cstrnt.GetType());
            }
        }
    }
    // </Snippet1>

}
