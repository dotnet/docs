using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected ToolBar toolBar1;
// <Snippet1>
public void RemoveMyButton()
 {
    int btns;
    btns = toolBar1.Buttons.Count;
 
    // Remove the last toolbar button.
    toolBar1.Buttons.RemoveAt(btns - 1);
 }
   
// </Snippet1>
}
