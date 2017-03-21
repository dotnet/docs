    private void GetConstraint(DataTable table)
    {
        if(table.Constraints.Contains("CustomersOrdersConstraint"))
        {
            Constraint constraint = 
                table.Constraints["CustomersOrdersConstraint"];
        }
    }