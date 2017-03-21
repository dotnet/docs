    private void GetConstraint(DataTable table)
    {
        for(int i = 0; i < table.Constraints.Count; i++)
        {
            Console.WriteLine(table.Constraints[i].ConstraintName);
            Console.WriteLine(table.Constraints[i].GetType());
        }
    }