using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//<Snippet1>
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
//</Snippet1>

namespace OfficeProgrammingWalkthrough
{
    class Program
    {
        static void Main(string[] args)
        {
            //<Snippet3>
            // Create a list of accounts.
            var bankAccounts = new List<Account> {
                new Account {
                              ID = 345678,
                              Balance = 541.27
                            },
                new Account {
                              ID = 1230221,
                              Balance = -127.44
                            }
            };
            //</Snippet3>

            //<Snippet8>
            // Display the list in an Excel spreadsheet.
            DisplayInExcel(bankAccounts);
            //</Snippet8>

            //<Snippet11>
            // Create a Word document that contains an icon that links to
            // the spreadsheet.
            CreateIconInWordDoc();
            //</Snippet11>
        }

        //<Snippet4>
        static void DisplayInExcel(IEnumerable<Account> accounts)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a particular template.
            // Because no argument is sent in this example, Add creates a new workbook.
            excelApp.Workbooks.Add();

            // This example uses a single workSheet. The explicit type casting is
            // removed in a later procedure.
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
        }
        //</Snippet4>

        //<Snippet9>
        static void CreateIconInWordDoc()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four reference parameters, all of which are
            // optional. Visual C# allows you to omit arguments for them if
            // the default values are what you want.
            wordApp.Documents.Add();

            // PasteSpecial has seven reference parameters, all of which are
            // optional. This example uses named arguments to specify values
            // for two of the parameters. Although these are reference
            // parameters, you do not need to use the ref keyword, or to create
            // variables to send in as arguments. You can send the values directly.
            wordApp.Selection.PasteSpecial( Link: true, DisplayAsIcon: true);
        }
        //</Snippet9>

        //<Snippet10>
        static void CreateIconInWordDoc2008()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four parameters, all of which are optional.
            // In Visual C# 2008 and earlier versions, an argument has to be sent
            // for every parameter. Because the parameters are reference
            // parameters of type object, you have to create an object variable
            // for the arguments that represents 'no value'.

            object useDefaultValue = Type.Missing;

            wordApp.Documents.Add(ref useDefaultValue, ref useDefaultValue,
                ref useDefaultValue, ref useDefaultValue);

            // PasteSpecial has seven reference parameters, all of which are
            // optional. In this example, only two of the parameters require
            // specified values, but in Visual C# 2008 an argument must be sent
            // for each parameter. Because the parameters are reference parameters,
            // you have to contruct variables for the arguments.
            object link = true;
            object displayAsIcon = true;

            wordApp.Selection.PasteSpecial( ref useDefaultValue,
                                            ref link,
                                            ref useDefaultValue,
                                            ref displayAsIcon,
                                            ref useDefaultValue,
                                            ref useDefaultValue,
                                            ref useDefaultValue);
        }
        //</Snippet10>

        static void Parts()
        {
            var excelApp = new Excel.Application();
            excelApp.Workbooks.Add();

            //<Snippet17>
            // The AutoFormat method has seven optional value parameters. The
            // following call specifies a value for the first parameter, and uses
            // the default values for the other six.

            // Call to AutoFormat in Visual C# 2008. This code is not part of the
            // current solution.
            excelApp.get_Range("A1", "B4").AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatTable3,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing);
            //</Snippet17>
        }

        static void DisplayInExcelFull(IEnumerable<Account> accounts)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned
            // by property Workbooks. The new workbook becomes the active workbook.
            // Add has an optional parameter for specifying a particular template.
            // Because no argument is sent in this example, Add creates a new workbook.
            excelApp.Workbooks.Add();

            // This example uses a single workSheet.
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            //<Snippet5>
            // Establish column headings in cells A1 and B1.
            workSheet.Cells[1, "A"] = "ID Number";
            workSheet.Cells[1, "B"] = "Current Balance";
            //</Snippet5>

            //<Snippet6>
            // Establish column headings. Both parameters must be supplied in
            // Visual C# 2008 or earlier versions.
            //workSheet.get_Range("A1", Type.Missing).Value2 = "ID Number";
            //workSheet.get_Range("B1", Type.Missing).Value2 = "Current Balance";
            // Move to the next row.
            //workSheet.get_Range("A2", Type.Missing).Select();
            //</Snippet6>

            //<Snippet7>

            var row = 1;
            foreach (var acct in accounts)
            {
                row++;
                workSheet.Cells[row, "A"] = acct.ID;
                workSheet.Cells[row, "B"] = acct.Balance;
            }
            //</Snippet7>

            // Columns returns a Range object that represents all the columns
            // on the active worksheet. AutoFit fits the width of the columns
            // to their content.
            //ExcelApp.Columns.AutoFit();

            //<Snippet13>
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
            //</Snippet13>

            //<Snippet14>
            ((Excel.Range)workSheet.Columns[1]).AutoFit();
            ((Excel.Range)workSheet.Columns[2]).AutoFit();
            //</Snippet14>

            //<Snippet15>
            // Call to AutoFormat in Visual C# 2010.
            workSheet.Range["A1", "B3"].AutoFormat(
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            //</Snippet15>

            //<Snippet16>
            // Call to AutoFormat in Visual C# 2010.
            workSheet.Range["A1", "B3"].AutoFormat(Format:
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            //</Snippet16>

            //<Snippet12>
            // Put the spreadsheet contents on the clipboard. The Copy method has one
            // optional parameter for specifying a destination. Because no argument
            // is sent, the destination is the Clipboard.
            workSheet.Range["A1:B3"].Copy();
            //</Snippet12>

            //ExcelApp.get_Range("A5:C6").PasteSpecial( Transpose: true);
            //dynamic val = Type.Missing;
            //ExcelApp.get_Range("A5:C6").PasteSpecial(val, val, val, Transpose: true);
            //ExcelApp.get_Range("A5:C6").Copy();
        }

        // These examples are in Named and Optional, main topic. Can be deleted here.
        static void TestExcelCom()
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            var myFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1;

            // Using named and optional arguments, you can supply arguments for
            // only the parameters for which you do not want to use the default
            // value, and omit arguments for the other parameters. In the following
            // call, a value is sent for only one parameter.
            excelApp.get_Range("A1", "B4").AutoFormat( Format: myFormat );

            // In Visual C# 2008 and earlier versions, you need to supply an argument for
            // every parameter. The following call supplies a value for the first
            // parameter, and sends a placeholder value for the other six. The
            // default values are used for those parameters.
            excelApp.get_Range("A1", "B4").AutoFormat(myFormat, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
    }

    //<Snippet2>
    public class Account
    {
        public int ID { get; set; }
        public double Balance { get; set; }
    }
    //</Snippet2>
}
