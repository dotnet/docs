using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void InitializeMyScrollBar()
 {
    // Create and initialize a VScrollBar.
    VScrollBar vScrollBar1 = new VScrollBar();
    
    // Dock the scroll bar to the right side of the form.
    vScrollBar1.Dock = DockStyle.Right;
    
    // Add the scroll bar to the form.
    Controls.Add(vScrollBar1);
 }
 
// </Snippet1>
}
