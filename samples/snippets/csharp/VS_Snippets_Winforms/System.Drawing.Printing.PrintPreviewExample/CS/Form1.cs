//<snippet0>
using System;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrintPreviewApp
{
    public partial class Form1 : Form
    {
        private Button printPreviewButton;

        //<snippet1>
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        // Declare a string to hold the entire document contents.
        private string documentContents;

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;
        //</snippet1>

        public Form1()
        {
            this.printPreviewButton = new System.Windows.Forms.Button();
            this.printPreviewButton.Location = new System.Drawing.Point(12, 12);
            this.printPreviewButton.Size = new System.Drawing.Size(125, 23);
            this.printPreviewButton.Text = "Print Preview";
            this.printPreviewButton.Click += new System.EventHandler(this.printPreviewButton_Click);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.printPreviewButton);
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
        }
        //<snippet2>
        private void ReadDocument()
        {
            string docName = "testPage.txt";
            string docPath = @"c:\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }
        //</snippet2>

        //<snippet3>
        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }
        //</snippet3>
        //<snippet4>
        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            ReadDocument();
    	    //<snippet5>
            printPreviewDialog1.Document = printDocument1;
            //</snippet5>
	    printPreviewDialog1.ShowDialog();
            
        }
        //</snippet4>

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