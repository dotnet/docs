using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void PrintBindingMemberInfo()
{
   foreach(Control c in this.Controls)
   {
      foreach(Binding b in c.DataBindings)
      {
         Console.WriteLine("\n" + c.ToString());
         BindingMemberInfo bInfo = b.BindingMemberInfo;
         Console.WriteLine("Binding Path \t" + bInfo.BindingPath);
         Console.WriteLine("Binding Field \t" + bInfo.BindingField);
         Console.WriteLine("Binding Member \t" + bInfo.BindingMember);
      }
   }
}
// </Snippet1>
}
