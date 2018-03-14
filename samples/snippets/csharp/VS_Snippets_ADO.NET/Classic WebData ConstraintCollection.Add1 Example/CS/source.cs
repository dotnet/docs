using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddUniqueConstraint(DataTable table)
    {
        DataColumn[] columns = new DataColumn[1];
        columns[0] = table.Columns["ID"];
        columns[1] = table.Columns["Name"];
        table.Constraints.Add("idNameConstraint", columns, true);
    }
    // </Snippet1>

}
