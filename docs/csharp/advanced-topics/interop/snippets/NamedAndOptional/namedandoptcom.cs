//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamedAndOptionalSnippets
{
    class NamedAndOptCOM
    {
        static void Main()
        {
            TestCOM();
        }

        static void TestCOM()
        {
            //<Snippet13>
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            excelApp.Visible = true;

            var myFormat =
                Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1;

            excelApp.Range["A1", "B4"].AutoFormat( Format: myFormat );
            //</Snippet13>
        }
    }
}
