//<Snippet2>
using System;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

public class CreateExcelWorksheet
{
    static void Main()
    {
        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

        if (xlApp == null)
        {
            Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");
            return;
        }
        xlApp.Visible = true;

        Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        Worksheet ws = (Worksheet)wb.Worksheets[1];

        if (ws == null)
        {
            Console.WriteLine("Worksheet could not be created. Check that your office installation and project references are correct.");
        }

        // Select the Excel cells, in the range c1 to c7 in the worksheet.
        Range aRange = ws.get_Range("C1", "C7");

        if (aRange == null)
        {
            Console.WriteLine("Could not get a range. Check to be sure you have the correct versions of the office DLLs.");
        }

        // Fill the cells in the C1 to C7 range of the worksheet with the number 6.
        Object[] args = new Object[1];
        args[0] = 6;
        aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);

        // Change the cells in the C1 to C7 range of the worksheet to the number 8.
        aRange.Value2 = 8;
    }
}
//</Snippet2>

//-----------------------------------------------------------------------------
namespace Microsoft.Office.Interop
{
  namespace Excel
  {
    public enum XlWBATemplate
    {
        xlWBATChart,
        xlWBATExcel4IntlMacroSheet,
        xlWBATExcel4MacroSheet,
        xlWBATWorksheet
    }

    //-------------------------------------------------------------------------
    class Application
    {
        private bool _Visible;
        public bool Visible
        {
            get{return _Visible;}
            set{_Visible = value;}
        }

        private Workbooks _Workbooks = new Workbooks();
        public Workbooks Workbooks
        {
            get{return _Workbooks;}
        }
    }

    //-------------------------------------------------------------------------
    class Range
    {
        private object _Value2;
        public object Value2
        {
            get{return _Value2;}
            set{_Value2 = value;}
        }
    }

    //-------------------------------------------------------------------------
    class Worksheet
    {
        Application _Application = new Application();
        public Application Application
        {
            get{return _Application;}
        }

        public void SaveAs(string Filename, object FileFormat, object Password, object WriteResPassword, object ReadOnlyRecommended, object CreateBackup, object AddToMru, object TextCodepage, object TextVisualLayout, object Local)
        {}

        private Range _Cells = new Range();
        public  Range Cells
        {
            get{return _Cells;}
        }

        public Range get_Range(object Cell1, object Cell2)
        {
            return new Range();
        }
    }

    //-------------------------------------------------------------------------
    class Worksheets
    {
        public object Add(object Before, object After, object Count, object Type)
        {
            return new Object();
        }

        public object this[int i]
        {
            get
            {
                return new Object();
            }
        }
    }

    //-------------------------------------------------------------------------
    class Workbook
    {
        private Worksheets _Worksheets = new Worksheets();
        public  Worksheets Worksheets
        {
            get{return _Worksheets;}
        }
    }

    //-------------------------------------------------------------------------
    class Workbooks
    {
        public void Close()
        {}

        public Workbook Add(object Template)
        {
            return new Workbook();
        }

        //public GetEnumerator() System.Collections.IEnumerator

        public Workbook Open(string Filename, object UpdateLinks, object oReadOnly, object Format, object Password, object WriteResPassword, object IgnoreReadOnlyRecommended, object Origin, object Delimiter, object Editable, object Notify, object Converter, object AddToMru, object Local, object CorruptLoad)
        {
            return new Workbook();
        }

        Application _Application = new Application();
        public  Application Application
        {
            get{return _Application;}
        }

        public int Count
        {
            get{return 1;}
        }

        public  Workbook Item
        {
            get{return new Workbook();}
        }

        //public  Property Parent() Object
    }
  }
}