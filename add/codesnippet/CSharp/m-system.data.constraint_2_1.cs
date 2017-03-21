    private void AddConstraint(DataTable table)
    {
        UniqueConstraint uniqueConstraint;
        // Assuming a column named "UniqueColumn" exists, and 
        // its Unique property is true.
        uniqueConstraint = new UniqueConstraint(
            table.Columns["UniqueColumn"]);
        table.Constraints.Add(uniqueConstraint);
    }