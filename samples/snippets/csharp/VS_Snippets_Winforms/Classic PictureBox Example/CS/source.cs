using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected PictureBox pictureBox1;
// <Snippet1>
 private Bitmap MyImage ;
 public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
 {
    // Sets up an image object to be displayed.
    if (MyImage != null)
    {
       MyImage.Dispose();
    }
 
    // Stretches the image to fit the pictureBox.
    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage ;
    MyImage = new Bitmap(fileToDisplay);
    pictureBox1.ClientSize = new Size(xSize, ySize);
    pictureBox1.Image = (Image) MyImage ;
 }
 
// </Snippet1>
}
