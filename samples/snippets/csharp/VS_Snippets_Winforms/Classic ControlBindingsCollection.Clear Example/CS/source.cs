using System;
using System.Windows.Forms;

public class Form1 : Form {

    protected GroupBox groupBox1;

// <Snippet1>
private void ClearAllBindings()
{
   foreach(Control c in groupBox1.Controls)
   c.DataBindings.Clear();
}
// </Snippet1>

}
