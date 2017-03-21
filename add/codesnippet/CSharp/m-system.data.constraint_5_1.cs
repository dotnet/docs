    private void RemoveConstraint(ConstraintCollection constraints, 
        Constraint constraint)
    {
        if(constraints.Contains(constraint.ConstraintName))
            if(constraints.CanRemove(constraint))
                constraints.Remove(constraint.ConstraintName);
    }