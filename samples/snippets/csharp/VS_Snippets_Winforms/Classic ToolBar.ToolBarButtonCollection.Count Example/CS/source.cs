using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected ToolBar toolBar1;
// <Snippet1>
public void ClearMyToolBar()
 {
    int btns;
    // Get the count before the Clear method is called.
    btns = toolBar1.Buttons.Count;
    toolBar1.Buttons.Clear();
    MessageBox.Show("Count Before Clear: " + btns.ToString() +
                    "\nCount After Clear: " + toolBar1.Buttons.Count.ToString());
 }
 
// </Snippet1>
}
