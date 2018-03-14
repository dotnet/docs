using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class Form1: Form
{
 protected string printer;

     private Font printFont;
     private StreamReader streamToPrint;
     protected string filePath;
 
// <Snippet1>
 public void Printing()
 {
    try
    {
       streamToPrint = new StreamReader (filePath);
       try
       {
          printFont = new Font("Arial", 10);
          PrintDocument pd = new PrintDocument(); 
          pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
          pd.PrinterSettings.PrinterName = printer;
          // Set the page orientation to landscape.
          pd.DefaultPageSettings.Landscape = true;
          pd.Print();
       } 
       finally
       {
          streamToPrint.Close() ;
       }
    } 
    catch(Exception ex)
    { 
       MessageBox.Show(ex.Message);
    }
 }
 
// </Snippet1>
 
     // The PrintPage event is raised for each page to be printed.
     private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
     {
         float linesPerPage = 0;
         float yPos =  0;
         int count = 0;
         float leftMargin = ev.MarginBounds.Left;
         float topMargin = ev.MarginBounds.Top;
         String line=null;
             
         // Calculate the number of lines per page.
         linesPerPage = ev.MarginBounds.Height  / 
            printFont.GetHeight(ev.Graphics) ;
 
         // Iterate over the file, printing each line.
         while (count < linesPerPage && 
            ((line=streamToPrint.ReadLine()) != null)) 
         {
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString (line, printFont, Brushes.Black, 
               leftMargin, yPos, new StringFormat());
            count++;
         }
 
         // If more lines exist, print another page.
         if (line != null) 
            ev.HasMorePages = true;
         else 
            ev.HasMorePages = false;
     }
}
