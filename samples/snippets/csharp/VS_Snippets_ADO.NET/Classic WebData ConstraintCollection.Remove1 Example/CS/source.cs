using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void RemoveConstraint(ConstraintCollection constraints, 
        Constraint constraint)
    {
        if(constraints.Contains(constraint.ConstraintName))
            if(constraints.CanRemove(constraint))
                constraints.Remove(constraint.ConstraintName);
    }
    // </Snippet1>

}
