using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected ToolBar toolBar1;
// <Snippet1>
public void ReplaceMyToolBarButton()
 {
    int btns;
    btns = toolBar1.Buttons.Count;
    ToolBarButton toolBarButton1 = new ToolBarButton();
    toolBarButton1.Text = "myButton";
 
    // Replace the last ToolBarButton in the collection.
    toolBar1.Buttons[btns - 1] = toolBarButton1;
 }
    
// </Snippet1>
}
