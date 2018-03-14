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
    
    
    
' <Snippet1>
Private Sub AddTimeStamp()
    'Create a new DataTable.
    Dim table As New DataTable("NewTable")

    'Get its PropertyCollection.
    Dim properties As PropertyCollection = table.ExtendedProperties

    'Add a timestamp value to the PropertyCollection.
    properties.Add("TimeStamp", DateTime.Now)

    'Print the timestamp.
    Console.WriteLine(properties("TimeStamp"))
End Sub 
' </Snippet1>
End Class 'Form1 
