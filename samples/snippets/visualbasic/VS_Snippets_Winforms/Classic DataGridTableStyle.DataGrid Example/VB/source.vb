Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel



Public Class Form1
    Inherits Form
    Protected myDataGrid As DataGrid
    Protected myDataSet As DataSet
    
    ' <Snippet1>
    Private Sub GetSelectedIndex(myGridTable As DataGridTableStyle)
        ' Get the name of the DataGrid of the DataGridTable 
        ' passed as an argument. 
        Console.WriteLine(myGridTable.DataGrid.CurrentCell.ToString())
    End Sub 'GetSelectedIndex
    ' </Snippet1>
End Class 'Form1 

