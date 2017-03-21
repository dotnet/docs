Public Sub EnableDoubleBuffering()
   ' Set the value of the double-buffering style bits to true.
   Me.SetStyle(ControlStyles.DoubleBuffer _
     Or ControlStyles.UserPaint _
     Or ControlStyles.AllPaintingInWmPaint, _
     True)
   Me.UpdateStyles()
End Sub