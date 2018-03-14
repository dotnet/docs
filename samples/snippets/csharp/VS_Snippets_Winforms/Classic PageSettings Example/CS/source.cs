using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

public class Sample {

    protected StreamReader streamToPrint;
    protected Font printFont;
    protected string filePath;
    protected string printer;

// <Snippet1>
public void Printing() {
   try {
     streamToPrint = new StreamReader (filePath);
     try {
       printFont = new Font("Arial", 10);
       PrintDocument pd = new PrintDocument(); 
       pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
       pd.PrinterSettings.PrinterName = printer;
       // Set the page orientation to landscape.
       pd.DefaultPageSettings.Landscape = true;
       pd.Print();
     } 
     finally {
       streamToPrint.Close() ;
     }
   } 
   catch(Exception ex) { 
     MessageBox.Show(ex.Message);
   }
 }
 
// </Snippet1>

 // Method added so sample will compile
 private void pd_PrintPage(object sender,
   PrintPageEventArgs e) {

 }
}
