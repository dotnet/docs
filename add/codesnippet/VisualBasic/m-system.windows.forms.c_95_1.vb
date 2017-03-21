Private Sub AutoSizeControl(control As Control, textPadding As Integer)
   ' Create a Graphics object for the Control.
   Dim g As Graphics = control.CreateGraphics()
   
   ' Get the Size needed to accommodate the formatted Text.
   Dim preferredSize As Size = g.MeasureString( _
     control.Text, control.Font).ToSize()
   
   ' Pad the text and resize the control.
   control.ClientSize = New Size( _
     preferredSize.Width + textPadding * 2, _
     preferredSize.Height + textPadding * 2)
   
   ' Clean up the Graphics object.
   g.Dispose()
End Sub