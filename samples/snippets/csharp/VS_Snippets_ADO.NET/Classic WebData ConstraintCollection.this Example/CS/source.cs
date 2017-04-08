using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetConstraint(DataTable table)
    {
        for(int i = 0; i < table.Constraints.Count; i++)
        {
            Console.WriteLine(table.Constraints[i].ConstraintName);
            Console.WriteLine(table.Constraints[i].GetType());
        }
    }
    // </Snippet1>

}
