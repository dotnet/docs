using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void PrintPropertyDescriptions(BindingManagerBase b)
{
   Console.WriteLine("Printing Property Descriptions");
   PropertyDescriptorCollection ps = b.GetItemProperties();
   for(int i = 0; i < ps.Count; i++)
   {
      Console.WriteLine("\t" + ps[i].Name + "\t" + ps[i].PropertyType);
   }
}

// </Snippet1>
}
