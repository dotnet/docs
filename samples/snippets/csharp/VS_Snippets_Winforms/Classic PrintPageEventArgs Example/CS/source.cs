using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;

    public Form1() 
    {
       
    }

PrintDocument pd = new PrintDocument();
// <Snippet1>

// Specifies what happens when the user clicks the Button.
 private void printButton_Click(object sender, EventArgs e) 
 {
   try 
   {
     // Assumes the default printer.
     pd.Print();
   }  
   catch(Exception ex) 
   {
     MessageBox.Show("An error occurred while printing", ex.ToString());
   }
 }
 
 // Specifies what happens when the PrintPage event is raised.
 private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
 {      
   // Draw a picture.
   ev.Graphics.DrawImage(Image.FromFile("C:\\My Folder\\MyFile.bmp"), ev.Graphics.VisibleClipBounds);
      
   // Indicate that this is the last page to print.
   ev.HasMorePages = false;
 }

    
// </Snippet1>

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
        Application.EnableVisualStyles();
    }
 
}
