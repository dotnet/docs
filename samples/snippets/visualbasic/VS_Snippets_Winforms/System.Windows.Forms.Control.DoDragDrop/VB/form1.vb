'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents ListDragSource As System.Windows.Forms.ListBox
    Friend WithEvents ListDragTarget As System.Windows.Forms.ListBox
    Friend WithEvents UseCustomCursorsCheck As System.Windows.Forms.CheckBox
    Friend WithEvents DropLocationLabel As System.Windows.Forms.Label

    Private indexOfItemUnderMouseToDrag As Integer
    Private indexOfItemUnderMouseToDrop As Integer

    Private dragBoxFromMouseDown As Rectangle
    Private screenOffset as Point

    Private MyNoDropCursor As Cursor
    Private MyNormalCursor As Cursor

    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1())
    End Sub 'Main

    Public Sub New()
        MyBase.New()

        Me.ListDragSource = New System.Windows.Forms.ListBox()
        Me.ListDragTarget = New System.Windows.Forms.ListBox()
        Me.UseCustomCursorsCheck = New System.Windows.Forms.CheckBox()
        Me.DropLocationLabel = New System.Windows.Forms.Label()

        Me.SuspendLayout()

        ' ListDragSource
        Me.ListDragSource.Items.AddRange(New Object() {"one", "two", "three", "four", _
                                                            "five", "six", "seven", "eight", _
                                                            "nine", "ten"})
        Me.ListDragSource.Location = New System.Drawing.Point(10, 17)
        Me.ListDragSource.Size = New System.Drawing.Size(120, 225)

        ' ListDragTarget
        Me.ListDragTarget.AllowDrop = True
        Me.ListDragTarget.Location = New System.Drawing.Point(154, 17)
        Me.ListDragTarget.Size = New System.Drawing.Size(120, 225)

        ' UseCustomCursorsCheck
        Me.UseCustomCursorsCheck.Location = New System.Drawing.Point(10, 243)
        Me.UseCustomCursorsCheck.Size = New System.Drawing.Size(137, 24)
        Me.UseCustomCursorsCheck.Text = "Use Custom Cursors"

        ' DropLocationLabel
        Me.DropLocationLabel.Location = New System.Drawing.Point(154, 245)
        Me.DropLocationLabel.Size = New System.Drawing.Size(137, 24)
        Me.DropLocationLabel.Text = "None"

        ' Form1
        Me.ClientSize = New System.Drawing.Size(292, 270)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListDragSource, _
                                            Me.ListDragTarget, Me.UseCustomCursorsCheck, _
                                            Me.DropLocationLabel})

        Me.Text = "drag-and-drop Example"
        Me.ResumeLayout(False)
    End Sub

    Private Sub ListDragSource_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListDragSource.MouseDown

        ' Get the index of the item the mouse is below.
        indexOfItemUnderMouseToDrag = ListDragSource.IndexFromPoint(e.X, e.Y)

        If (indexOfItemUnderMouseToDrag <> ListBox.NoMatches) Then

            ' Remember the point where the mouse down occurred. The DragSize indicates
            ' the size that the mouse can move before a drag event should be started.                
            Dim dragSize As Size = SystemInformation.DragSize

            ' Create a rectangle using the DragSize, with the mouse position being
            ' at the center of the rectangle.
            dragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                            e.Y - (dragSize.Height / 2)), dragSize)
        Else
            ' Reset the rectangle if the mouse is not over an item in the ListBox.
            dragBoxFromMouseDown = Rectangle.Empty
        End If

    End Sub

    Private Sub ListDragSource_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListDragSource.MouseUp

        ' Reset the drag rectangle when the mouse button is raised.
        dragBoxFromMouseDown = Rectangle.Empty
    End Sub

    '<Snippet2>
    Private Sub ListDragSource_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListDragSource.MouseMove

        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            ' If the mouse moves outside the rectangle, start the drag.
            If (Rectangle.op_Inequality(dragBoxFromMouseDown, Rectangle.Empty) And _
                Not dragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                ' Creates custom cursors for the drag-and-drop operation.
                Try
                    MyNormalCursor = New Cursor("3dwarro.cur")
                    MyNoDropCursor = New Cursor("3dwno.cur")

                Catch
                    ' An error occurred while attempting to load the cursors so use
                    ' standard cursors.
                    UseCustomCursorsCheck.Checked = False
                Finally
                    ' The screenOffset is used to account for any desktop bands 
                    ' that may be at the top or left side of the screen when 
                    ' determining when to cancel the drag drop operation.
                    screenOffset = SystemInformation.WorkingArea.Location

                    ' Proceed with the drag-and-drop, passing in the list item.                    
                    Dim dropEffect As DragDropEffects = ListDragSource.DoDragDrop(ListDragSource.Items(indexOfItemUnderMouseToDrag), _
                                                                                  DragDropEffects.All Or DragDropEffects.Link)

                    ' If the drag operation was a move then remove the item.
                    If (dropEffect = DragDropEffects.Move) Then
                        ListDragSource.Items.RemoveAt(indexOfItemUnderMouseToDrag)

                        ' Select the previous item in the list as long as the list has an item.
                        If (indexOfItemUnderMouseToDrag > 0) Then
                            ListDragSource.SelectedIndex = indexOfItemUnderMouseToDrag - 1

                        ElseIf (ListDragSource.Items.Count > 0) Then
                            ' Selects the first item.
                            ListDragSource.SelectedIndex = 0
                        End If
                    End If

                    ' Dispose the cursors since they are no longer needed.
                    If (Not MyNormalCursor Is Nothing) Then _
                        MyNormalCursor.Dispose()

                    If (Not MyNoDropCursor Is Nothing) Then _
                        MyNoDropCursor.Dispose()
                End Try

            End If
        End If
    End Sub
    '</Snippet2>
    '<Snippet9>
    '<Snippet3>
    Private Sub ListDragSource_GiveFeedback(ByVal sender As Object, ByVal e As GiveFeedbackEventArgs) Handles ListDragSource.GiveFeedback

        ' Use custom cursors if the check box is checked.
        If (UseCustomCursorsCheck.Checked) Then

            ' Set the custom cursor based upon the effect.
            e.UseDefaultCursors = False
            If ((e.Effect And DragDropEffects.Move) = DragDropEffects.Move) Then
                Cursor.Current = MyNormalCursor
            Else
                Cursor.Current = MyNoDropCursor
            End If
        End If

    End Sub
    '</Snippet3>

    '<Snippet4>
    Private Sub ListDragTarget_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles ListDragTarget.DragOver
        ' Determine whether string data exists in the drop data. If not, then
        ' the drop effect reflects that the drop cannot occur.
        If Not (e.Data.GetDataPresent(GetType(System.String))) Then

            e.Effect = DragDropEffects.None
            DropLocationLabel.Text = "None - no string data."
            Return
        End If

        ' Set the effect based upon the KeyState.
        If ((e.KeyState And (8 + 32)) = (8 + 32) And _
            (e.AllowedEffect And DragDropEffects.Link) = DragDropEffects.Link) Then
            ' KeyState 8 + 32 = CTL + ALT

            ' Link drag-and-drop effect.
            e.Effect = DragDropEffects.Link

        ElseIf ((e.KeyState And 32) = 32 And _
            (e.AllowedEffect And DragDropEffects.Link) = DragDropEffects.Link) Then

            ' ALT KeyState for link.
            e.Effect = DragDropEffects.Link

        ElseIf ((e.KeyState And 4) = 4 And _
            (e.AllowedEffect And DragDropEffects.Move) = DragDropEffects.Move) Then

            ' SHIFT KeyState for move.
            e.Effect = DragDropEffects.Move

        ElseIf ((e.KeyState And 8) = 8 And _
            (e.AllowedEffect And DragDropEffects.Copy) = DragDropEffects.Copy) Then

            ' CTL KeyState for copy.
            e.Effect = DragDropEffects.Copy

        ElseIf ((e.AllowedEffect And DragDropEffects.Move) = DragDropEffects.Move) Then

            ' By default, the drop action should be move, if allowed.
            e.Effect = DragDropEffects.Move

        Else
            e.Effect = DragDropEffects.None
        End If

        ' Gets the index of the item the mouse is below. 

        ' The mouse locations are relative to the screen, so they must be 
        ' converted to client coordinates.

        indexOfItemUnderMouseToDrop = _
            ListDragTarget.IndexFromPoint(ListDragTarget.PointToClient(New Point(e.X, e.Y)))

        ' Updates the label text.
        If (indexOfItemUnderMouseToDrop <> ListBox.NoMatches) Then

            DropLocationLabel.Text = "Drops before item #" & (indexOfItemUnderMouseToDrop + 1)
        Else
            DropLocationLabel.Text = "Drops at the end."
        End If

    End Sub
    '</Snippet4>

    '<Snippet5>
    Private Sub ListDragTarget_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles ListDragTarget.DragDrop
        ' Ensures that the list item index is contained in the data.

        If (e.Data.GetDataPresent(GetType(System.String))) Then

            Dim item As Object = CType(e.Data.GetData(GetType(System.String)), System.Object)

            ' Perform drag-and-drop, depending upon the effect.
            If (e.Effect = DragDropEffects.Copy Or _
                e.Effect = DragDropEffects.Move) Then

                ' Insert the item.
                If (indexOfItemUnderMouseToDrop <> ListBox.NoMatches) Then
                    ListDragTarget.Items.Insert(indexOfItemUnderMouseToDrop, item)
                Else
                    ListDragTarget.Items.Add(item)

                End If
            End If
            ' Reset the label text.
            DropLocationLabel.Text = "None"
        End If
    End Sub
    '</Snippet5>
    '<Snippet6>
    Private Sub ListDragSource_QueryContinueDrag(ByVal sender As Object, ByVal e As QueryContinueDragEventArgs) Handles ListDragSource.QueryContinueDrag
        ' Cancel the drag if the mouse moves off the form.
        Dim lb as ListBox = CType(sender, System.Windows.Forms.ListBox)

        If (lb isNot nothing) Then

            Dim f as Form = lb.FindForm()

            ' Cancel the drag if the mouse moves off the form. The screenOffset
            ' takes into account any desktop bands that may be at the top or left
            ' side of the screen.
            If (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) Or _
                ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) Or _
                ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) Or _
                ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom)) Then

                e.Action = DragAction.Cancel
            End If
        End if
    End Sub
    '</Snippet6>
    '<Snippet7>
    Private Sub ListDragTarget_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles ListDragTarget.DragEnter

        ' Reset the label text.
        DropLocationLabel.Text = "None"
    End Sub
    '</Snippet7>
    '<Snippet8>
    Private Sub ListDragTarget_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListDragTarget.DragLeave

        ' Reset the label text.
        DropLocationLabel.Text = "None"
    End Sub
    '</Snippet8>
    '</Snippet9>
End Class
'</Snippet1>
