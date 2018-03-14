using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class Form1: Form
{
 protected ToolBar toolBar1;

 protected PrintDialog printDialog1;
 protected OpenFileDialog openFileDialog1;
 protected SaveFileDialog saveFileDialog1;

// <Snippet1>
public void InitializeMyToolBar()
 {
    // Create and initialize the ToolBar and ToolBarButton controls.
    toolBar1 = new ToolBar();
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
    
    // Add the event-handler delegate.
    toolBar1.ButtonClick += new ToolBarButtonClickEventHandler(
       toolBar1_ButtonClick);
    
    // Add the ToolBar to the Form.
    Controls.Add(toolBar1);
 }
 
 private void toolBar1_ButtonClick (
                         Object sender, 
                         ToolBarButtonClickEventArgs e)
 {
   // Evaluate the Button property to determine which button was clicked.
   switch(toolBar1.Buttons.IndexOf(e.Button))
   {
      case 0:
         openFileDialog1.ShowDialog();
         // Insert additional code here to open the file.
         break; 
      case 1:
         saveFileDialog1.ShowDialog();
         // Insert additional code here to save the file.
         break; 
      case 2:
         printDialog1.ShowDialog();
         // Insert additional code here to print the file.    
         break; 
    }
 }

// </Snippet1>
}
