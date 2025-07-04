using System;
//<Usings>
using System.Collections.Generic;
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
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
            //</PasteIntoWord>
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
