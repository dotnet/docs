'<Snippet00>
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private WithEvents dataGridView1 As New DataGridView()

    Sub New()

        Dim data As New DataTable()
        data.Locale = System.Globalization.CultureInfo.InvariantCulture
        Dim adapter As New SqlDataAdapter( _
            "select * from customers", _
            "data source=localhost;initial catalog=northwind;" + _
            "integrated security=sspi")
        adapter.Fill(data)

        Me.dataGridView1.Dock = DockStyle.Fill
        Me.dataGridView1.DataSource = data
        Me.Controls.Add(Me.dataGridView1)
        Me.Text = "DataGridView.CellPainting demo"

    End Sub

    '<Snippet10>
    Private Sub dataGridView1_CellPainting(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) _
        Handles dataGridView1.CellPainting

        If Me.dataGridView1.Columns("ContactName").Index = _
            e.ColumnIndex AndAlso e.RowIndex >= 0 Then

            Dim newRect As New Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, _
                e.CellBounds.Width - 4, e.CellBounds.Height - 4)
            Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
            Dim gridBrush As New SolidBrush(Me.dataGridView1.GridColor)
            Dim gridLinePen As New Pen(gridBrush)

            Try

                ' Erase the cell.
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                ' Draw the grid lines (only the right and bottom lines;
                ' DataGridView takes care of the others).
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, _
                    e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, _
                    e.CellBounds.Bottom - 1)
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, _
                    e.CellBounds.Top, e.CellBounds.Right - 1, _
                    e.CellBounds.Bottom)

                ' Draw the inset highlight box.
                e.Graphics.DrawRectangle(Pens.Blue, newRect)

                ' Draw the text content of the cell, ignoring alignment.
                If (e.Value IsNot Nothing) Then
                    e.Graphics.DrawString(CStr(e.Value), e.CellStyle.Font, _
                    Brushes.Crimson, e.CellBounds.X + 2, e.CellBounds.Y + 2, _
                    StringFormat.GenericDefault)
                End If
                e.Handled = True

            Finally
                gridLinePen.Dispose()
                gridBrush.Dispose()
                backColorBrush.Dispose()
            End Try

        End If

    End Sub
    '</Snippet10>

End Class
'</Snippet00>