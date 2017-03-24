//
using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
//<snippet1>
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
//</snippet1>
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace OfficeWalkthroughCS
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //<snippet3>
            var bankAccounts = new List<Account> 
            {
                new Account 
                {
                    ID = 345,
                    Balance = 541.27
                },
                new Account 
                {
                    ID = 123,
                    Balance = -127.44
                }
            };
            //</snippet3>

            //<snippet9>
            DisplayInExcel(bankAccounts, (account, cell) =>
            // This multiline lambda expression sets custom processing rules  
            // for the bankAccounts.
            {
                cell.Value = account.ID;
                cell.Offset[0, 1].Value = account.Balance;
                if (account.Balance < 0)
                {
                    cell.Interior.Color = 255;
                    cell.Offset[0, 1].Interior.Color = 255;
                }
            });
            //</snippet9>

            //<snippet10>
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
            //</snippet10>

        }

        //<snippet4>
        void DisplayInExcel(IEnumerable<Account> accounts,
                   Action<Account, Excel.Range> DisplayFunc)
        {
            var excelApp = this.Application;
            // Add a new Excel workbook.
            excelApp.Workbooks.Add();
            excelApp.Visible = true;
            excelApp.Range["A1"].Value = "ID";
            excelApp.Range["B1"].Value = "Balance";
            excelApp.Range["A2"].Select();

            foreach (var ac in accounts)
            {
                DisplayFunc(ac, excelApp.ActiveCell);
                excelApp.ActiveCell.Offset[1, 0].Select();
            }
            // Copy the results to the Clipboard.
            excelApp.Range["A1:B3"].Copy();
        }
        //</snippet4>



        void Pieces(IEnumerable<Account> accounts,
                   Action<Account, Excel.Range> DisplayFunc)
        {
            var excelApp = this.Application;
            // Add a new Excel workbook.
            excelApp.Workbooks.Add();
            excelApp.Visible = true;
            excelApp.Range["A1"].Value = "ID";
            excelApp.Range["B1"].Value = "Balance";
            excelApp.Range["A2"].Select();

            foreach (var ac in accounts)
            {
                DisplayFunc(ac, excelApp.ActiveCell);
                excelApp.ActiveCell.Offset[1, 0].Select();
            }
            // Copy the results to the Clipboard.
            excelApp.Range["A1:B3"].Copy();

            //<snippet7>
            excelApp.Columns[1].AutoFit();
            excelApp.Columns[2].AutoFit();
            //</snippet7>

            //<snippet5>
            // Visual C# 2010 provides indexed properties for COM programming.
            excelApp.Range["A1"].Value = "ID";
            excelApp.ActiveCell.Offset[1, 0].Select();
            //</snippet5>

            //<snippet6>
            // In Visual C# 2008, you cannot access the Range, Offset, and Value
            // properties directly.
            excelApp.get_Range("A1").Value2 = "ID";
            excelApp.ActiveCell.get_Offset(1, 0).Select();
            //</snippet6>

            //<snippet8>
            // Casting is required in Visual C# 2008.
            ((Excel.Range)excelApp.Columns[1]).AutoFit();

            // Casting is not required in Visual C# 2010.
            excelApp.Columns[1].AutoFit();
            //</snippet8>

            var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();

            //<snippet11>
            // Call to PasteSpecial in Visual C# 2008.
            object iconIndex = Type.Missing;
            object link = true;
            object placement = Type.Missing;
            object displayAsIcon = true;
            object dataType = Type.Missing;
            object iconFileName = Type.Missing;
            object iconLabel = Type.Missing;
            wordApp.Selection.PasteSpecial(ref iconIndex,
                                           ref link,
                                           ref placement,
                                           ref displayAsIcon,
                                           ref dataType,
                                           ref iconFileName,
                                           ref iconLabel);

            // Call to PasteSpecial in Visual C# 2010.
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
            //</snippet11>

            // Snippets 12 and 13 are from Using Type dynamic.
            //<snippet12>
            // Before the introduction of dynamic.
            ((Excel.Range)excelApp.Cells[1, 1]).Value2 = "Name";
            Excel.Range range2008 = (Excel.Range)excelApp.Cells[1, 1];
            //</snippet12>

            //<snippet13>
            // After the introduction of dynamic, the access to the Value property and
            // the conversion to Excel.Range are handled by the run-time COM binder.
            excelApp.Cells[1, 1].Value = "Name";
            Excel.Range range2010 = excelApp.Cells[1, 1];
            //</snippet13>
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}

