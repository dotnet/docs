using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void PrintPropertyNameAndIsBinding()
{
   foreach(Control thisControl in this.Controls)
   {
      foreach(Binding thisBinding in thisControl.DataBindings)
      {
         Console.WriteLine("\n" + thisControl.ToString());
         // Print the PropertyName value for each binding.
         Console.WriteLine(thisBinding.PropertyName);
      }
   }
}

// </Snippet1>
}
