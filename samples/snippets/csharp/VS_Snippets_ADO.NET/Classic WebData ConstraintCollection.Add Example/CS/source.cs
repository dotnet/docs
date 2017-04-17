using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddConstraint(DataTable table)
    {
        UniqueConstraint uniqueConstraint;
        // Assuming a column named "UniqueColumn" exists, and 
        // its Unique property is true.
        uniqueConstraint = new UniqueConstraint(
            table.Columns["UniqueColumn"]);
        table.Constraints.Add(uniqueConstraint);
    }
    // </Snippet1>

}
