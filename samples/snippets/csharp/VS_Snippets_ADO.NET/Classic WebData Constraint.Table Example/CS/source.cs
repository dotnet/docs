using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{

// <Snippet1>
 private void GetDataTable(UniqueConstraint constraint){
    DataTable table = constraint.Table;
    Console.WriteLine(table.TableName);
 }
// </Snippet1>

}
