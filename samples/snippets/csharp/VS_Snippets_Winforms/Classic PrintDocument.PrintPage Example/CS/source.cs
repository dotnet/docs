
// <Snippet1>
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

 public class PrintingExample 
 {
     private Font printFont;
     private StreamReader streamToPrint;
     static string filePath;
 
 
     public PrintingExample() 
     {
         Printing();
     }
 
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
 
     // Print the file.
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
               // Print the document.
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
   
     // This is the main entry point for the application.
     public static void Main(string[] args) 
     {
        string sampleName = Environment.GetCommandLineArgs()[0];
        if(args.Length != 1)
        {
           Console.WriteLine("Usage: " + sampleName +" <file path>");
           return;
        }
        filePath = args[0];
        new PrintingExample();
     }
 }
 
// </Snippet1>
