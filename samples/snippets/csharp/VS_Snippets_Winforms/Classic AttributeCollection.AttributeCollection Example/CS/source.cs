using System;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected Button   button1;
 protected TextBox textBox1;

protected void Method()
{
// <Snippet1>
AttributeCollection collection1;
collection1 = TypeDescriptor.GetAttributes(button1);
}
// </Snippet1>
}
