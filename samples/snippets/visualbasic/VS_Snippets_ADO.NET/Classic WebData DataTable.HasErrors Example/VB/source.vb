Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Private Sub CheckForErrors(dataSet As DataSet)
     ' Invoke GetChanges on the DataSet to create a reduced set.
     Dim thisDataSet As DataSet = dataSet.GetChanges()

     ' Check each table's HasErrors property.
     Dim table As DataTable
     For Each table In thisDataSet.Tables
         ' If HasErrors is true, reconcile errors.
         If table.HasErrors Then
             ' Insert code to reconcile errors.
         End If
     Next table
 End Sub
' </Snippet1>
End Class

