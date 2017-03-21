    private void RemoveConstraint(DataTable table, 
        Constraint constraint)
    {
        if(table.Constraints.Contains(constraint.ConstraintName))
            if(table.Constraints.CanRemove(constraint))
                table.Constraints.Remove(constraint);
    }