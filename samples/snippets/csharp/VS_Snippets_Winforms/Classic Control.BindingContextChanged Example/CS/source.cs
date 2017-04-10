using System;
using System.Windows.Forms;

public class Form1 : Form {

    protected TextBox textBox1;

// <Snippet1>
private void AddEventHandler()
{
   textBox1.BindingContextChanged += new EventHandler(BindingContext_Changed);
}

private void BindingContext_Changed(object sender, EventArgs e)
{
   Console.WriteLine("BindingContext changed");
}
// </Snippet1>

}
