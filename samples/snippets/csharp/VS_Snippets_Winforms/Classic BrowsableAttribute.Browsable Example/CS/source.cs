using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
// Gets the attributes for the property.
 AttributeCollection attributes = 
    TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
 
 // Checks to see if the property is browsable.
 BrowsableAttribute myAttribute = (BrowsableAttribute)attributes[typeof(BrowsableAttribute)];
 if(myAttribute.Browsable) {
    // Insert code here.
 }
 
// </Snippet1>
 }
}
