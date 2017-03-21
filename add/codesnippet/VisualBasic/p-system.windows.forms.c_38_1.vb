Private Sub DrawCursorsOnForm(cursor As Cursor)
   ' If the form's cursor is not the Hand cursor and the 
   ' Current cursor is the Default, Draw the specified 
   ' cursor on the form in normal size and twice normal size. 
   If (Not Me.Cursor.Equals(Cursors.Hand)) And _
     Cursor.Current.Equals(Cursors.Default) Then

      ' Draw the cursor stretched.
      Dim graphics As Graphics = Me.CreateGraphics()
      Dim rectangle As New Rectangle(New Point(10, 10), _
        New Size(cursor.Size.Width * 2, cursor.Size.Height * 2))
      cursor.DrawStretched(graphics, rectangle)
     
      ' Draw the cursor in normal size.
      rectangle.Location = New Point(rectangle.Width + _
        rectangle.Location.X, rectangle.Height + rectangle.Location.Y)
      rectangle.Size = cursor.Size
      cursor.Draw(graphics, rectangle)

      ' Dispose of the cursor.
      cursor.Dispose()
   End If
End Sub