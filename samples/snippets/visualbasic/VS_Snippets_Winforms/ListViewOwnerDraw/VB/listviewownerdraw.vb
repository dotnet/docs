'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms

Public Class ListViewOwnerDraw
    Inherits Form
    Private WithEvents listView1 As New ListView()
    Private WithEvents contextMenu1 As New ContextMenu()
    Private WithEvents listMenuItem As New MenuItem("List")
    Private WithEvents detailsMenuItem As New MenuItem("Details")

    '<Snippet2>
    Public Sub New()

        ' Initialize the shortcut menu. 
        contextMenu1.MenuItems.AddRange(New MenuItem() _
            {Me.listMenuItem, Me.detailsMenuItem})

        ' Initialize the ListView control.
        With Me.listView1
            .BackColor = Color.Black
            .ForeColor = Color.White
            .Dock = DockStyle.Fill
            .View = View.Details
            .FullRowSelect = True
            .OwnerDraw = True
            .ContextMenu = Me.contextMenu1
        End With

        ' Add columns to the ListView control.
        With Me.listView1.Columns
            .Add("Name", 100, HorizontalAlignment.Center)
            .Add("First", 100, HorizontalAlignment.Center)
            .Add("Second", 100, HorizontalAlignment.Center)
            .Add("Third", 100, HorizontalAlignment.Center)
        End With

        ' Create items and add them to the ListView control.
        Dim listViewItem1 As New ListViewItem(New String() _
            {"One", "20", "30", "-40"}, -1)
        Dim listViewItem2 As New ListViewItem(New String() _
            {"Two", "-250", "145", "37"}, -1)
        Dim listViewItem3 As New ListViewItem(New String() _
            {"Three", "200", "800", "-1,001"}, -1)
        Dim listViewItem4 As New ListViewItem(New String() _
            {"Four", "not available", "-2", "100"}, -1)
        Me.listView1.Items.AddRange(New ListViewItem() _
            {listViewItem1, listViewItem2, listViewItem3, listViewItem4})

        ' Initialize the form and add the ListView control to it.
        With Me
            .ClientSize = New Size(450, 150)
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .MaximizeBox = False
            .Text = "ListView OwnerDraw Example"
            .Controls.Add(Me.listView1)
        End With

    End Sub
    '</Snippet2>

    ' Clean up any resources being used.        
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            contextMenu1.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New ListViewOwnerDraw())
    End Sub

    ' Sets the ListView control to the List view.
    Private Sub menuItemList_Click(ByVal sender As Object, _
        ByVal e As EventArgs) _
        Handles listMenuItem.Click

        Me.listView1.View = View.List

    End Sub

    ' Sets the ListView control to the Details view.
    Private Sub menuItemDetails_Click(ByVal sender As Object, _
        ByVal e As EventArgs) _
        Handles detailsMenuItem.Click

        Me.listView1.View = View.Details

        ' Reset the tag on each item to re-enable the workaround 
        ' in the MouseMove event handler.
        For Each item As ListViewItem In listView1.Items
            item.Tag = Nothing
        Next

    End Sub

    ' Selects and focuses an item when it is clicked anywhere along 
    ' its width. The click must normally be on the parent item text.
    Private Sub listView1_MouseUp(ByVal sender As Object, _
        ByVal e As MouseEventArgs) _
        Handles listView1.MouseUp

        Dim clickedItem As ListViewItem = Me.listView1.GetItemAt(5, e.Y)
        If (clickedItem IsNot Nothing) Then
            clickedItem.Selected = True
            clickedItem.Focused = True
        End If

    End Sub

    '<Snippet3>
    ' Draws the backgrounds for entire ListView items.
    Private Sub listView1_DrawItem(ByVal sender As Object, _
        ByVal e As DrawListViewItemEventArgs) _
        Handles listView1.DrawItem

        If Not (e.State And ListViewItemStates.Selected) = 0 Then

            ' Draw the background for a selected item.
            e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds)
            e.DrawFocusRectangle()

        Else

            ' Draw the background for an unselected item.
            Dim brush As New LinearGradientBrush(e.Bounds, Color.Orange, _
                Color.Maroon, LinearGradientMode.Horizontal)
            Try
                e.Graphics.FillRectangle(brush, e.Bounds)
            Finally
                brush.Dispose()
            End Try

        End If

        ' Draw the item text for views other than the Details view.
        If Not Me.listView1.View = View.Details Then
            e.DrawText()
        End If

    End Sub
    '</Snippet3>

    '<Snippet4>
    ' Draws subitem text and applies content-based formatting.
    Private Sub listView1_DrawSubItem(ByVal sender As Object, _
        ByVal e As DrawListViewSubItemEventArgs) _
        Handles listView1.DrawSubItem

        Dim flags As TextFormatFlags = TextFormatFlags.Left

        Dim sf As New StringFormat()
        Try

            ' Store the column text alignment, letting it default
            ' to Left if it has not been set to Center or Right.
            Select Case e.Header.TextAlign
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                    flags = TextFormatFlags.HorizontalCenter
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
                    flags = TextFormatFlags.Right
            End Select

            ' Draw the text and background for a subitem with a 
            ' negative value. 
            Dim subItemValue As Double
            If e.ColumnIndex > 0 AndAlso _
                Double.TryParse(e.SubItem.Text, NumberStyles.Currency, _
                NumberFormatInfo.CurrentInfo, subItemValue) AndAlso _
                subItemValue < 0 Then

                ' Unless the item is selected, draw the standard 
                ' background to make it stand out from the gradient.
                If (e.ItemState And ListViewItemStates.Selected) = 0 Then
                    e.DrawBackground()
                End If

                ' Draw the subitem text in red to highlight it. 
                e.Graphics.DrawString(e.SubItem.Text, _
                    Me.listView1.Font, Brushes.Red, e.Bounds, sf)

                Return

            End If

            ' Draw normal text for a subitem with a nonnegative 
            ' or nonnumerical value.
            e.DrawText(flags)

        Finally
            sf.Dispose()
        End Try

    End Sub
    '</Snippet4>

    '<Snippet5>
    ' Draws column headers.
    Private Sub listView1_DrawColumnHeader(ByVal sender As Object, _
        ByVal e As DrawListViewColumnHeaderEventArgs) _
        Handles listView1.DrawColumnHeader

        Dim sf As New StringFormat()
        Try

            ' Store the column text alignment, letting it default
            ' to Left if it has not been set to Center or Right.
            Select Case e.Header.TextAlign
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
            End Select

            ' Draw the standard header background.
            e.DrawBackground()

            ' Draw the header text.
            Dim headerFont As New Font("Helvetica", 10, FontStyle.Bold)
            Try
                e.Graphics.DrawString(e.Header.Text, headerFont, _
                    Brushes.Black, e.Bounds, sf)
            Finally
                headerFont.Dispose()
            End Try

        Finally
            sf.Dispose()
        End Try

    End Sub
    '</Snippet5>

    ' Forces each row to repaint itself the first time the mouse moves over 
    ' it, compensating for an extra DrawItem event sent by the wrapped 
    ' Win32 control.
    Private Sub listView1_MouseMove(ByVal sender As Object, _
        ByVal e As MouseEventArgs) _
        Handles listView1.MouseMove

        Dim item As ListViewItem = listView1.GetItemAt(e.X, e.Y)
        If item IsNot Nothing AndAlso item.Tag Is Nothing Then
            listView1.Invalidate(item.Bounds)
            item.Tag = "tagged"
        End If

    End Sub

    ' Resets the item tags. 
    Private Sub listView1_Invalidated(ByVal sender As Object, _
        ByVal e As InvalidateEventArgs) Handles listView1.Invalidated

        For Each item As ListViewItem In listView1.Items
            If item Is Nothing Then Return
            item.Tag = Nothing
        Next

    End Sub

    ' Forces the entire control to repaint if a column width is changed.
    Private Sub listView1_ColumnWidthChanged(ByVal sender As Object, _
        ByVal e As ColumnWidthChangedEventArgs) Handles listView1.ColumnWidthChanged

        listView1.Invalidate()

    End Sub

End Class
'</Snippet1>