using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected ToolBar toolBar1;
// <Snippet1>
public void AddMyButton()
 {
    ToolBarButton toolBarButton1 = new ToolBarButton();
    toolBarButton1.Text = "Print";
 
    // Add the new toolbar button to the toolbar.
    toolBar1.Buttons.Add(toolBarButton1);
 }

// </Snippet1>
}
