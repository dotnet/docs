'<Snippet2>
' Add Option Strict Off to the top of your program.
Option Strict Off
'</Snippet2>

Public Class Class1

    '******************************************************************************
    '<Snippet4>
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
    '</Snippet4>
    '<Snippet5>
    Private Sub getExcel()
        Dim fileName As String = "c:\vb\test.xls"

        If Not My.Computer.FileSystem.FileExists(fileName) Then
            MsgBox(fileName & " does not exist")
            Exit Sub
        End If

        ' Set the object variable to refer to the file you want to use.
        Dim excelObj As Object = GetObject(fileName)
        ' Show Excel through its Application property. 
        excelObj.Application.Visible = True
        ' Show the window containing the file.
        Dim winCount As Integer = excelObj.Parent.Windows.Count()
        excelObj.Parent.Windows(winCount).Visible = True

        ' Insert additional code to manipulate the test.xls file here.
        ' ...

        excelObj = Nothing
    End Sub
    '</Snippet5>


    '*************************************************************************
    '<Snippet1>
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
    '</Snippet1>


End Class



'******************************************************************************
Namespace Microsoft.Office.Interop.Excel

    '******************************************************************
    Public Class Application

        Private _Visible As Boolean
        Public Property Visible() As Boolean
            Get
                Return _Visible
            End Get
            Set(ByVal value As Boolean)
                _Visible = value
            End Set
        End Property


        Private _Workbooks As Workbooks
        Public ReadOnly Property Workbooks() As Workbooks
            Get
                Return _Workbooks
            End Get
        End Property

    End Class


    '******************************************************************
    Public Class Range
        Default Public Property Item(ByVal RowIndex As Object, ByVal ColumnIndex As Object) As Object
            Get
                Return New Object
            End Get
            Set(ByVal value As Object)

            End Set
        End Property
    End Class


    '******************************************************************
    Public Class Worksheet
        Dim _Application As Application
        Public ReadOnly Property Application() As Application
            Get
                Return _Application
            End Get
        End Property

        Public Sub SaveAs(ByVal Filename As String, Optional ByVal FileFormat As Object = Nothing, Optional ByVal Password As Object = Nothing, Optional ByVal WriteResPassword As Object = Nothing, Optional ByVal ReadOnlyRecommended As Object = Nothing, Optional ByVal CreateBackup As Object = Nothing, Optional ByVal AddToMru As Object = Nothing, Optional ByVal TextCodepage As Object = Nothing, Optional ByVal TextVisualLayout As Object = Nothing, Optional ByVal Local As Object = Nothing)
        End Sub

        Private _Cells As Range
        Public ReadOnly Property Cells() As Range
            Get
                Return _Cells
            End Get
        End Property
    End Class


    '******************************************************************
    Public Class Worksheets
        Public Function Add(Optional ByVal Before As Object = Nothing, Optional ByVal After As Object = Nothing, Optional ByVal Count As Object = Nothing, Optional ByVal Type As Object = Nothing) As Object
            Return New Object
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Object) As Object
            Get
                Return New Object
            End Get
        End Property
    End Class


    '******************************************************************
    Public Class Workbook
        Private _Worksheets As Worksheets
        Public ReadOnly Property Worksheets() As Worksheets
            Get
                Return _Worksheets
            End Get
        End Property
    End Class


    '******************************************************************
    Public Class Workbooks

        Public Sub Close()
        End Sub

        Public Function Add(Optional ByVal Template As Object = Nothing) As Workbook
            Return New Workbook
        End Function

        Public Function Open(ByVal Filename As String, Optional ByVal UpdateLinks As Object = Nothing, Optional ByVal oReadOnly As Object = Nothing, Optional ByVal Format As Object = Nothing, Optional ByVal Password As Object = Nothing, Optional ByVal WriteResPassword As Object = Nothing, Optional ByVal IgnoreReadOnlyRecommended As Object = Nothing, Optional ByVal Origin As Object = Nothing, Optional ByVal Delimiter As Object = Nothing, Optional ByVal Editable As Object = Nothing, Optional ByVal Notify As Object = Nothing, Optional ByVal Converter As Object = Nothing, Optional ByVal AddToMru As Object = Nothing, Optional ByVal Local As Object = Nothing, Optional ByVal CorruptLoad As Object = Nothing) As Workbook
            Return New Workbook
        End Function

        Dim _Application As Application
        Public ReadOnly Property Application() As Application
            Get
                Return _Application
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get

            End Get
        End Property

        Public ReadOnly Property Item(ByVal Index As Object) As Workbook
            Get
                Return New Workbook
            End Get
        End Property

    End Class
End Namespace
