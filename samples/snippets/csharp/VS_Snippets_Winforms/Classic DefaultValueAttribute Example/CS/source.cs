using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>

private bool myVal=false;

[DefaultValue(false)]
 public bool MyProperty {
    get {
       return myVal;
    }
    set {
       myVal=value;
    }
 }
// </Snippet1>
 protected void Method()
 {
    // <Snippet2>
    // Gets the attributes for the property.
     AttributeCollection attributes = 
        TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
     
     /* Prints the default value by retrieving the DefaultValueAttribute 
      * from the AttributeCollection. */
     DefaultValueAttribute myAttribute = 
        (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
     Console.WriteLine("The default value is: " + myAttribute.Value.ToString());
    // </Snippet2>
 }
}

