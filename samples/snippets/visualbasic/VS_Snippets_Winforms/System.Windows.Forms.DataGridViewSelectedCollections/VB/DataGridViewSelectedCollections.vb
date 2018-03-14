Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Class Form1
    Inherits Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private WithEvents dataGridView1 As New DataGridView()
    Private WithEvents selectedCellsButton As New Button()
    Private WithEvents selectedRowsButton As New Button()
    Private WithEvents selectedColumnsButton As New Button()

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        Me.dataGridView1.Dock = DockStyle.Fill
        Me.dataGridView1.ColumnCount = 5
        Me.dataGridView1.RowCount = 5

        selectedCellsButton.AutoSize = True
        selectedCellsButton.Text = "selected cells"
        selectedRowsButton.AutoSize = True
        selectedRowsButton.Text = "selected rows"
        selectedColumnsButton.AutoSize = True
        selectedColumnsButton.Text = "selected columns"

        Dim panel As New FlowLayoutPanel()
        panel.Dock = DockStyle.Top
        panel.AutoSize = True
        panel.Controls.AddRange(New Control() { _
            Me.selectedCellsButton, Me.selectedRowsButton, _
            Me.selectedColumnsButton})

        Me.Controls.AddRange(New Control() {dataGridView1, panel})
        Me.Text = "DataGridView selected collections demo"

        MyBase.OnLoad(e)

    End Sub

    '<snippet05>
    Private Sub dataGridView1_ColumnHeaderMouseClick( _
        ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) _
        Handles dataGridView1.ColumnHeaderMouseClick

        Me.dataGridView1.SelectionMode = _
            DataGridViewSelectionMode.ColumnHeaderSelect
        Me.dataGridView1.Columns(e.ColumnIndex).HeaderCell _
            .SortGlyphDirection = SortOrder.None
        Me.dataGridView1.Columns(e.ColumnIndex).Selected = True

    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick( _
        ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) _
        Handles dataGridView1.RowHeaderMouseClick

        Me.dataGridView1.SelectionMode = _
            DataGridViewSelectionMode.RowHeaderSelect
        Me.dataGridView1.Rows(e.RowIndex).Selected = True

    End Sub
    '</snippet05>

    '<snippet10>
    Private Sub selectedCellsButton_Click( _
        ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles selectedCellsButton.Click

        Dim selectedCellCount As Integer = _
            dataGridView1.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount > 0 Then

            If dataGridView1.AreAllCellsSelected(True) Then

                MessageBox.Show("All cells are selected", "Selected Cells")

            Else

                Dim sb As New System.Text.StringBuilder()

                Dim i As Integer
                For i = 0 To selectedCellCount - 1

                    sb.Append("Row: ")
                    sb.Append(dataGridView1.SelectedCells(i).RowIndex _
                        .ToString())
                    sb.Append(", Column: ")
                    sb.Append(dataGridView1.SelectedCells(i).ColumnIndex _
                        .ToString())
                    sb.Append(Environment.NewLine)

                Next i

                sb.Append("Total: " + selectedCellCount.ToString())
                MessageBox.Show(sb.ToString(), "Selected Cells")

            End If

        End If

    End Sub
    '</snippet10>

    '<snippet20>
    Private Sub selectedRowsButton_Click( _
        ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles selectedRowsButton.Click

        Dim selectedRowCount As Integer = _
            dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then

            Dim sb As New System.Text.StringBuilder()

            Dim i As Integer
            For i = 0 To selectedRowCount - 1

                sb.Append("Row: ")
                sb.Append(dataGridView1.SelectedRows(i).Index.ToString())
                sb.Append(Environment.NewLine)

            Next i

            sb.Append("Total: " + selectedRowCount.ToString())
            MessageBox.Show(sb.ToString(), "Selected Rows")

        End If

    End Sub
    '</snippet20>

    '<snippet30>
    Private Sub selectedColumnsButton_Click( _
        ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles selectedColumnsButton.Click

        Dim selectedColumnCount As Integer = dataGridView1.Columns _
            .GetColumnCount(DataGridViewElementStates.Selected)

        If selectedColumnCount > 0 Then

            Dim sb As New System.Text.StringBuilder()

            Dim i As Integer
            For i = 0 To selectedColumnCount - 1

                sb.Append("Column: ")
                sb.Append(dataGridView1.SelectedColumns(i).Index.ToString())
                sb.Append(Environment.NewLine)

            Next i

            sb.Append("Total: " + selectedColumnCount.ToString())
            MessageBox.Show(sb.ToString(), "Selected Columns")

        End If

    End Sub
    '</snippet30>

End Class