using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
 protected DataSet ds;
// <Snippet1>
private void PrintBoundControls()
{
   BindingManagerBase myBindingBase = this.BindingContext[ds, "customers"];
   foreach(Binding b in myBindingBase.Bindings)
   {
      Console.WriteLine(b.Control.ToString());
   }
}

// </Snippet1>
}
