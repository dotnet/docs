Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    Protected parameters As OleDbParameterCollection
    
    
    ' <Snippet1>
    Public Sub SearchParameters()
        ' ...
        ' create OleDbParameterCollection parameters
        ' ...
        If Not parameters.Contains("Description") Then
            Console.WriteLine("ERROR: no such parameter in the collection")
        Else
            Console.WriteLine("Name: " & parameters("Description").ToString() & _
                "Index: " & parameters.IndexOf("Description").ToString())
        End If
    End Sub 
    ' </Snippet1>
End Class 'Form1 
