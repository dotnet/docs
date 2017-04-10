using System;
using System.Windows.Forms;

public class Form1 : Form {

    protected TextBox textBox1;
    
// <Snippet1>
private void RemoveBackColorBinding()
{
   Binding colorBinding = textBox1.DataBindings["BackColor"];
   textBox1.DataBindings.Remove(colorBinding);
}
// </Snippet1>

}
