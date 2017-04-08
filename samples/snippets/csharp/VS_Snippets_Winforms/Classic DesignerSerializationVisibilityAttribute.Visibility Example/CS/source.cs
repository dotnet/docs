using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;

 protected void Method()
 {
// <Snippet1>
// Gets the attributes for the property.
 AttributeCollection attributes = 
    TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
 
 // Checks to see if the value of the DesignerSerializationVisibilityAttribute is set to Content.
 if(attributes[typeof(DesignerSerializationVisibilityAttribute)].Equals(DesignerSerializationVisibilityAttribute.Content)) {
    // Insert code here.
 }
 
 // This is another way to see whether the property is marked as serializing content.
 DesignerSerializationVisibilityAttribute myAttribute = 
    (DesignerSerializationVisibilityAttribute)attributes[typeof(DesignerSerializationVisibilityAttribute)];
 if(myAttribute.Visibility == DesignerSerializationVisibility.Content) {
    // Insert code here.
 }

// </Snippet1>
}
}
