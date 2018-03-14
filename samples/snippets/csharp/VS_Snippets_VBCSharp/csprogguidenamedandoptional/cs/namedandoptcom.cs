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
            //<Snippet3>
            // In C# 3.0 and earlier versions, you need to supply an argument for
            // every parameter. The following call specifies a value for the first
            // parameter, and sends a placeholder value for the other six. The
            // default values are used for those parameters.
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            excelApp.Visible = true;

            var myFormat = 
                Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1;

            excelApp.get_Range("A1", "B4").AutoFormat(myFormat, Type.Missing, 
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //</Snippet3>

            //<Snippet13>
            // The following code shows the same call to AutoFormat in C# 4.0. Only
            // the argument for which you want to provide a specific value is listed.
            excelApp.Range["A1", "B4"].AutoFormat( Format: myFormat );
            //</Snippet13>
        }
    }
}
