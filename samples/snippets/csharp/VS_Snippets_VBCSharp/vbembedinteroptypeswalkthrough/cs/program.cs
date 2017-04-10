//<Snippet1>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace CreateExcelWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = {4, 6, 18, 2, 1, 76, 0, 3, 11};

            CreateWorkbook(values, @"C:\SampleFolder\SampleWorkbook.xls");
        }

        static void CreateWorkbook(int[] values, string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook wkbk;
            Excel.Worksheet sheet;
            
            try
            {
                    // Start Excel and create a workbook and worksheet.
                    excelApp = new Excel.Application();
                    wkbk = excelApp.Workbooks.Add();
                    sheet = wkbk.Sheets.Add() as Excel.Worksheet;
                    sheet.Name = "Sample Worksheet";

                    // Write a column of values.
                    // In the For loop, both the row index and array index start at 1.
                    // Therefore the value of 4 at array index 0 is not included.
                    for (int i = 1; i < values.Length; i++)
                    {
                        sheet.Cells[i, 1] = values[i];
                    }

                    // Suppress any alerts and save the file. Create the directory 
                    // if it does not exist. Overwrite the file if it exists.
                    excelApp.DisplayAlerts = false;
                    string folderPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    wkbk.SaveAs(filePath);
            }
            catch
            {
            }
            finally
            {
                sheet = null;
                wkbk = null;
                
                // Close Excel.
                excelApp.Quit();
                excelApp = null;
            }
        }
    }
}
//</Snippet1>