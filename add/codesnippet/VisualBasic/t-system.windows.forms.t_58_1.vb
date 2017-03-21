   Friend Class StackRenderer
      Inherits ToolStripProfessionalRenderer
      Private Shared titleBarGripBmp As Bitmap
      Private Shared titleBarGripEnc As String = "Qk16AQAAAAAAADYAAAAoAAAAIwAAAAMAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAAuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5ANj+RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5ANj+RzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMANj+"
      
      ' Define titlebar colors.
      Private Shared titlebarColor1 As Color = Color.FromArgb(89, 135, 214)
      Private Shared titlebarColor2 As Color = Color.FromArgb(76, 123, 204)
      Private Shared titlebarColor3 As Color = Color.FromArgb(63, 111, 194)
      Private Shared titlebarColor4 As Color = Color.FromArgb(50, 99, 184)
      Private Shared titlebarColor5 As Color = Color.FromArgb(38, 88, 174)
      Private Shared titlebarColor6 As Color = Color.FromArgb(25, 76, 164)
      Private Shared titlebarColor7 As Color = Color.FromArgb(12, 64, 154)
      Private Shared borderColor As Color = Color.FromArgb(0, 0, 128)
      
      Shared Sub New()
         titleBarGripBmp = StackView.DeserializeFromBase64(titleBarGripEnc)
        End Sub
      
      Public Sub New()
        End Sub
      
        Private Sub DrawTitleBar(ByVal g As Graphics, ByVal rect As Rectangle)

            ' Assign the image for the grip.
            Dim titlebarGrip As Image = titleBarGripBmp

            ' Fill the titlebar. 
            ' This produces the gradient and the rounded-corner effect.
            g.DrawLine(New Pen(titlebarColor1), rect.X, rect.Y, rect.X + rect.Width, rect.Y)
            g.DrawLine(New Pen(titlebarColor2), rect.X, rect.Y + 1, rect.X + rect.Width, rect.Y + 1)
            g.DrawLine(New Pen(titlebarColor3), rect.X, rect.Y + 2, rect.X + rect.Width, rect.Y + 2)
            g.DrawLine(New Pen(titlebarColor4), rect.X, rect.Y + 3, rect.X + rect.Width, rect.Y + 3)
            g.DrawLine(New Pen(titlebarColor5), rect.X, rect.Y + 4, rect.X + rect.Width, rect.Y + 4)
            g.DrawLine(New Pen(titlebarColor6), rect.X, rect.Y + 5, rect.X + rect.Width, rect.Y + 5)
            g.DrawLine(New Pen(titlebarColor7), rect.X, rect.Y + 6, rect.X + rect.Width, rect.Y + 6)

            ' Center the titlebar grip.
            g.DrawImage(titlebarGrip, New Point(rect.X + (rect.Width / 2 - titlebarGrip.Width / 2), rect.Y + 1))
        End Sub
      
      
      ' This method handles the RenderGrip event.
      Protected Overrides Sub OnRenderGrip(e As ToolStripGripRenderEventArgs)
         DrawTitleBar(e.Graphics, New Rectangle(0, 0, e.ToolStrip.Width, 7))
        End Sub
      
      
      ' This method handles the RenderToolStripBorder event.
      Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
         DrawTitleBar(e.Graphics, New Rectangle(0, 0, e.ToolStrip.Width, 7))
        End Sub
      
      
      ' This method handles the RenderButtonBackground event.
      Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
         Dim g As Graphics = e.Graphics
         Dim bounds As New Rectangle(Point.Empty, e.Item.Size)
         
         Dim gradientBegin As Color = Color.FromArgb(203, 225, 252)
         Dim gradientEnd As Color = Color.FromArgb(125, 165, 224)
         
            Dim button As ToolStripButton = CType(e.Item, ToolStripButton)
         
         If button.Pressed OrElse button.Checked Then
            gradientBegin = Color.FromArgb(254, 128, 62)
            gradientEnd = Color.FromArgb(255, 223, 154)
         ElseIf button.Selected Then
            gradientBegin = Color.FromArgb(255, 255, 222)
            gradientEnd = Color.FromArgb(255, 203, 136)
         End If
         
         Dim b = New LinearGradientBrush(bounds, gradientBegin, gradientEnd, LinearGradientMode.Vertical)
         Try
            g.FillRectangle(b, bounds)
         Finally
            b.Dispose()
         End Try
         
         e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, bounds)
         
         g.DrawLine(SystemPens.ControlDarkDark, bounds.X, bounds.Y, bounds.Width - 1, bounds.Y)
         
         g.DrawLine(SystemPens.ControlDarkDark, bounds.X, bounds.Y, bounds.X, bounds.Height - 1)
         
         Dim toolStrip As ToolStrip = button.Owner
            Dim nextItem As ToolStripButton = CType(button.Owner.GetItemAt(button.Bounds.X, button.Bounds.Bottom + 1), ToolStripButton)
         
         If nextItem Is Nothing Then
            g.DrawLine(SystemPens.ControlDarkDark, bounds.X, bounds.Height - 1, bounds.X + bounds.Width - 1, bounds.Height - 1)
         End If
        End Sub
    End Class