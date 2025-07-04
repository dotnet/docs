using System;
//<Usings>
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
//</Usings>

namespace OfficeWalkthrough
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //<CreateAccount>
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
            //</CreateAccount>

            //<CallDisplay>
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
            //</CallDisplay>

            //<PasteIntoWord>
            CreateWordDocumentWithCleanup();
            //</PasteIntoWord>
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void CreateWordDocumentWithCleanup()
        {
            Word.Application wordApp = null;
            Word.Document document = null;
            
            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = true;
                document = wordApp.Documents.Add();
                wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
                
                // Save the document
                string fileName = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                    "BankAccountsLink.docx");
                document.SaveAs(fileName);
            }
            finally
            {
                // Clean up COM objects
                if (document != null)
                {
                    document.Close(true);
                    Marshal.FinalReleaseComObject(document);
                }
                if (wordApp != null)
                {
                    wordApp.Quit(true);
                    Marshal.FinalReleaseComObject(wordApp);
                }
            }
        }

        //<Display>
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
        //</Display>

        //<ProperCleanup>
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void CreateComObjectsAndCleanup()
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            
            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = workbook.ActiveSheet;
                
                // Use COM objects here...
            }
            finally
            {
                // Clean up COM objects in reverse order of creation
                if (worksheet != null)
                {
                    Marshal.FinalReleaseComObject(worksheet);
                }
                if (workbook != null)
                {
                    workbook.Close(true);
                    Marshal.FinalReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.FinalReleaseComObject(excelApp);
                }
            }
        }
        //</ProperCleanup>

        //<DisplayWithCleanup>
        void DisplayInExcelWithCleanup(IEnumerable<Account> accounts,
                   Action<Account, Excel.Range> DisplayFunc)
        {
            DisplayInExcelCore(accounts, DisplayFunc);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        void DisplayInExcelCore(IEnumerable<Account> accounts,
                   Action<Account, Excel.Range> DisplayFunc)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            
            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = true;
                
                // Add a new Excel workbook.
                workbook = excelApp.Workbooks.Add();
                worksheet = workbook.ActiveSheet;
                
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Balance";
                
                int row = 2;
                foreach (var ac in accounts)
                {
                    var cell = worksheet.Cells[row, 1];
                    DisplayFunc(ac, cell);
                    row++;
                }
                
                // Save the workbook
                string fileName = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                    "BankAccounts.xlsx");
                workbook.SaveAs(fileName);
                
                // Copy the results to the Clipboard.
                worksheet.Range["A1:B3"].Copy();
            }
            finally
            {
                // Always clean up COM objects in reverse order of creation
                if (worksheet != null)
                {
                    Marshal.FinalReleaseComObject(worksheet);
                }
                if (workbook != null)
                {
                    workbook.Close(true); // Save changes
                    Marshal.FinalReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.FinalReleaseComObject(excelApp);
                }
            }
        }
        //</DisplayWithCleanup>


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

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

            //<AutoFit>
            excelApp.Columns[1].AutoFit();
            excelApp.Columns[2].AutoFit();
            //</AutoFit>

            //<IndexedProperties>
            // Visual C# 2010 provides indexed properties for COM programming.
            excelApp.Range["A1"].Value = "ID";
            excelApp.ActiveCell.Offset[1, 0].Select();
            //</IndexedProperties>
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
