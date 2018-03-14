Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected dataSet As DataSet
    Protected dataGrid As DataGrid
    
' <Snippet1>
 Public Sub DisplayOdbcErrorCollection(exception As OdbcException)
     Dim i As Integer

     For i = 0 To exception.Errors.Count - 1
         MessageBox.Show("Index #" + i.ToString() + ControlChars.Cr _
            + "Message: " + exception.Errors(i).Message + ControlChars.Cr _
            + "Native: " + exception.Errors(i).NativeError.ToString() + ControlChars.Cr _
            + "Source: " + exception.Errors(i).Source + ControlChars.Cr _
            + "SQL: " + exception.Errors(i).SQLState + ControlChars.Cr)
     Next i
 End Sub
' </Snippet1>
End Class

