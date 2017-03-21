Public Function DoubleBufferingEnabled() As Boolean
   ' Get the value of the double-buffering style bits.
   Return Me.GetStyle((ControlStyles.DoubleBuffer _
     Or ControlStyles.UserPaint _
     Or ControlStyles.AllPaintingInWmPaint))
End Function