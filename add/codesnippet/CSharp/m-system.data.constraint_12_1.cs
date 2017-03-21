    private void TryRemove(DataSet dataSet)
    {
        try
        {
            DataTable customersTable = dataSet.Tables["Customers"];
            Constraint constraint = customersTable.Constraints[0];
            Console.WriteLine("Can remove? " + 
                customersTable.Constraints.CanRemove(constraint));
        }
        catch(Exception ex) 
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                ex.GetType());
        }
    }