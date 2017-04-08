using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void PrintPositions()
{
   foreach(Control c in this.Controls)
   {
      foreach(Binding xBinding in c.DataBindings)
      {
         Console.WriteLine
         (c.ToString() + "\t Position: " + 
         xBinding.BindingManagerBase.Position);
      }
   }
}

// </Snippet1>
}
