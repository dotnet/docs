Protected Overrides Sub SetBoundsCore(x As Integer, _
  y As Integer, width As Integer, _
  height As Integer, specified As BoundsSpecified)
   ' Set a fixed height and width for the control.
   MyBase.SetBoundsCore(x, y, 150, 75, specified)
End Sub