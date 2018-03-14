using System;
using System.Data;


public class Sample
{
    static void Main()
    {
        // create a DataSet with two tables
        DataSet dataSet = new DataSet();

        // create Customer table
        DataTable customersTable = new DataTable("Customers");
        customersTable.Columns.Add("customerId", typeof(int)).AutoIncrement = true;
        customersTable.Columns.Add("name",       typeof(string));
        customersTable.PrimaryKey = new DataColumn[] { customersTable.Columns["customerId"] };

        // create Orders table
        DataTable ordersTable = new DataTable("Orders");
        ordersTable.Columns.Add("orderId",    typeof(int)).AutoIncrement = true;
        ordersTable.Columns.Add("customerId", typeof(int));
        ordersTable.Columns.Add("amount",     typeof(double));
        ordersTable.PrimaryKey = new DataColumn[] { customersTable.Columns["orderId"] };

        // create Order Details table
        DataTable orderDetailsTable = new DataTable("OrderDetails");
        orderDetailsTable.Columns.Add("orderId",    typeof(int));
        orderDetailsTable.Columns.Add("productId",     typeof(int));
        orderDetailsTable.Columns.Add("quantity",     typeof(double));

        dataSet.Tables.AddRange(new DataTable[] {customersTable, ordersTable, orderDetailsTable} );

        // print the tables and their columns
        foreach(DataTable table in dataSet.Tables )
        {
            Console.WriteLine(table.TableName );
            foreach(DataColumn column in table.Columns )
            {
                Console.WriteLine("{0}", column.ColumnName.ToString() );
            }
            Console.WriteLine();
        }

        AddRelations(dataSet);
    }

    // <Snippet1>
    public static void AddRelations(DataSet dataSet)
    {
        DataRelation customerOrders = 
            new DataRelation("CustomerOrders",
            dataSet.Tables["Customers"].Columns["customerId"],
            dataSet.Tables["Orders"].Columns["customerId"]);

        DataRelation orderDetails = 
            new DataRelation("OrderDetail",
            dataSet.Tables["Orders"].Columns["orderId"],
            dataSet.Tables["OrderDetails"].Columns["orderId"]);

        dataSet.Relations.AddRange(new DataRelation[] 
            {customerOrders, orderDetails});

        // Display names of all relations.
        foreach (DataRelation relation in dataSet.Relations)
            Console.WriteLine(relation.RelationName.ToString());
    }
    // </Snippet1>

}