using System;
using System.Collections;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 private void CopyToArray(){
    // Declare the array.
    object [] myArray = new object [100];
    ((ICollection)this.BindingContext).CopyTo(myArray, 0);
 }       
// </Snippet1>
}
