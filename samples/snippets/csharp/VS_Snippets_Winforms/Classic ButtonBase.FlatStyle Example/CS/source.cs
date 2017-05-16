using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected Button button1;
// <Snippet1>
private void SetMyButtonProperties()
 {
    // Assign an image to the button.
    button1.Image = Image.FromFile("C:\\Graphics\\MyBitmap.bmp");
    // Align the image and text on the button.
    button1.ImageAlign = ContentAlignment.MiddleRight;    
    button1.TextAlign = ContentAlignment.MiddleLeft;
    // Give the button a flat appearance.
    button1.FlatStyle = FlatStyle.Flat;
 }
 
// </Snippet1>
}
