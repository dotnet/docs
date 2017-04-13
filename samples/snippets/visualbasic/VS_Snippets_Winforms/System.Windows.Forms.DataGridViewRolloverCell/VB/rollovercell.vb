'<Snippet000>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

'<Snippet100>
Class Form1
    Inherits Form

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Public Sub New()
        Dim dataGridView1 As New DataGridView()
        Dim col As New DataGridViewRolloverCellColumn()
        dataGridView1.Columns.Add(col)
        dataGridView1.Rows.Add(New String() {""})
        dataGridView1.Rows.Add(New String() {""})
        dataGridView1.Rows.Add(New String() {""})
        dataGridView1.Rows.Add(New String() {""})
        Me.Controls.Add(dataGridView1)
        Me.Text = "DataGridView rollover-cell demo"
    End Sub

End Class
'</Snippet100>

'<Snippet200>
'<Snippet201>
Public Class DataGridViewRolloverCell
    Inherits DataGridViewTextBoxCell
'</Snippet201>

    '<Snippet210>
    Protected Overrides Sub Paint( _
        ByVal graphics As Graphics, _
        ByVal clipBounds As Rectangle, _
        ByVal cellBounds As Rectangle, _
        ByVal rowIndex As Integer, _
        ByVal elementState As DataGridViewElementStates, _
        ByVal value As Object, _
        ByVal formattedValue As Object, _
        ByVal errorText As String, _
        ByVal cellStyle As DataGridViewCellStyle, _
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
        ByVal paintParts As DataGridViewPaintParts)

        ' Call the base class method to paint the default cell appearance.
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, _
            value, formattedValue, errorText, cellStyle, _
            advancedBorderStyle, paintParts)

        ' Retrieve the client location of the mouse pointer.
        Dim cursorPosition As Point = _
            Me.DataGridView.PointToClient(Cursor.Position)

        ' If the mouse pointer is over the current cell, draw a custom border.
        If cellBounds.Contains(cursorPosition) Then
            Dim newRect As New Rectangle(cellBounds.X + 1, _
                cellBounds.Y + 1, cellBounds.Width - 4, _
                cellBounds.Height - 4)
            graphics.DrawRectangle(Pens.Red, newRect)
        End If

    End Sub
    '</Snippet210>

    '<Snippet220>
    ' Force the cell to repaint itself when the mouse pointer enters it.
    Protected Overrides Sub OnMouseEnter(ByVal rowIndex As Integer)
        Me.DataGridView.InvalidateCell(Me)
    End Sub

    ' Force the cell to repaint itself when the mouse pointer leaves it.
    Protected Overrides Sub OnMouseLeave(ByVal rowIndex As Integer)
        Me.DataGridView.InvalidateCell(Me)
    End Sub
    '</Snippet220>

'<Snippet202>
End Class
'</Snippet202>
'</Snippet200>

'<Snippet300>
Public Class DataGridViewRolloverCellColumn
    Inherits DataGridViewColumn

    Public Sub New()
        Me.CellTemplate = New DataGridViewRolloverCell()
    End Sub

End Class
'</Snippet300>
'</Snippet000>