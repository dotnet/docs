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
 
 // Checks to see if the property is recommended as configurable.
 RecommendedAsConfigurableAttribute myAttribute = 
    (RecommendedAsConfigurableAttribute)attributes[typeof(RecommendedAsConfigurableAttribute)];
 if(myAttribute.RecommendedAsConfigurable) {
    // Insert code here.
 }
 
// </Snippet1>
 }
}
