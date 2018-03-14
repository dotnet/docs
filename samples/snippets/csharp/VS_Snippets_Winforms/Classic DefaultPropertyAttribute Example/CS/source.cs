using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
    // <Snippet2>
    public static int Main() {
        // Creates a new control.
        MyControl myNewControl = new MyControl();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewControl);
     
        /* Prints the name of the default property by retrieving the 
         * DefaultPropertyAttribute from the AttributeCollection. */
        DefaultPropertyAttribute myAttribute = 
           (DefaultPropertyAttribute)attributes[typeof(DefaultPropertyAttribute)];
        Console.WriteLine("The default property is: " + myAttribute.Name);
      
        return 0;
     }
    // </Snippet2>
    // <Snippet1>
    [DefaultProperty("MyProperty")]
     public class MyControl : Control {
     
        public int MyProperty {
           get {
              // Insert code here.
              return 0;
           }
           set {
              // Insert code here.
           }
        }
     
        // Insert any additional code.
     
     }
    // </Snippet1>
}

