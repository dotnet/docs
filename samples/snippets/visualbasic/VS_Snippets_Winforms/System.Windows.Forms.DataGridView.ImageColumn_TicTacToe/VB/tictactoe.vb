' The following code example demonstrates using images to create a 
' TicTacToe game.
'<snippet0>
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System

Public Class TicTacToe
    Inherits System.Windows.Forms.Form

    Friend WithEvents dataGridView1 As DataGridView
    Friend WithEvents Button1 As Button = New Button()
    Friend WithEvents turn As Label = New Label()
    Friend WithEvents Button2 As Button = New Button()
    Friend WithEvents Button3 As Button = New Button()
    Friend WithEvents Button4 As Button = New Button()
    Friend WithEvents Button5 As Button = New Button()
    Friend WithEvents Panel1 As FlowLayoutPanel = New FlowLayoutPanel()

#Region "bitmaps"
    Private oImage As Byte() = { _
        &H42, &H4D, &HC6, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H76, &H0, &H0, &H0, &H28, &H0, _
        &H0, &H0, &HB, &H0, &H0, &H0, &HA, &H0, _
        &H0, &H0, &H1, &H0, &H4, &H0, &H0, &H0, _
        &H0, &H0, &H50, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H0, &H0, &H0, &H0, &H10, &H0, _
        &H0, &H0, &H10, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H0, &H0, &H80, &H0, &H0, &H80, _
        &H0, &H0, &H0, &H80, &H80, &H0, &H80, &H0, _
        &H0, &H0, &H80, &H0, &H80, &H0, &H80, &H80, _
        &H0, &H0, &HC0, &HC0, &HC0, &H0, &H80, &H80, _
        &H80, &H0, &H0, &H0, &HFF, &H0, &H0, &HFF, _
        &H0, &H0, &H0, &HFF, &HFF, &H0, &HFF, &H0, _
        &H0, &H0, &HFF, &H0, &HFF, &H0, &HFF, &HFF, _
        &H0, &H0, &HFF, &HFF, &HFF, &H0, &HFF, &HFF, _
        &H0, &HF, &HFF, &HF0, &H0, &H0, &HFF, &H0, _
        &HFF, &HF0, &HF, &HF0, &H0, &H0, &HF0, &HFF, _
        &HFF, &HFF, &HF0, &HF0, &H0, &H0, &HF0, &HFF, _
        &HFF, &HFF, &HF0, &HF0, &H0, &H0, &HF, &HFF, _
        &HFF, &HFF, &HFF, &H0, &H0, &H0, &HF, &HFF, _
        &HFF, &HFF, &HFF, &H0, &H0, &H0, &HF0, &HFF, _
        &HFF, &HFF, &HF0, &HF0, &H0, &H0, &HF0, &HFF, _
        &HFF, &HFF, &HF0, &HF0, &H0, &H0, &HFF, &H0, _
        &HFF, &HF0, &HF, &HF0, &H0, &H0, &HFF, &HFF, _
        &H0, &HF, &HFF, &HF0, &H0, &H0}

    Private xImage As Byte() = { _
        &H42, &H4D, &HC6, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H76, &H0, &H0, &H0, &H28, &H0, _
        &H0, &H0, &HB, &H0, &H0, &H0, &HA, &H0, _
        &H0, &H0, &H1, &H0, &H4, &H0, &H0, &H0, _
        &H0, &H0, &H50, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H0, &H0, &H0, &H0, &H10, &H0, _
        &H0, &H0, &H10, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H0, &H0, &H80, &H0, &H0, &H80, _
        &H0, &H0, &H0, &H80, &H80, &H0, &H80, &H0, _
        &H0, &H0, &H80, &H0, &H80, &H0, &H80, &H80, _
        &H0, &H0, &HC0, &HC0, &HC0, &H0, &H80, &H80, _
        &H80, &H0, &H0, &H0, &HFF, &H0, &H0, &HFF, _
        &H0, &H0, &H0, &HFF, &HFF, &H0, &HFF, &H0, _
        &H0, &H0, &HFF, &H0, &HFF, &H0, &HFF, &HFF, _
        &H0, &H0, &HFF, &HFF, &HFF, &H0, &HF0, &HFF, _
        &HFF, &HFF, &HF0, &HF0, &H0, &H0, &HFF, &HF, _
        &HFF, &HFF, &HF, &HF0, &H0, &H0, &HFF, &HF0, _
        &HFF, &HF0, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HF, &HF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HF, &HF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HF, &HF, &HFF, &HF0, &H0, &H0, &HFF, &HF0, _
        &HFF, &HF0, &HFF, &HF0, &H0, &H0, &HFF, &HF, _
        &HFF, &HFF, &HF, &HF0, &H0, &H0, &HF0, &HFF, _
        &HFF, &HFF, &HF0, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0}

    Private blankImage As Byte() = { _
        &H42, &H4D, &HC6, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H76, &H0, &H0, &H0, &H28, &H0, _
        &H0, &H0, &HB, &H0, &H0, &H0, &HA, &H0, _
        &H0, &H0, &H1, &H0, &H4, &H0, &H0, &H0, _
        &H0, &H0, &H50, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H0, &H0, &H0, &H0, &H10, &H0, _
        &H0, &H0, &H10, &H0, &H0, &H0, &H0, &H0, _
        &H0, &H0, &H0, &H0, &H80, &H0, &H0, &H80, _
        &H0, &H0, &H0, &H80, &H80, &H0, &H80, &H0, _
        &H0, &H0, &H80, &H0, &H80, &H0, &H80, &H80, _
        &H0, &H0, &HC0, &HC0, &HC0, &H0, &H80, &H80, _
        &H80, &H0, &H0, &H0, &HFF, &H0, &H0, &HFF, _
        &H0, &H0, &H0, &HFF, &HFF, &H0, &HFF, &H0, _
        &H0, &H0, &HFF, &H0, &HFF, &H0, &HFF, &HFF, _
        &H0, &H0, &HFF, &HFF, &HFF, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0, &HFF, &HFF, _
        &HFF, &HFF, &HFF, &HF0, &H0, &H0}
