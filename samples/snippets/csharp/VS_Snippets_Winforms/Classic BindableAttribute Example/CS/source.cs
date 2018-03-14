using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1:Form
{
 protected TextBox textBox1; 

// <Snippet1>
[Bindable(true)]
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
         
         // Checks to see if the value of the BindableAttribute is Yes.
         if(attributes[typeof(BindableAttribute)].Equals(BindableAttribute.Yes)) {
            // Insert code here.
         }
         
         // This is another way to see whether the property is bindable.
         BindableAttribute myAttribute = 
            (BindableAttribute)attributes[typeof(BindableAttribute)];
         if(myAttribute.Bindable) {
            // Insert code here.
         }

	 // Yet another way to see whether the property is bindable.
	 if (attributes.Contains(BindableAttribute.Yes)) {
	    // Insert code here.
	 }

        // </Snippet2> 
        return 0;
    }
    set {
       // Insert code here.
    }
 }
 public int MyProperty3 {
    get {
        // <Snippet3>
        AttributeCollection attributes = 
            TypeDescriptor.GetAttributes(MyProperty);
         if(attributes[typeof(BindableAttribute)].Equals(BindableAttribute.Yes)) {
            // Insert code here.
         }
        // </Snippet3>
       return 0;
    }
    set {
       // Insert code here.
    }
 }

}

