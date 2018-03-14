using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void TryContainsDataMember(DataSet myDataSet){
    bool trueorfalse;
    trueorfalse = this.BindingContext.Contains(myDataSet,"Suppliers");
    Console.WriteLine(trueorfalse.ToString());
 }

// </Snippet1>
}
