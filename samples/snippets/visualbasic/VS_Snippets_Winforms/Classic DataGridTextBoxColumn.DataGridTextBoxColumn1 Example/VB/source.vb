Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel


Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub AddColumn()
        Dim myTable As New DataTable()
        
        ' Add a new DataColumn to the DataTable.
        Dim myColumn As New DataColumn("myTextBoxColumn")
        myColumn.DataType = System.Type.GetType("System.String")
        myColumn.DefaultValue = "default string"
        myTable.Columns.Add(myColumn)
        ' Get the CurrencyManager for the DataTable.
        Dim cm As CurrencyManager = CType(Me.BindingContext(myTable), CurrencyManager)
        ' Use the CurrencyManager to get the PropertyDescriptor for the new column.
        Dim pd As PropertyDescriptor = cm.GetItemProperties()("myTextBoxColumn")
        Dim myColumnTextColumn As DataGridTextBoxColumn
        ' Create the DataGridTextBoxColumn with the PropertyDescriptor.
        myColumnTextColumn = New DataGridTextBoxColumn(pd)
        ' Add the new DataGridColumn to the GridColumnsCollection.
        dataGrid1.DataSource = myTable
        dataGrid1.TableStyles.Add(New DataGridTableStyle())
        dataGrid1.TableStyles(0).GridColumnStyles.Add(myColumnTextColumn)
    End Sub 'AddColumn
    ' </Snippet1>
End Class 'Form1 

