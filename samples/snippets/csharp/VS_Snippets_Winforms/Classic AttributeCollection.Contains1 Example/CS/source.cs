using System;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected Button   button1;
 protected TextBox textBox1;
// <Snippet1>
 private void ContainsAttributes() {
    // Creates a new collection and assigns it the attributes for button1.
    AttributeCollection myCollection;
    myCollection = TypeDescriptor.GetAttributes(button1);    
 
    // Checks to see whether the attributes in myCollection are the attributes for textBox1.
    Attribute[] myAttrArray = new Attribute[100];
    TypeDescriptor.GetAttributes(textBox1).CopyTo(myAttrArray, 0);
    if (myCollection.Contains(myAttrArray))
       textBox1.Text = "Both the button and text box have the same attributes.";
    else
       textBox1.Text = "The button and the text box do not have the same attributes.";
 }
// </Snippet1>
}
