'<snippet00>
Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private WithEvents DataGridView1 As New DataGridView()

    ' Establish the main entry point for the application.
    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub New()
        ' Initialize the form.
        ' This code can be replaced with designer generated code.
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(Me.DataGridView1)
        Me.Text = "DataGridView.SortCompare demo"

        Me.PopulateDataGridView()
    End Sub

    '<snippet20>'
    ' Replace this with your own population code.
    Private Sub PopulateDataGridView()
        With Me.DataGridView1
            ' Add columns to the DataGridView.
            .ColumnCount = 3

            ' Set the properties of the DataGridView columns.
            .Columns(0).Name = "ID"
            .Columns(1).Name = "Name"
            .Columns(2).Name = "City"
            .Columns("ID").HeaderText = "ID"
            .Columns("Name").HeaderText = "Name"
            .Columns("City").HeaderText = "City"
        End With

        ' Add rows of data to the DataGridView.
        With Me.DataGridView1.Rows
            .Add(New String() {"1", "Parker", "Seattle"})
            .Add(New String() {"2", "Parker", "New York"})
            .Add(New String() {"3", "Watson", "Seattle"})
            .Add(New String() {"4", "Jameson", "New Jersey"})
            .Add(New String() {"5", "Brock", "New York"})
            .Add(New String() {"6", "Conner", "Portland"})
        End With

        ' Autosize the columns.
        Me.DataGridView1.AutoResizeColumns()
 
    End Sub
    '</snippet20>

    '<snippet10>
    Private Sub DataGridView1_SortCompare( _
        ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) _
        Handles DataGridView1.SortCompare

        ' Try to sort based on the contents of the cell in the current column.
        e.SortResult = System.String.Compare(e.CellValue1.ToString(), _
            e.CellValue2.ToString())

        ' If the cells are equal, sort based on the ID column.
        If (e.SortResult = 0) AndAlso Not (e.Column.Name = "ID") Then
            e.SortResult = System.String.Compare( _
                DataGridView1.Rows(e.RowIndex1).Cells("ID").Value.ToString(), _
                DataGridView1.Rows(e.RowIndex2).Cells("ID").Value.ToString())
        End If

        e.Handled = True

    End Sub
    '</snippet10>
End Class
'</snippet00>