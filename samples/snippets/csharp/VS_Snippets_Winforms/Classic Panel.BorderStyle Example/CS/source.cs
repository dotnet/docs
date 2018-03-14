using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
 public void CreateMyPanel()
 {
    Panel panel1 = new Panel();
    
    // Initialize the Panel control.
    panel1.Location = new Point(56,72);
    panel1.Size = new Size(264, 152);
    // Set the Borderstyle for the Panel to three-dimensional.
    panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
 }
 
// </Snippet1>
}
