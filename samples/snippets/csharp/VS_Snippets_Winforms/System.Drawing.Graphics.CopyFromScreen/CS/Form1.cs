//<snippet1>

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

public class Form1 :
    Form
{
    private Button printButton = new Button();
    private PrintDocument printDocument1 = new PrintDocument();

    public Form1()
    {
        printButton.Text = "Print Form";
        printButton.Click += new EventHandler(printButton_Click);
        printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        this.Controls.Add(printButton);
    }

    void printButton_Click(object sender, EventArgs e)
    {
        CaptureScreen();
        printDocument1.Print();
    }


    Bitmap memoryImage;

    private void CaptureScreen()
    {
        Graphics myGraphics = this.CreateGraphics();
        Size s = this.Size;
        memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
        Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
    }

    private void printDocument1_PrintPage(System.Object sender,  
           System.Drawing.Printing.PrintPageEventArgs e)
    {
        e.Graphics.DrawImage(memoryImage, 0, 0);
    }

  

    public static void Main()
    {
        Application.Run(new Form1());
    }
}
//</snippet1>


