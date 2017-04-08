using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
public void InitializeMyToolBar()
 {
    // Create and initialize the ToolBarButton controls and ToolBar.
    ToolBar toolBar1 = new ToolBar();
    ToolBarButton toolBarButton1 = new ToolBarButton();
    ToolBarButton toolBarButton2 = new ToolBarButton();
    ToolBarButton toolBarButton3 = new ToolBarButton();
 
    // Set the Text properties of the ToolBarButton controls.
    toolBarButton1.Text = "Open";
    toolBarButton2.Text = "Save";
    toolBarButton3.Text = "Print";
 
    // Add the ToolBarButton controls to the ToolBar.
    toolBar1.Buttons.Add(toolBarButton1);
    toolBar1.Buttons.Add(toolBarButton2);
    toolBar1.Buttons.Add(toolBarButton3);
 
    // Add the ToolBar to the Form.
    Controls.Add(toolBar1);
 }

// </Snippet1>
}
