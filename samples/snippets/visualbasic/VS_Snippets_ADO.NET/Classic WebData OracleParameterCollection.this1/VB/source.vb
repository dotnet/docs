Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    Protected parameters As OracleParameterCollection
    
    
    ' <Snippet1>
    Public Sub SearchOracleParams()
        ' ...
        ' create OracleParameterCollection parameters
        ' ...
        If Not parameters.Contains("DName") Then
            Console.WriteLine("ERROR: no such parameter in the collection")
        Else
            Console.WriteLine("Name: " & parameters("DName").ToString() & _
                "Index: " & parameters.IndexOf("DName").ToString())
        End If
    End Sub 
    ' </Snippet1>
End Class 'Form1 
