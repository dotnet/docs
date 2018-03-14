// <Snippet5>
using System;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

public class Example
{
   public static void Main()
   {
      ResourceManager rm = new ResourceManager("AppResources", typeof(Example).Assembly);
      Bitmap screen = (Bitmap) Image.FromStream(rm.GetStream("SplashScreen"));
      
      Form frm = new Form();
      frm.Size = new Size(300, 300);

      PictureBox pic = new PictureBox();
      pic.Bounds = frm.RestoreBounds;
      pic.BorderStyle = BorderStyle.Fixed3D; 
      pic.Image = screen;
      pic.SizeMode = PictureBoxSizeMode.StretchImage;

      frm.Controls.Add(pic);
      pic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                   AnchorStyles.Left | AnchorStyles.Right;

      frm.ShowDialog();
   }
}
// </Snippet5>
