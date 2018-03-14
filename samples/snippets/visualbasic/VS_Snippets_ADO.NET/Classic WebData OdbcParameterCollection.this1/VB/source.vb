Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    Protected parameterCollection As OdbcParameterCollection
    
    
    ' <Snippet1>
    Public Sub SearchParameters()
        ' ...
        ' create OdbcParameterCollection parameterCollection
        ' ...
        If Not parameterCollection.Contains("Description") Then
            Console.WriteLine("ERROR: no such parameter in the collection")
        Else
            Console.WriteLine("Name: " & parameterCollection("Description").ToString() & _
                "Index: " & parameterCollection.IndexOf("Description").ToString())
        End If
    End Sub 
    ' </Snippet1>
End Class 'Form1 
