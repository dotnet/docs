using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected PictureBox pictureBox1;
 protected ScrollBar hScrollBar1, vScrollBar1;
// <Snippet1>
public void DisplayScrollBars()
 {
    // Display or hide the scroll bars based upon  
    // whether the image is larger than the PictureBox.
    if (pictureBox1.Width > pictureBox1.Image.Width)
    {
       hScrollBar1.Visible = false;
    }
    else
    {
       hScrollBar1.Visible = true;
    }
    
    if (pictureBox1.Height > pictureBox1.Image.Height)
    {
       vScrollBar1.Visible = false;
    }
    else
    {
       vScrollBar1.Visible = true;
    }
 }
 
// </Snippet1>
}
