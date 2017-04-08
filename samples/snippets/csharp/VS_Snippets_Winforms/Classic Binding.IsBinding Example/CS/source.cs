using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void PrintBindingIsBinding()
{
   foreach(Control c in this.Controls)
   {
      foreach(Binding b in c.DataBindings)
      {
         Console.WriteLine("\n" + c.ToString());
         Console.WriteLine(b.PropertyName + " IsBinding: " 
             + b.IsBinding);
      }
   }
}

// </Snippet1>
}
