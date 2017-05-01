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
    TypeDescriptor.GetProperties(this)["MyPropertyProperty"].Attributes;
 
 // Checks to see if the property is bindable.
 MergablePropertyAttribute myAttribute = (MergablePropertyAttribute)attributes[typeof(MergablePropertyAttribute)];
 if(myAttribute.AllowMerge) {
    // Insert code here.
 }
 
// </Snippet1>
 }
}
