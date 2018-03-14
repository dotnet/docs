using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void TryContains(DataSet myDataSet){
    // Test each DataTable in a DataSet to see if it is bound to a BindingManagerBase.
    foreach(DataTable thisTable in myDataSet.Tables){
       Console.WriteLine(thisTable.TableName + ": " + this.BindingContext.Contains(thisTable));
    }
 }

// </Snippet1>
}
