using System;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected Button   button1;
 protected TextBox textBox1;
// <Snippet1>
private void PrintIndexItem() {
    // Creates a new collection and assigns it the attributes for button1.
    AttributeCollection attributes;
    attributes = TypeDescriptor.GetAttributes(button1);
 
    // Prints the second attribute's name.
    textBox1.Text = attributes[1].ToString();
 }

// </Snippet1>
}
