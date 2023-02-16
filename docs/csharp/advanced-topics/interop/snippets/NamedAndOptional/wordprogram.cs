//
//<Snippet12>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//<Snippet4>
using Word = Microsoft.Office.Interop.Word;
//</Snippet4>

namespace OfficeHowTo
{
    class WordProgram
    {
        static void Main(string[] args)
        {
            //<Snippet8>
            DisplayInWord();
            //</Snippet8>
        }

        static void DisplayInWord()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            // docs is a collection of all the Document objects currently
            // open in Word.
            Word.Documents docs = wordApp.Documents;

            // Add a document to the collection and name it doc.
            Word.Document doc = docs.Add();

            //<Snippet7>
            // Define a range, a contiguous area in the document, by specifying
            // a starting and ending character position. Currently, the document
            // is empty.
            Word.Range range = doc.Range(0, 0);

            // Use the InsertAfter method to insert a string at the end of the
            // current range.
            range.InsertAfter("Testing, testing, testing. . .");
            //</Snippet7>

            // You can comment out any or all of the following statements to
            // see the effect of each one in the Word document.

            // Next, use the ConvertToTable method to put the text into a table.
            // The method has 16 optional parameters. You only have to specify
            // values for those you want to change.

            //<Snippet9>
            // Convert to a simple table. The table will have a single row with
            // three columns.
            range.ConvertToTable(Separator: ",");
            //</Snippet9>

            // Change to a single column with three rows..
            //<Snippet10>
            range.ConvertToTable(Separator: ",", AutoFit: true, NumColumns: 1);
            //</Snippet10>

            // Format the table.
            //<Snippet11>
            range.ConvertToTable(Separator: ",", AutoFit: true, NumColumns: 1,
                Format: Word.WdTableFormat.wdTableFormatElegant);
            //</Snippet11>
        }
    }
}
//</Snippet12>

namespace Parts
{
    class Parts
    {
        //<Snippet6>
        static void DisplayInWord()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            // docs is a collection of all the Document objects currently
            // open in Word.
            Word.Documents docs = wordApp.Documents;

            // Add a document to the collection and name it doc.
            Word.Document doc = docs.Add();
        }
        //</Snippet6>

        static void VS2008()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            // docs is a collection of all the Document objects currently
            // open in Word.
            Word.Documents docs = wordApp.Documents;

            // Add a document to the collection and name it doc.
            object useDefaultVal = Type.Missing;
            Word.Document doc = docs.Add(ref useDefaultVal, ref useDefaultVal,
                ref useDefaultVal, ref useDefaultVal);

            object n = 0;
            Word.Range range = doc.Range(ref n, ref n);

            range.InsertAfter("Testing, testing, testing. . .");
        }
    }
}
