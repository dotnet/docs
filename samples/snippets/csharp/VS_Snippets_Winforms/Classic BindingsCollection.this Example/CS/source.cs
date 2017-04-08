using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
// <Snippet1>
private void PrintBindingInfo()
{
   BindingsCollection bc = text1.DataBindings;
   for(int i = 0; i < bc.Count; i++)
      Console.WriteLine(bc[i].BindingMemberInfo.BindingMember);
}

// </Snippet1>
}
