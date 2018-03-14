using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{

public static void Main()
{   
}

 protected DataGrid dataGrid1;
// <Snippet1>
private void ToggleAllowSorting()
{
   // Toggle the AllowSorting property.
   dataGrid1.AllowSorting = ! dataGrid1.AllowSorting;
}

// </Snippet1>
}
