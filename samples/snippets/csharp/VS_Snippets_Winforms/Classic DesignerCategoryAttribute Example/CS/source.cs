using System;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

public class Class1
{
    // <Snippet1>
    [Designer("System.Windows.Forms.Design.DocumentDesigner, System.Windows.Forms.Design", 
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
     
        /* Prints the name of the designer by retrieving the 
         * DesignerCategoryAttribute from the AttributeCollection. */
        DesignerCategoryAttribute myAttribute = 
           (DesignerCategoryAttribute)attributes[typeof(DesignerCategoryAttribute)];
        Console.WriteLine("The category of the designer for this class is: " + myAttribute.Category);
      
        return 0;
    }
    // </Snippet2>
}
