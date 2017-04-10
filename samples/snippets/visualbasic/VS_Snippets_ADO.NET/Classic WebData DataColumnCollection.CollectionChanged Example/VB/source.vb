Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub AddEventHandler(table As DataTable)
     Dim columns As DataColumnCollection = table.Columns
     AddHandler columns.CollectionChanged, _
        AddressOf ColumnsCollection_Changed
 End Sub    
    
 Private Sub ColumnsCollection_Changed _
    (sender As Object, e As System.ComponentModel. _
    CollectionChangeEventArgs)

     Dim columns As DataColumnCollection = _
        CType(sender, DataColumnCollection)
     Console.WriteLine("ColumnsCollectionChanged: " _
        & columns.Count.ToString())
End Sub
' </Snippet1>
End Class
