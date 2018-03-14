using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
    protected TextBox textBox1;
    // <Snippet1>
    [ReadOnly(true)]
     public int MyProperty {
        get {
           // Insert code here.
           return 0;
        }
    }
    // </Snippet1>
    public void Method1()
    {
        // <Snippet2>
        // Gets the attributes for the property.
        AttributeCollection attributes = 
           TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
         
        // Checks to see whether the value of the ReadOnlyAttribute is Yes.
        if(attributes[typeof(ReadOnlyAttribute)].Equals(ReadOnlyAttribute.Yes)) {
           // Insert code here.
        }
         
        // This is another way to see whether the property is read-only.
        ReadOnlyAttribute myAttribute = 
           (ReadOnlyAttribute)attributes[typeof(ReadOnlyAttribute)];
        if(myAttribute.IsReadOnly) {
           // Insert code here.
        }
        // </Snippet2>
    }
    
    public void Method2()
    {
        // <Snippet3>
        AttributeCollection attributes = 
           TypeDescriptor.GetAttributes(MyProperty);
        if(attributes[typeof(ReadOnlyAttribute)].Equals(ReadOnlyAttribute.Yes)) {
           // Insert code here.
        }
        // </Snippet3>
    }
}
