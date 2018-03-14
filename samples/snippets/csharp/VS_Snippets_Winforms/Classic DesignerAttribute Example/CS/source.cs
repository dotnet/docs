using System;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

public class Class1
{
    // <Snippet1>
    [Designer("System.Windows.Forms.Design.DocumentDesigner, System.Windows.Forms.Design.DLL", 
        typeof(IRootDesigner)),
        DesignerCategory("Form")]
    public class MyForm : ContainerControl {
        // Insert code here.
    }
    // </Snippet1>
    // <Snippet2>
    public static int Main() {
        // Creates a new form.
        MyForm myNewForm = new MyForm();
     
        // Gets the attributes for the collection.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewForm);
     
        /* Prints the name of the designer by retrieving the DesignerAttribute
         * from the AttributeCollection. */
        DesignerAttribute myAttribute = 
           (DesignerAttribute)attributes[typeof(DesignerAttribute)];
        Console.WriteLine("The designer for this class is: " + myAttribute.DesignerTypeName);
      
        return 0;
    }
    // </Snippet2>
}
