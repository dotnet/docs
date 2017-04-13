using System;
using System.Data;
using System.Windows.Forms;

public class Form1 : Form {

    protected GroupBox groupBox1;
    protected GroupBox groupBox2;
    protected TextBox textBox1;
    protected TextBox textBox2;

    protected DataSet ds;
    
// <Snippet1>
private void BindControls()
{
   BindingContext bcG1 = new BindingContext();
   BindingContext bcG2 = new BindingContext();

   groupBox1.BindingContext = bcG1;
   groupBox2.BindingContext = bcG2;

   textBox1.DataBindings.Add("Text", ds, "Customers.CustName");
   textBox2.DataBindings.Add("Text", ds, "Customers.CustName");
}

private void Button1_Click(object sender, EventArgs e)
{
   groupBox1.BindingContext[ds, "Customers"].Position += 1;         
}

private void Button2_Click(object sender, EventArgs e)
{
   groupBox2.BindingContext[ds, "Customers"].Position += 1;
}
// </Snippet1>

}
