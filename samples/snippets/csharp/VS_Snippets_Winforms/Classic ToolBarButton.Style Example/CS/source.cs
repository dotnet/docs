using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected ImageList imageList1;
 protected ContextMenu contextMenu1;
 protected MenuItem menuItem1;

// <Snippet1>
public void InitializeMyToolBar()
 {
    // Create the ToolBar, ToolBarButton controls, and menus.
    ToolBarButton toolBarButton1 = new ToolBarButton("Open");
    ToolBarButton toolBarButton2 = new ToolBarButton();
    ToolBarButton toolBarButton3 = new ToolBarButton();
    ToolBar toolBar1 = new ToolBar();
    MenuItem menuItem1 = new MenuItem("Print");
    ContextMenu contextMenu1 = new ContextMenu(new MenuItem[]{menuItem1});

     
    // Add the ToolBarButton controls to the ToolBar.
    toolBar1.Buttons.Add(toolBarButton1);
    toolBar1.Buttons.Add(toolBarButton2);
    toolBar1.Buttons.Add(toolBarButton3);
 
    // Assign an ImageList to the ToolBar and show ToolTips.
    toolBar1.ImageList = imageList1;
    toolBar1.ShowToolTips = true;
 
    /* Assign ImageIndex, ContextMenu, Text, ToolTip, and 
       Style properties of the ToolBarButton controls. */
    toolBarButton2.Style = ToolBarButtonStyle.Separator;
    toolBarButton3.Text = "Print";
    toolBarButton3.Style = ToolBarButtonStyle.DropDownButton;
    toolBarButton3.ToolTipText = "Print";
    toolBarButton3.ImageIndex = 0;
    toolBarButton3.DropDownMenu = contextMenu1;
 
    // Add the ToolBar to a form.
    Controls.Add(toolBar1);
 }
 
// </Snippet1>
}
