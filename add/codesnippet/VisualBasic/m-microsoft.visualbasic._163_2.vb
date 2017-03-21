    ' Test to see if a copy of Excel is already running.
    Private Sub testExcelRunning()
        On Error Resume Next
        ' GetObject called without the first argument returns a
        ' reference to an instance of the application. If the
        ' application is not already running, an error occurs.
        Dim excelObj As Object = GetObject(, "Excel.Application")
        If Err.Number = 0 Then
            MsgBox("Excel is running")
        Else
            MsgBox("Excel is not running")
        End If
        Err.Clear()
        excelObj = Nothing
    End Sub