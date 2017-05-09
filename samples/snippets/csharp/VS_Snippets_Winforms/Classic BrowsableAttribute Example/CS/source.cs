using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
[Browsable(true)]
 public int MyProperty {
    get {
       // Insert code here.
       return 0;
    }
    set {
       // Insert code here.
    }
 }
   // </Snippet1>
 public int MyProperty2 {
    get {
        // <Snippet2>
        // Gets the attributes for the property.
         AttributeCollection attributes = 
            TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
         
         // Checks to see if the value of the BrowsableAttribute is Yes.
         if(attributes[typeof(BrowsableAttribute)].Equals(BrowsableAttribute.Yes)) {
            // Insert code here.
         }
         
         // This is another way to see whether the property is browsable.
         BrowsableAttribute myAttribute = 
            (BrowsableAttribute)attributes[typeof(BrowsableAttribute)];
         if(myAttribute.Browsable) {
            // Insert code here.
         }
        // </Snippet2>
       return 0;
    }
    }

 public int MyProperty3 {
    get {
        // <Snippet3>
        AttributeCollection attributes = 
            TypeDescriptor.GetAttributes(MyProperty);
         if(attributes[typeof(BrowsableAttribute)].Equals(BrowsableAttribute.Yes)) {
            // Insert code here.
         }
        // </Snippet3>
        return 0;
        }
    }
}
