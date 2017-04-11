using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class Form1: Form
{
 protected TextBox textBox1;
 protected Image image1;
 // <Snippet1>
[Description("The image associated with the control"),Category("Appearance")] 
 public Image MyImage {
    get {
       // Insert code here.
       return image1;
    }
    set {
       // Insert code here.
    }
 }
// </Snippet1>
public void MyMethod(){
    // <Snippet2>
    // Gets the attributes for the property.
     AttributeCollection attributes = 
        TypeDescriptor.GetProperties(this)["MyImage"].Attributes;
     
     // Prints the description by retrieving the CategoryAttribute.
     // from the AttributeCollection.
     CategoryAttribute myAttribute = 
        (CategoryAttribute)attributes[typeof(CategoryAttribute)];
     Console.WriteLine(myAttribute.Category);
    // </Snippet2>
}
}
