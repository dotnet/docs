Option Strict On
'<Snippet1>
Imports Excel = Microsoft.Office.Interop.Excel

Module Module1

    Sub Main()
        Dim values = {4, 6, 18, 2, 1, 76, 0, 3, 11}

        CreateWorkbook(values, "C:\SampleFolder\SampleWorkbook.xls")
    End Sub

    Sub CreateWorkbook(ByVal values As Integer(), ByVal filePath As String)
        Dim excelApp As Excel.Application = Nothing
        Dim wkbk As Excel.Workbook
        Dim sheet As Excel.Worksheet

        Try
            ' Start Excel and create a workbook and worksheet.
            excelApp = New Excel.Application
            wkbk = excelApp.Workbooks.Add()
            sheet = CType(wkbk.Sheets.Add(), Excel.Worksheet)
            sheet.Name = "Sample Worksheet"

            ' Write a column of values.
            ' In the For loop, both the row index and array index start at 1.
            ' Therefore the value of 4 at array index 0 is not included.
            For i = 1 To values.Length - 1
                sheet.Cells(i, 1) = values(i)
            Next

            ' Suppress any alerts and save the file. Create the directory 
            ' if it does not exist. Overwrite the file if it exists.
            excelApp.DisplayAlerts = False
            Dim folderPath = My.Computer.FileSystem.GetParentPath(filePath)
            If Not My.Computer.FileSystem.DirectoryExists(folderPath) Then
                My.Computer.FileSystem.CreateDirectory(folderPath)
            End If
            wkbk.SaveAs(filePath)
	Catch

        Finally
            sheet = Nothing
            wkbk = Nothing

            ' Close Excel.
            excelApp.Quit()
            excelApp = Nothing
        End Try

    End Sub
End Module
'</Snippet1>
