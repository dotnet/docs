using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void PrintBindingMemberInfo()
{
   foreach(Control thisControl in this.Controls)
   {
      foreach(Binding thisBinding in thisControl.DataBindings)
      {
         // Print the control's name and Binding information.
         Console.WriteLine("\n" + thisControl.ToString());
         BindingMemberInfo bInfo = thisBinding.BindingMemberInfo;
         Console.WriteLine("Binding Path \t" + bInfo.BindingPath);
         Console.WriteLine("Binding Field \t" + bInfo.BindingField);
         Console.WriteLine("Binding Member \t" + bInfo.BindingMember);
      }
   }
}
// </Snippet1>
}
