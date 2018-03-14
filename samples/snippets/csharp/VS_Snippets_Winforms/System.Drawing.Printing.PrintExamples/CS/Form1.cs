//<snippet0>
using System;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrintApp
{
    public class Form1 : Form
    {
        private Button printButton;
        //<snippet8>
        private PrintDocument printDocument1 = new PrintDocument();
        private string stringToPrint;
        //</snippet8>
        public Form1()
        {
            this.printButton = new System.Windows.Forms.Button();
            this.printButton.Location = new System.Drawing.Point(12, 51);
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.printButton);
            
            // Associate the PrintPage event handler with the PrintPage event.
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
        }
      
        private void ReadFile()
        {
            //<snippet1>
            string docName = "testPage.txt";
            string docPath = @"c:\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                stringToPrint = reader.ReadToEnd();
            }
            //</snippet1>
        }
       
        //<snippet2>
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
        }
        //</snippet2>

        private void printButton_Click(object sender, EventArgs e)
        {
            ReadFile();
            //<snippet5>
            printDocument1.Print();
            //</snippet5>
        }
      
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
//</snippet0>