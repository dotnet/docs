Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization



Class Form1
    Inherits Form
    
    Private dataGrid1 As New DataGrid()
    
    ' <Snippet1>
    Private Sub AddColumn(myTable As DataTable)
        ' Add a new DataColumn to the DataTable.
        Dim myColumn As New DataColumn("myTextBoxColumn")
        myColumn.DataType = GetType(String)
        myColumn.DefaultValue = "default string"
        myTable.Columns.Add(myColumn)
        ' Get the ListManager for the DataTable.
        Dim cm As CurrencyManager = CType(Me.BindingContext(myTable), CurrencyManager)
        ' Use the ListManager to get the PropertyDescriptor for the new column.
        Dim pd As PropertyDescriptor = cm.GetItemProperties()("myTextBoxColumn")
        ' Create a new DataTimeFormat object.
        Dim fmt As New DateTimeFormatInfo()
        ' Insert code to set format.
        Dim myColumnTextColumn As DataGridTextBoxColumn
        ' Create the DataGridTextBoxColumn with the PropertyDescriptor and Format.
        myColumnTextColumn = New DataGridTextBoxColumn(pd, fmt.SortableDateTimePattern)
        ' Add the new DataGridColumnStyle to the GridColumnsCollection.
        dataGrid1.TableStyles(0).GridColumnStyles.Add(myColumnTextColumn)
    End Sub 'AddColumn
    ' </Snippet1>
End Class 'Form1 

