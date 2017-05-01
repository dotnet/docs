using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
    protected Button button1;
    protected TextBox textBox1;
    private void Method1()
    {
        // <Snippet1>
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);
        // </Snippet1>
    }
    // <Snippet2>
    private void MyPropertyCollection() {
        // Creates a new collection and assign it the properties for button1.
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);
     
        // Displays each property in the collection in a text box.
        foreach (PropertyDescriptor myProperty in properties)
           textBox1.Text += myProperty.Name + '\n';
     }
    // </Snippet2>
}
