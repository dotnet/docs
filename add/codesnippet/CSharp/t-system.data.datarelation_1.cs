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