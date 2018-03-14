using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class Sample : Form {

    protected StreamReader streamToPrint;
    protected string filePath;
    protected string printer;
    protected Font printFont;

// <Snippet1>
 public void Printing()
 {
   try 
   {
     /* This assumes that a variable of type string, named filePath,
        has been set to the path of the file to print. */
     streamToPrint = new StreamReader (filePath);
     try 
     {
       printFont = new Font("Arial", 10);
       PrintDocument pd = new PrintDocument(); 
       /* This assumes that a method, named pd_PrintPage, has been
          defined. pd_PrintPage handles the PrintPage event. */
       pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
       /* This assumes that a variable of type string, named 
          printer, has been set to the printer's name. */
       pd.PrinterSettings.PrinterName = printer;
       // Create a new instance of Margins with one inch margins.
       Margins margins = new Margins(100,100,100,100);
       pd.DefaultPageSettings.Margins = margins;
       pd.Print();
     } 
     finally 
     {
       streamToPrint.Close() ;
     }
   } 
   catch(Exception ex) 
   { 
     MessageBox.Show("An error occurred printing the file - " + ex.Message);
   }
 }
 
// </Snippet1>

 private void pd_PrintPage(object sender, PrintPageEventArgs e) {

 }

}
