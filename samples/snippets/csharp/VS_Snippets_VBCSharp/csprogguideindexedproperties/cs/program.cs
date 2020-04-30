//<snippet5>
// You must add a reference to Microsoft.Office.Interop.Excel to run
// this example.
using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace IndexedProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharp2010();
            //CSharp2008();
        }

        static void CSharp2010()
        {
            var excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            excelApp.Visible = true;

            Excel.Range targetRange = excelApp.Range["A1"];
            targetRange.Value = "Name";
        }

        static void CSharp2008()
        {
            var excelApp = new Excel.Application();
            excelApp.Workbooks.Add(Type.Missing);
            excelApp.Visible = true;

            Excel.Range targetRange = excelApp.get_Range("A1", Type.Missing);
            targetRange.set_Value(Type.Missing, "Name");
            // Or
            //targetRange.Value2 = "Name";
        }
    }
}
//</snippet5>

namespace IndexedPieces
{
    class Pieces
    {
        public void Snippets2008()
        {
            //<snippet1>
            // Visual C# 2008 and earlier.
            var excelApp = new Excel.Application();
            // . . .
            Excel.Range targetRange = excelApp.get_Range("A1", Type.Missing);
            //</snippet1>

            //<snippet3>
            // Visual C# 2008.
            targetRange.set_Value(Type.Missing, "Name");
            // Or
            targetRange.Value2 = "Name";
            //</snippet3>
        }

        public void Snippets2010()
        {
            //<snippet2>
            // Visual C# 2010.
            var excelApp = new Excel.Application();
            // . . .
            Excel.Range targetRange = excelApp.Range["A1"];
            //</snippet2>

            //<snippet4>
            // Visual C# 2010.
            targetRange.Value = "Name";
            //</snippet4>
        }
    }
}
