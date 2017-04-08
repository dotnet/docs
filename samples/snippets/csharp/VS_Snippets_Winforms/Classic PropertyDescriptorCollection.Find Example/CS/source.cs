using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected Button button1;
 protected TextBox textBox1;
// <Snippet1>
 private void FindProperty() {
    // Creates a new collection and assign it the properties for button1.
    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);
 
    // Sets a PropertyDescriptor to the specific property.
    PropertyDescriptor myProperty = properties.Find("Opacity", false);
 
    // Prints the property and the property description.
    textBox1.Text = myProperty.DisplayName + '\n' + myProperty.Description;
 }

// </Snippet1>
}
