using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected Button button1;
 protected Panel panel1;

 protected int myCounter;

// <Snippet1>
private void SetDockPadding()
 {
    // Dock the button in the panel.
    button1.Dock = System.Windows.Forms.DockStyle.Fill;
    
    // Reset the counter if it is greater than 5.
    if (myCounter > 5)
    {
       myCounter = 0;
    }
 
    // Set the appropriate DockPadding and display
    // which one was set on the button face.
    switch (myCounter)
    {
       case 0:
          panel1.DockPadding.All = 0;
          button1.Text = "Start";
          break;
       case 1:
          panel1.DockPadding.Top = 10;
          button1.Text = "Top";
          break;
       case 2:
          panel1.DockPadding.Bottom = 10;
          button1.Text = "Bottom";
          break;
       case 3:
          panel1.DockPadding.Left = 10;
          button1.Text = "Left";
          break;
       case 4:
          panel1.DockPadding.Right = 10;
          button1.Text = "Right";
          break;
       case 5:
          panel1.DockPadding.All = 20;
          button1.Text = "All";
          break;
    }
    
    // Increment the counter.
    myCounter += 1;
 }
 
// </Snippet1>
}
