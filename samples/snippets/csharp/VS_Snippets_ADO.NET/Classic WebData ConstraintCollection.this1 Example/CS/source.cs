using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetConstraint(DataTable table)
    {
        if(table.Constraints.Contains("CustomersOrdersConstraint"))
        {
            Constraint constraint = 
                table.Constraints["CustomersOrdersConstraint"];
        }
    }
    // </Snippet1>

}
