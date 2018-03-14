using System;
using System.Windows.Forms;

public class Form1 : Form {

    protected TextBox textBox1;

// <Snippet1>
private void RemoveThirdBinding()
{
   if(textBox1.DataBindings.Count < 3) return;
   textBox1.DataBindings.RemoveAt(2);
}
// </Snippet1>

}
