// Snippets 5000 Note:  
// The container used for building our samples doesn't include the Office assemblies.
// This sample will generate a few errors in the CI build. Those are expected,
// so the build passes.
//
// If you update this sample, make sure to build it locally.
// Then, make sure no new errors are added.

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
