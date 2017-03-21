    Sub TestExcel()
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet

        xlApp = CType(CreateObject("Excel.Application"), 
                    Microsoft.Office.Interop.Excel.Application)
        xlBook = CType(xlApp.Workbooks.Add, 
                    Microsoft.Office.Interop.Excel.Workbook)
        xlSheet = CType(xlBook.Worksheets(1), 
                    Microsoft.Office.Interop.Excel.Worksheet)

        ' The following statement puts text in the second row of the sheet.
        xlSheet.Cells(2, 2) = "This is column B row 2"
        ' The following statement shows the sheet.
        xlSheet.Application.Visible = True
        ' The following statement saves the sheet to the C:\Test.xls directory.
        xlSheet.SaveAs("C:\Test.xls")
        ' Optionally, you can call xlApp.Quit to close the workbook.
    End Sub