#End Region

    Private blank As Bitmap = New Bitmap( _
        New MemoryStream(blankImage))
    Private x As Bitmap = New Bitmap(New MemoryStream(xImage))
    Private o As Bitmap = New Bitmap(New MemoryStream(oImage))
    Private xString As String = "X's turn"
    Private oString As String = "O's turn"
    Private gameOverString As String = "Game Over"
    Private bitmapPadding As Integer = 6

    Private Sub InitializeDataGridView(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Me.Load
        SuspendLayout()
        Panel1.SuspendLayout()

        ConfigureForm()
        SizeGrid()
        CreateColumns()
        CreateRows()

        ResumeLayout(False)
        Panel1.ResumeLayout(False)
    End Sub

    Private Sub ConfigureForm()
        AutoSize = True
        turn.Size = New System.Drawing.Size(75, 34)
        turn.TextAlign = ContentAlignment.MiddleLeft
        turn.Text = xString

        Panel1.FlowDirection = FlowDirection.TopDown
        Panel1.Location = New System.Drawing.Point(0, 8)
        Panel1.Size = New System.Drawing.Size(120, 196)

        ClientSize = New System.Drawing.Size(355, 200)
        Controls.Add(Me.Panel1)
        Text = "TicTacToe"

        dataGridView1 = New System.Windows.Forms.DataGridView
        dataGridView1.Location = New Point(120, 0)
        dataGridView1.AllowUserToAddRows = False
        Controls.Add(dataGridView1)
        SetupButtons()
    End Sub

    Private Sub SetupButtons()
        SetupButton(Button1, "Restart")
        Panel1.Controls.Add(Me.turn)
        SetupButton(Button2, "Increase Cell Size")
        SetupButton(Button3, "Stretch Images")
        SetupButton(Button4, "Zoom Images")
        SetupButton(Button5, "Normal Images")
    End Sub

    Private Sub SetupButton(ByVal button As Button, _
        ByVal buttonLabel As String)

        Panel1.Controls.Add(button)
        button.Text = buttonLabel
        button.AutoSize = True

    End Sub

    '<snippet5>
    Private Sub CreateColumns()

        Dim imageColumn As DataGridViewImageColumn
        Dim columnCount As Integer = 0
        Do
            Dim unMarked As Bitmap = blank
            imageColumn = New DataGridViewImageColumn()

            ' Add twice the padding for the left and 
            ' right sides of the cell.
            imageColumn.Width = x.Width + 2 * bitmapPadding + 1

            imageColumn.Image = unMarked
            imageColumn.ImageLayout = DataGridViewImageCellLayout.NotSet
            imageColumn.Description = "default image layout"
            dataGridView1.Columns.Add(imageColumn)
            columnCount = columnCount + 1
        Loop While columnCount < 3
    End Sub
    '</snippet5>

    Private Sub CreateRows()
        dataGridView1.Rows.Add()
        dataGridView1.Rows.Add()
        dataGridView1.Rows.Add()
    End Sub

    '<snippet7>
    Private Sub SizeGrid()
        dataGridView1.ColumnHeadersVisible = False
        dataGridView1.RowHeadersVisible = False
        dataGridView1.AllowUserToResizeColumns = False
        dataGridView1.AllowUserToResizeRows = False
        dataGridView1.BorderStyle = BorderStyle.None

        ' Add twice the padding for the top and bottom of the cell. 
        dataGridView1.RowTemplate.Height = x.Height + _
            2 * bitmapPadding + 1

        dataGridView1.AutoSize = True
    End Sub
    '</snippet7>

    Private Sub reset(ByVal sender As Object, _
        ByVal e As EventArgs) _
        Handles Button1.Click

        dataGridView1.Dispose()
        InitializeDataGridView(Nothing, Nothing)
    End Sub

    '<snippet10>
    Private Sub dataGridView1_CellClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellClick

        If turn.Text.Equals(gameOverString) Then Return

        Dim cell As DataGridViewImageCell = _
            CType(dataGridView1.Rows(e.RowIndex). _
                Cells(e.ColumnIndex), DataGridViewImageCell)
        If (cell.Value Is blank) Then
            If IsOsTurn() Then
                cell.Value = o
            Else
                cell.Value = x
            End If
            ToggleTurn()
            ToolTip(e)
        End If
        If IsAWin() Then
            turn.Text = gameOverString
        End If
    End Sub
    '</snippet10>

    '<snippet15>
    Private Sub dataGridView1_CellMouseEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellMouseEnter

        Dim markingUnderMouse As Bitmap = _
            CType(dataGridView1.Rows(e.RowIndex). _
                Cells(e.ColumnIndex).Value, Bitmap)

        If markingUnderMouse Is blank Then
            dataGridView1.Cursor = Cursors.Default
        ElseIf markingUnderMouse Is o OrElse markingUnderMouse Is x Then
            dataGridView1.Cursor = Cursors.No
            ToolTip(e)
        End If
    End Sub

    Private Sub ToolTip( _
        ByVal e As DataGridViewCellEventArgs)

        Dim cell As DataGridViewImageCell = _
            CType(dataGridView1.Rows(e.RowIndex). _
            Cells(e.ColumnIndex), DataGridViewImageCell)
        Dim imageColumn As DataGridViewImageColumn = _
            CType(dataGridView1.Columns(cell.ColumnIndex), _
            DataGridViewImageColumn)

        cell.ToolTipText = imageColumn.Description
    End Sub

    Private Sub dataGridView1_CellMouseLeave(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellMouseLeave

        dataGridView1.Cursor = Cursors.Default
    End Sub
    '</snippet15>

    '<snippet20>
    Private Sub Stretch(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button3.Click

        For Each column As DataGridViewImageColumn _
            In dataGridView1.Columns
            column.ImageLayout = DataGridViewImageCellLayout.Stretch
            column.Description = "Stretched image layout"
        Next
    End Sub

    Private Sub ZoomToImage(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button4.Click

        For Each column As DataGridViewImageColumn _
            In dataGridView1.Columns
            column.ImageLayout = DataGridViewImageCellLayout.Zoom
            column.Description = "Zoomed image layout"
        Next
    End Sub

    Private Sub NormalImage(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button5.Click

        For Each column As DataGridViewImageColumn _
            In dataGridView1.Columns
            column.ImageLayout = DataGridViewImageCellLayout.Normal
            column.Description = "Normal image layout"
        Next
    End Sub
    '</snippet20>

    Private Sub MakeCellsLarger(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button2.Click

        For Each column As DataGridViewImageColumn _
            In dataGridView1.Columns
            column.Width = column.Width * 2
        Next
        For Each row As DataGridViewRow In dataGridView1.Rows
            If row.IsNewRow Then Continue For
            row.Height = CInt(row.Height * 1.5)
        Next
    End Sub

    Private Function IsAWin() As Boolean
        If ARowIsSame() OrElse AColumnIsSame() OrElse ADiagonalIsSame() Then
            Return True
        Else 
            Return False
        End If
    End Function

    Private Function ARowIsSame() As Boolean
        Dim marking As Bitmap = Nothing
        If marking Is blank Then Return False
        For Each row As DataGridViewRow In dataGridView1.Rows
            If row.IsNewRow Then Continue For
            marking = CType(row.Cells(0).Value, Bitmap)
            If marking IsNot blank Then
                If marking Is row.Cells(1).Value AndAlso _
                    marking Is row.Cells(2).Value Then Return True
            End If
        Next
        Return False
    End Function

    Private Function AColumnIsSame() As Boolean

        Dim columnIndex As Integer = 0
        Dim marking As Bitmap
        Do
            marking = CType(dataGridView1.Rows(0).Cells(columnIndex).Value, _
                Bitmap)
            If marking IsNot blank Then
                If marking Is _
                    dataGridView1.Rows(1).Cells(columnIndex).Value _
                    AndAlso marking Is _
                    dataGridView1.Rows(2).Cells(columnIndex).Value _
                    Then Return True
            End If
            columnIndex = columnIndex + 1
        Loop While columnIndex < _
            dataGridView1.Columns.GetColumnCount( _
            DataGridViewElementStates.Visible)
        Return False
    End Function

    Private Function ADiagonalIsSame() As Boolean

        If LeftToRightDiagonalIsSame() Then Return True
        If RightToLeftDiagonalIsSame() Then Return True
        Return False
    End Function

    Private Function LeftToRightDiagonalIsSame() As Boolean
        Return IsDiagonalSame(0, 2)
    End Function

    Private Function RightToLeftDiagonalIsSame() As Boolean
        Return IsDiagonalSame(2, 0)
    End Function

    Private Function IsDiagonalSame(ByVal startingColumn As Integer, _
        ByVal lastColumn As Integer) As Boolean

        Dim marking As Bitmap = CType( _
            dataGridView1.Rows(0).Cells(startingColumn).Value, Bitmap)
        If marking Is blank Then Return False
        If marking Is dataGridView1.Rows(1).Cells(1).Value AndAlso _
            marking Is dataGridView1.Rows(2).Cells(lastColumn).Value _
            Then Return True
    End Function

    Private Sub ToggleTurn()
        If turn.Text.Equals(xString) Then turn.Text = oString _
        Else turn.Text = xString
    End Sub

    Private Function IsOsTurn() As Boolean
        If turn.Text.Equals(oString) Then Return True _
        Else  : Return False
    End Function

    <STAThread> Public Shared Sub Main()
        Application.Run(New TicTacToe())
    End Sub

End Class
'</snippet0>