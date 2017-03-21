Private Sub MoveCursor()
   ' Set the Current cursor, move the cursor's Position,
   ' and set its clipping rectangle to the form. 

   Me.Cursor = New Cursor(Cursor.Current.Handle)
   Cursor.Position = New Point(Cursor.Position.X - 50, Cursor.Position.Y - 50)
   Cursor.Clip = New Rectangle(Me.Location, Me.Size)
End Sub