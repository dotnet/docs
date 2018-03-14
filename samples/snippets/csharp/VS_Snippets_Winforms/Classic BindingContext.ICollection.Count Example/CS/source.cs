using System;
using System.Collections;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 private void PrintCount(){
    Console.WriteLine("BindingContext.Count " + ((ICollection) this.BindingContext).Count);
 } 
// </Snippet1>
}
