Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    Protected myDataSet As DataSet
    
    ' <Snippet1>
    Private Sub PrintReadOnlyValues()
        Dim tableStyle As DataGridTableStyle
        For Each tableStyle In  dataGrid1.TableStyles
            Console.WriteLine(tableStyle.ReadOnly)
        Next tableStyle
    End Sub 'PrintReadOnlyValues
    ' </Snippet1>
End Class 'Form1 

