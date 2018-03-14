using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected Button button1;

 protected void Method()
{
// <Snippet1>
EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);

// </Snippet1>
}
}
