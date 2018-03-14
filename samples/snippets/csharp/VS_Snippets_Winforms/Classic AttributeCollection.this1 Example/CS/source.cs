using System;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected Button   button1;
 protected TextBox textBox1;
// <Snippet1>
private void PrintIndexItem2() {
    // Creates a new collection and assigns it the attributes for button1.
    AttributeCollection attributes;
    attributes = TypeDescriptor.GetAttributes(button1);
 
    // Gets the designer attribute from the collection.
    DesignerAttribute myDesigner; 
    // You must supply a valid fully qualified assembly name here. 
    myDesigner = (DesignerAttribute)attributes[Type.GetType("Assembly text name, Version, Culture, PublicKeyToken")];
    textBox1.Text = myDesigner.DesignerTypeName;
 }

// </Snippet1>
}
