Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeEvents
    ' <Snippet1>
    Private Sub RectangleShape1_Click() Handles RectangleShape1.Click
        ' Set properties to display a gradient fill.
        RectangleShape1.FillColor = Color.Blue
        RectangleShape1.FillGradientColor = Color.Red
        RectangleShape1.FillGradientStyle = 
          PowerPacks.FillGradientStyle.Horizontal
        RectangleShape1.FillStyle = PowerPacks.FillStyle.Solid
    End Sub
    ' </Snippet1>
    ' <Snippet2>
    Private Sub RectangleShape1_ContextMenuChanged(
      ) Handles RectangleShape1.ContextMenuChanged

        MsgBox("A new shortcut menu is available")
    End Sub
    ' </Snippet2>
    ' <Snippet3>
    Private Sub RectangleShape1_ContextMenuStripChanged(
      ) Handles RectangleShape1.ContextMenuStripChanged

        MsgBox("A new shortcut menu is available")
    End Sub
    ' </Snippet3>
    ' <Snippet4>
    Private Sub RectangleShape1_CursorChanged(
      ) Handles RectangleShape1.CursorChanged

        ToolStripStatusLabel1.Text = "This shape is currently disabled."
    End Sub
    ' </Snippet4>
    ' <Snippet5>
    Private Sub RectangleShape1_DoubleClick(
      ) Handles RectangleShape1.DoubleClick

        If RectangleShape1.BackColor = Color.Blue Then
            RectangleShape1.BackColor = Color.Red
        Else
            RectangleShape1.BackColor = Color.Blue
        End If
    End Sub
    ' </Snippet5>
    ' <Snippet6>
    Private Sub RectangleShape1_EnabledChanged(
      ) Handles RectangleShape1.EnabledChanged

        If RectangleShape1.Enabled = True Then
            ' Display a crosshair cursor.
            RectangleShape1.Cursor = Cursors.Cross
        End If
    End Sub
    ' </Snippet6>
    ' <Snippet7>
    Private Sub RectangleShape1_Enter(
      ) Handles RectangleShape1.Enter

        MsgBox("The rectangle has been selected.")
    End Sub
    ' </Snippet7>
    ' <Snippet8>
    Private Sub RectangleShape1_GotFocus(
      ) Handles RectangleShape1.GotFocus

        RectangleShape1.SelectionColor = Color.Red
    End Sub
    ' </Snippet8>
    ' <Snippet9>
    Private Sub Shapes_KeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.KeyEventArgs
      ) Handles RectangleShape1.KeyDown, OvalShape1.KeyDown, 
                LineShape1.KeyDown

        ' Check to see whether the TAB key was pressed.
        If e.KeyCode = Keys.Tab Then
            ' Call the Tab procedure
            Tab(sender)
        End If
    End Sub
    Private Sub Tab(ByVal sender As Shape)
        ' Select the next shape.
        sender.Parent.SelectNextShape(sender, True, True)
    End Sub
    ' </Snippet9>
    ' <Snippet10>
    Private Sub RectangleShape1_KeyPress(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.KeyPressEventArgs
      ) Handles RectangleShape1.KeyPress

        Dim ch As Char
        ch = e.KeyChar
        MsgBox("You pressed the " & ch & " key.")
    End Sub
    ' </Snippet10>
    ' <Snippet11>
    Private Sub OvalShape1_KeyUp(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.KeyEventArgs
      ) Handles OvalShape1.KeyUp

        ' Determine whether the key entered is the F1 key. 
        ' Display Help if it is.
        If e.KeyCode = Keys.F1 Then
            ' Display a pop-up Help message to assist the user.
            Help.ShowPopup(OvalShape1.Parent, 
              "This represents a router.", New Point(500, 500))
        End If
    End Sub
    ' </Snippet11>
    ' <Snippet12>
    Private Sub RectangleShape1_Leave() Handles RectangleShape1.Leave
        ' Restore the default BackColor.
        RectangleShape1.BackColor = PowerPacks.SimpleShape.DefaultBackColor
    End Sub
    ' </Snippet12>
    ' <Snippet13>
    Private Sub RectangleShape1_LostFocus() Handles RectangleShape1.LostFocus
        ' Restore the default BorderColor.
        RectangleShape1.BorderColor = 
          PowerPacks.SimpleShape.DefaultBorderColor
    End Sub
    ' </Snippet13>
    ' <Snippet14>
    Private Sub OvalShape1_MouseClick() Handles OvalShape1.MouseClick
        ' Display a crosshair cursor.
        OvalShape1.Cursor = Cursors.Cross
    End Sub

    ' </Snippet14>
    ' <Snippet15>
    Private Sub OvalShape1_MouseDoubleClick(
      ) Handles OvalShape1.MouseDoubleClick

        OvalShape1.BringToFront()
    End Sub

    ' </Snippet15>
    ' <Snippet16>
    Private mousePath = New System.Drawing.Drawing2D.GraphicsPath()

    Private Sub RectangleShape2_MouseDown(
        ByVal sender As Object, 
         ByVal e As System.Windows.Forms.MouseEventArgs
      ) Handles RectangleShape2.MouseDown

        Dim mouseDownLocation As New Point(e.X + RectangleShape2.Left, 
          e.Y + RectangleShape2.Top)
        ' Clear the previous line.
        mousePath.Dispose()
        mousePath = New System.Drawing.Drawing2D.GraphicsPath()
        RectangleShape2.Invalidate()
        ' Add a line to the graphics path.
        mousePath.AddLine(mouseDownLocation, mouseDownLocation)
    End Sub

    Private Sub RectangleShape2_MouseMove(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.MouseEventArgs
      ) Handles RectangleShape2.MouseMove

        Dim mouseX As Integer = e.X + RectangleShape2.Left
        Dim mouseY As Integer = e.Y + RectangleShape2.Top
        ' Add a line to the graphics path.
        mousePath.AddLine(mouseX, mouseY, mouseX, mouseY)
    End Sub

    Private Sub RectangleShape2_MouseUp(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.MouseEventArgs
      ) Handles RectangleShape2.MouseUp

        Dim mouseUpLocation = New System.Drawing.Point(e.X + 
          RectangleShape2.Left, e.Y + RectangleShape2.Top)
        ' Add a line to the graphics path.
        mousePath.Addline(mouseUpLocation, mouseUpLocation)
        ' Force the shape to redraw.
        RectangleShape2.Invalidate()
    End Sub

    Private Sub RectangleShape2_Paint(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.PaintEventArgs
      ) Handles RectangleShape2.Paint

        ' Draw the line.
        e.Graphics.DrawPath(System.Drawing.Pens.DarkRed, mousePath)
    End Sub
    ' </Snippet16>
    ' <Snippet17>
    Private Sub RectangleShape1_MouseEnter(
      ) Handles RectangleShape1.MouseEnter

        ToolStripStatusLabel1.Text = "The mouse has entered the shape."
    End Sub

    Private Sub RectangleShape1_MouseHover(
      ) Handles RectangleShape1.MouseHover

        ToolStripStatusLabel1.Text = "The mouse is paused over the shape."
    End Sub

    Private Sub RectangleShape1_MouseLeave(
      ) Handles RectangleShape1.MouseLeave

        ToolStripStatusLabel1.Text = "The mouse has left the shape."
    End Sub

    Private Sub RectangleShape1_MouseMove(
      ) Handles RectangleShape1.MouseMove

        ToolStripStatusLabel1.Text = "The mouse is over the shape."
    End Sub
    ' </Snippet17>
    ' <Snippet18>
    Private Sub RectangleShape1_MouseWheel(
        ByVal sender As Object, 
       ByVal e As System.Windows.Forms.MouseEventArgs
      ) Handles RectangleShape1.MouseWheel

        ' Move the shape vertically to correspond to the scrolling of the
        ' mouse wheel.
        Dim scale As Integer = e.Delta * 
          SystemInformation.MouseWheelScrollLines / 120
        RectangleShape1.Top = RectangleShape1.Top - scale
    End Sub
    ' </Snippet18>
    ' <Snippet19>
    Private Sub OvalShape1_Move() Handles OvalShape1.Move
        Dim rect As New Rectangle
        ' Get the bounding rectangle for the rectangle shape.
        rect = RectangleShape1.DisplayRectangle
        ' Determine whether the bounding rectangles overlap.
        If rect.IntersectsWith(OvalShape1.DisplayRectangle) Then
            ' Bring the oval shape to the front.
            OvalShape1.BringToFront()
        End If
    End Sub
    ' </Snippet19>
    ' <Snippet20>
    Private Sub OvalShape1_ParentChanged() Handles OvalShape1.ParentChanged
        MsgBox("The shape has been moved to a new container.")
    End Sub
    ' </Snippet20>
    ' <Snippet21>
    Private Sub OvalShape1_PreviewKeyDown(
       ByVal sender As Object, 
       ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs
      ) Handles OvalShape1.PreviewKeyDown

        If e.KeyCode = Keys.F1 Then
            ' Display a pop-up Help window to assist the user.
            Help.ShowPopup(OvalShape1.Parent, 
              "This shape represents a network node.", 
              PointToScreen(New Point(OvalShape1.Width, 
              OvalShape1.Height)))
        End If
    End Sub
    ' </Snippet21>
    ' <Snippet22>
    Private Sub OvalShape1_RegionChanged() Handles OvalShape1.RegionChanged
        ' Force the shape to repaint.
        OvalShape1.Invalidate()
    End Sub
    ' </Snippet22>
    ' <Snippet23>
    Private Sub OvalShape1_VisibleChanged() Handles OvalShape1.VisibleChanged
        ' Switch between the oval and rectangle shapes.
        If OvalShape1.Visible = False Then
            RectangleShape1.Visible = True
        Else
            RectangleShape1.Visible = False
        End If
    End Sub

    ' </Snippet23>

    Private Sub ShapeEvents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RectangleShape1.ContextMenu = ContextMenu1
    End Sub
End Class
