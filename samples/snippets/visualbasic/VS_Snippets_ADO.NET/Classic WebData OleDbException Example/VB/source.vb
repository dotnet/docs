Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Public Sub ShowOleDbException()
     Dim mySelectQuery As String = "SELECT column1 FROM table1"
     Dim myConnection As New OleDbConnection _
        ("Provider=Microsoft.Jet.OLEDB.4.0;DataSource=")
     Dim myCommand As New OleDbCommand(mySelectQuery, myConnection)

     Try
         myCommand.Connection.Open()
     Catch e As OleDbException
         Dim errorMessages As String
         Dim i As Integer

         For i = 0 To e.Errors.Count - 1
             errorMessages += "Index #" & i.ToString() & ControlChars.Cr _
                            & "Message: " & e.Errors(i).Message & ControlChars.Cr _
                            & "NativeError: " & e.Errors(i).NativeError & ControlChars.Cr _
                            & "Source: " & e.Errors(i).Source & ControlChars.Cr _
                            & "SQLState: " & e.Errors(i).SQLState & ControlChars.Cr
         Next i

        Dim log As System.Diagnostics.EventLog = New System.Diagnostics.EventLog()
        log.Source = "My Application"
        log.WriteEntry(errorMessages)
        Console.WriteLine("An exception occurred. Please contact your system administrator.")
     End Try
 End Sub
' </Snippet1>
End Class

