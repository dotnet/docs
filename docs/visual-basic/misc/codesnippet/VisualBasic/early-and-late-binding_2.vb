    ' To use this example, you must have Microsoft Excel installed on your computer.
    ' Compile with Option Strict Off to allow late binding.
    Sub TestLateBinding()
        Dim xlApp As Object
        Dim xlBook As Object
        Dim xlSheet As Object
        xlApp = CreateObject("Excel.Application")
        ' Late bind an instance of an Excel workbook.
        xlBook = xlApp.Workbooks.Add
        ' Late bind an instance of an Excel worksheet.
        xlSheet = xlBook.Worksheets(1)
        xlSheet.Activate()
        ' Show the application.
        xlSheet.Application.Visible = True
        ' Place some text in the second row of the sheet.
        xlSheet.Cells(2, 2) = "This is column B row 2"
    End Sub