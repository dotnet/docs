Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid

    ' <Snippet1>
    Public Sub CreateParamCollection(command As OleDbCommand)
        Dim paramCollection As OleDbParameterCollection = _
            command.Parameters
        paramCollection.Add("@CategoryName", OleDbType.Char)
        paramCollection.Add("@Description", OleDbType.Char)
        paramCollection.Add("@Picture", OleDbType.Binary)
        Dim parameterNames As String = ""
        For i As Integer = 0 To paramCollection.Count - 1
            parameterNames += paramCollection(i).ToString() & _
                ControlChars.Cr
        Next
        Console.WriteLine(parameterNames)
        paramCollection.Clear()
    End Sub 
    ' </Snippet1>
End Class
