Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

public class Form1
Inherits Form
Private dataGrid1 As DataGrid 
Shared Sub Main()
End Sub
    ' <Snippet1>
    Private Sub GetDataGridTextBox()
        ' Gets the DataGridTextBoxColumn from the DataGrid control.
        Dim myTextBoxColumn As DataGridTextBoxColumn
        ' Assumes the CompanyName column is a DataGridTextBoxColumn.
        myTextBoxColumn = CType(dataGrid1.TableStyles(0). _
            GridColumnStyles("CompanyName"), DataGridTextBoxColumn)
        ' Gets the DataGridTextBox for the column.
        Dim myGridTextBox As DataGridTextBox
        myGridTextBox = CType(myTextBoxColumn.TextBox, DataGridTextBox)
    End Sub
    ' </Snippet1>
End Class
