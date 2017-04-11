using System;
using System.Windows.Forms;

public class Form1 : Form {

// <Snippet1>
private void GetControl(ControlBindingsCollection myBindings)
{
   Control c = myBindings.Control;
   Console.WriteLine(c.ToString());
}
// </Snippet1>

}
