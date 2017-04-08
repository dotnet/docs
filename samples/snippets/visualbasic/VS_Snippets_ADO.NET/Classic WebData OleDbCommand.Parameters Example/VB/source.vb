Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports Microsoft.VisualBasic

Public Class Form1

    
' <Snippet1>
 Public Sub CreateMyOleDbCommand(connection As OleDbConnection, _
    queryString As String, parameters() As OleDbParameter)

     Dim command As New OleDbCommand(queryString, connection)
     command.CommandText = _
        "SELECT CustomerID, CompanyName FROM Customers WHERE Country = ? AND City = ?"
     command.Parameters.Add(parameters)

     Dim j As Integer
     For j = 0 To command.Parameters.Count - 1
        command.Parameters.Add(parameters(j))
     Next j

     Dim message As String = ""
     Dim i As Integer
     For i = 0 To command.Parameters.Count - 1
         message += command.Parameters(i).ToString() + ControlChars.Cr
     Next i
     Console.WriteLine(message)
 End Sub
' </Snippet1>
End Class
