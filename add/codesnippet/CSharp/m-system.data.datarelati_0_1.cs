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