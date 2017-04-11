'<Snippet00>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class DataGridViewRowPainting
    Inherits Form
    Private WithEvents dataGridView1 As New DataGridView()
    Private oldRowIndex As Int32 = 0
    Private Const CUSTOM_CONTENT_HEIGHT As Int32 = 30

    <STAThreadAttribute()> _
    Public Shared Sub Main()

        Application.Run(New DataGridViewRowPainting())

    End Sub 'Main

    Public Sub New()

        Me.dataGridView1.Dock = DockStyle.Fill
        Me.Controls.Add(Me.dataGridView1)
        Me.Text = "DataGridView row painting demo"

    End Sub 'New

    Sub DataGridViewRowPainting_Load(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Me.Load

        '<Snippet10>
        ' Set a cell padding to provide space for the top of the focus 
        ' rectangle and for the content that spans multiple columns. 
        Dim newPadding As New Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT)
        Me.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding

        ' Set the selection background color to transparent so 
        ' the cell won't paint over the custom selection background.
        Me.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = _
            Color.Transparent

        ' Set the row height to accommodate the normal cell content and the 
        ' content that spans multiple columns.
        Me.dataGridView1.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT
        '</Snippet10>

        ' Initialize other DataGridView properties.
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
        Me.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Set the column header names.
        Me.dataGridView1.ColumnCount = 4
        Me.dataGridView1.Columns(0).Name = "Recipe"
        Me.dataGridView1.Columns(0).SortMode = _
            DataGridViewColumnSortMode.NotSortable
        Me.dataGridView1.Columns(1).Name = "Category"
        Me.dataGridView1.Columns(2).Name = "Main Ingredients"
        Me.dataGridView1.Columns(3).Name = "Rating"

        ' Hide the column that contains the content that spans 
        ' multiple columns.
        Me.dataGridView1.Columns(2).Visible = False

        ' Populate the rows of the DataGridView.
        Dim row1() As String = {"Meatloaf", "Main Dish", _
            "1 lb. lean ground beef, 1/2 cup bread crumbs, " + _
            "1/4 cup ketchup, 1/3 tsp onion powder, 1 clove of garlic, " + _
            "1/2 pack onion soup mix, dash of your favorite BBQ Sauce", "****"}
        Dim row2() As String = {"Key Lime Pie", "Dessert", _
            "lime juice, whipped cream, eggs, evaporated milk", "****"}
        Dim row3() As String = {"Orange-Salsa Pork Chops", "Main Dish", _
            "pork chops, salsa, orange juice, pineapple", "****"}
        Dim row4() As String = {"Black Bean and Rice Salad", "Salad", _
            "black beans, brown rice", "****"}
        Dim row5() As String = {"Chocolate Cheesecake", "Dessert", _
            "cream cheese, unsweetened chocolate", "***"}
        Dim row6() As String = {"Black Bean Dip", "Appetizer", _
            "black beans, sour cream, salsa, chips", "***"}
        Dim rows() As Object = {row1, row2, row3, row4, row5, row6}
        Dim rowArray As String()
        For Each rowArray In rows
            Me.dataGridView1.Rows.Add(rowArray)
        Next rowArray

        ' Adjust the row heights to accommodate the normal cell content.
        Me.dataGridView1.AutoResizeRows( _
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
    End Sub 'DataGridViewRowPainting_Load

    '<snippet18>
    ' Forces the control to repaint itself when the user 
    ' manually changes the width of a column.
    Sub dataGridView1_ColumnWidthChanged(ByVal sender As Object, _
        ByVal e As DataGridViewColumnEventArgs) _
        Handles dataGridView1.ColumnWidthChanged

        Me.dataGridView1.Invalidate()

    End Sub 'dataGridView1_ColumnWidthChanged
    '</snippet18>

    '<Snippet19>
    ' Forces the row to repaint itself when the user changes the 
    ' current cell. This is necessary to refresh the focus rectangle.
    Sub dataGridView1_CurrentCellChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles dataGridView1.CurrentCellChanged

        If oldRowIndex <> -1 Then
            Me.dataGridView1.InvalidateRow(oldRowIndex)
        End If
        oldRowIndex = Me.dataGridView1.CurrentCellAddress.Y

    End Sub 'dataGridView1_CurrentCellChanged
    '</Snippet19>

    '<Snippet20>
    ' Paints the custom selection background for selected rows.
    Sub dataGridView1_RowPrePaint(ByVal sender As Object, _
        ByVal e As DataGridViewRowPrePaintEventArgs) _
        Handles dataGridView1.RowPrePaint

        ' Do not automatically paint the focus rectangle.
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus

        '<Snippet25>
        ' Determine whether the cell should be painted with the 
        ' custom selection background.
        If (e.State And DataGridViewElementStates.Selected) = _
            DataGridViewElementStates.Selected Then

            ' Calculate the bounds of the row.
            Dim rowBounds As New Rectangle( _
                Me.dataGridView1.RowHeadersWidth, e.RowBounds.Top, _
                Me.dataGridView1.Columns.GetColumnsWidth( _
                DataGridViewElementStates.Visible) - _
                Me.dataGridView1.HorizontalScrollingOffset + 1, _
                e.RowBounds.Height)

            ' Paint the custom selection background.
            Dim backbrush As New _
                System.Drawing.Drawing2D.LinearGradientBrush(rowBounds, _
                Me.dataGridView1.DefaultCellStyle.SelectionBackColor, _
                e.InheritedRowStyle.ForeColor, _
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Try
                e.Graphics.FillRectangle(backbrush, rowBounds)
            Finally
                backbrush.Dispose()
            End Try
        End If
        '</Snippet25>

    End Sub 'dataGridView1_RowPrePaint
    '</Snippet20>

    '<Snippet30>
    ' Paints the content that spans multiple columns and the focus rectangle.
    Sub dataGridView1_RowPostPaint(ByVal sender As Object, _
        ByVal e As DataGridViewRowPostPaintEventArgs) _
        Handles dataGridView1.RowPostPaint

        ' Calculate the bounds of the row.
        Dim rowBounds As New Rectangle(Me.dataGridView1.RowHeadersWidth, _
            e.RowBounds.Top, Me.dataGridView1.Columns.GetColumnsWidth( _
            DataGridViewElementStates.Visible) - _
            Me.dataGridView1.HorizontalScrollingOffset + 1, e.RowBounds.Height)

        Dim forebrush As SolidBrush = Nothing
        Try
            '<Snippet34>
            ' Determine the foreground color.
            If (e.State And DataGridViewElementStates.Selected) = _
                DataGridViewElementStates.Selected Then

                forebrush = New SolidBrush(e.InheritedRowStyle.SelectionForeColor)
            Else
                forebrush = New SolidBrush(e.InheritedRowStyle.ForeColor)
            End If
            '</Snippet34>

            '<Snippet35>
            ' Get the content that spans multiple columns.
            Dim recipe As Object = _
                Me.dataGridView1.Rows.SharedRow(e.RowIndex).Cells(2).Value

            If (recipe IsNot Nothing) Then
                Dim text As String = recipe.ToString()

                ' Calculate the bounds for the content that spans multiple 
                ' columns, adjusting for the horizontal scrolling position 
                ' and the current row height, and displaying only whole
                ' lines of text.
                Dim textArea As Rectangle = rowBounds
                textArea.X -= Me.dataGridView1.HorizontalScrollingOffset
                textArea.Width += Me.dataGridView1.HorizontalScrollingOffset
                textArea.Y += rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                textArea.Height -= rowBounds.Height - e.InheritedRowStyle.Padding.Bottom
                textArea.Height = (textArea.Height \ e.InheritedRowStyle.Font.Height) * _
                    e.InheritedRowStyle.Font.Height

                ' Calculate the portion of the text area that needs painting.
                Dim clip As RectangleF = textArea
                clip.Width -= Me.dataGridView1.RowHeadersWidth + 1 - clip.X
                clip.X = Me.dataGridView1.RowHeadersWidth + 1
                Dim oldClip As RectangleF = e.Graphics.ClipBounds
                e.Graphics.SetClip(clip)

                ' Draw the content that spans multiple columns.
                e.Graphics.DrawString(text, e.InheritedRowStyle.Font, forebrush, _
                    textArea)

                e.Graphics.SetClip(oldClip)
            End If
            '</Snippet35>
        Finally
            forebrush.Dispose()
        End Try

        If Me.dataGridView1.CurrentCellAddress.Y = e.RowIndex Then
            ' Paint the focus rectangle.
            e.DrawFocus(rowBounds, True)
        End If

    End Sub 'dataGridView1_RowPostPaint
    '</Snippet30>

    '<Snippet40>
    ' Adjusts the padding when the user changes the row height so that 
    ' the normal cell content is fully displayed and any extra
    ' height is used for the content that spans multiple columns.
    Sub dataGridView1_RowHeightChanged(ByVal sender As Object, _
        ByVal e As DataGridViewRowEventArgs) _
        Handles dataGridView1.RowHeightChanged

        ' Calculate the new height of the normal cell content.
        Dim preferredNormalContentHeight As Int32 = _
            e.Row.GetPreferredHeight(e.Row.Index, _
            DataGridViewAutoSizeRowMode.AllCellsExceptHeader, True) - _
            e.Row.DefaultCellStyle.Padding.Bottom()

        ' Specify a new padding.
        Dim newPadding As Padding = e.Row.DefaultCellStyle.Padding
        newPadding.Bottom = e.Row.Height - preferredNormalContentHeight
        e.Row.DefaultCellStyle.Padding = newPadding

    End Sub
    '</Snippet40>

End Class 'DataGridViewRowPainting
'</Snippet00>