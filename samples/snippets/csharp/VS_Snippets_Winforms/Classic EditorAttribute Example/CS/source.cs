using System;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;


public class Class1{
    // <Snippet1>
   [Editor("System.Windows.Forms.ImageEditorIndex, System.Design", 
       typeof(UITypeEditor))]

   public class MyImage
   {
       // Insert code here.
    }
    // </Snippet1>

    // <Snippet2>
    public static int Main() {
        // Creates a new component.
        MyImage myNewImage = new MyImage();
     
        // Gets the attributes for the component.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewImage);
     
        /* Prints the name of the editor by retrieving the EditorAttribute 
         * from the AttributeCollection. */
        
        EditorAttribute myAttribute = (EditorAttribute)attributes[typeof(EditorAttribute)];
        Console.WriteLine("The editor for this class is: " + myAttribute.EditorTypeName);
     
        return 0;
     }
    // </Snippet2>
}
