   Private Sub StatusBar1_DrawItem(ByVal sender As Object, ByVal sbdevent As System.Windows.Forms.StatusBarDrawItemEventArgs) Handles StatusBar1.DrawItem

      ' Create a StringFormat object to align text in the panel.
      Dim sf As New StringFormat()
      ' Format the String of the StatusBarPanel to be centered.
      sf.Alignment = StringAlignment.Center
      sf.LineAlignment = StringAlignment.Center

      ' Draw a black background in owner-drawn panel.
      sbdevent.Graphics.FillRectangle(Brushes.Black, sbdevent.Bounds)
      ' Draw the current date (short date format) with white text in the control's font.
      sbdevent.Graphics.DrawString(DateTime.Today.ToShortDateString(), StatusBar1.Font, Brushes.White, _
            New RectangleF(sbdevent.Bounds.X, sbdevent.Bounds.Y, _
            sbdevent.Bounds.Width, sbdevent.Bounds.Height), sf)
   End Sub