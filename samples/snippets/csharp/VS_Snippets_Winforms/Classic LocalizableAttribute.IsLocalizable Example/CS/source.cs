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
 
 // Checks to see if the property needs to be localized.
 LocalizableAttribute myAttribute = 
    (LocalizableAttribute)attributes[typeof(LocalizableAttribute)];
 if(myAttribute.IsLocalizable) {
    // Insert code here.
 }
 
// </Snippet1>
 }
}
