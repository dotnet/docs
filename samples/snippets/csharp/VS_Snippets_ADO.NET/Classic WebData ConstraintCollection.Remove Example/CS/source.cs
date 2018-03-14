using System;
using System.Data;
using System.Windows.Forms;

public class Form1 : Form 
{

    // <Snippet1>
    private void RemoveConstraint(DataTable table, 
        Constraint constraint)
    {
        if(table.Constraints.Contains(constraint.ConstraintName))
            if(table.Constraints.CanRemove(constraint))
                table.Constraints.Remove(constraint);
    }
    // </Snippet1>

}
