using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
private void InitializeMyScrollBar()
 {
    // Create and initialize an HScrollBar.
    HScrollBar hScrollBar1 = new HScrollBar();
    
    // Dock the scroll bar to the bottom of the form.
    hScrollBar1.Dock = DockStyle.Bottom;
    
    // Add the scroll bar to the form.
    Controls.Add(hScrollBar1);
 }
    
// </Snippet1>
}
