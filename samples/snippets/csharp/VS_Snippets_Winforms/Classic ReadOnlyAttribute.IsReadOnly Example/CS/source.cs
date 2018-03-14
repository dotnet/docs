using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 
 public void Method()
 {
// <Snippet1>
 // Gets the attributes for the property.
 AttributeCollection attributes = 
    TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
 
 // Checks to see whether the property is read-only.
 ReadOnlyAttribute myAttribute = 
    (ReadOnlyAttribute)attributes[typeof(ReadOnlyAttribute)];
 
 if(myAttribute.IsReadOnly) {
    // Insert code here.
 }
 
// </Snippet1>
 }
}
