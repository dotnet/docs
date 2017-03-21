    public static void RemoveConstraint(
        ConstraintCollection constraints, Constraint constraint)
    {
        try
        {
            if(constraints.Contains(constraint.ConstraintName)) 
            {
                if(constraints.CanRemove(constraint)) 
                {
                    constraints.Remove(constraint.ConstraintName);
                }
            }
        }
        catch(Exception e) 
        {
            // Process exception and return.
            Console.WriteLine("Exception of type {0} occurred.", 
                e.GetType());
        }
    }