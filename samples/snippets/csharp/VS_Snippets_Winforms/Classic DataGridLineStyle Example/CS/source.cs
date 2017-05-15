using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
    protected DataGrid dataGrid1;
    // <Snippet1>
    private void SetGridLineAttributes()
    {
       dataGrid1.GridLineStyle = DataGridLineStyle.None;
    }
// </Snippet1>
}
