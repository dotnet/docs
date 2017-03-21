' Distance from Point to the specified x and y values method.
<SqlMethod(OnNullCall:=False, IsMutator:=False, InvokeIfReceiverIsNull:=False)> _
Public Function DistanceFromXY(ByVal ix As Int32, ByVal iy As Int32) _
    As Double

    Return Math.Sqrt(Math.Pow(ix - _x, 2.0) + Math.Pow(iy - _y, 2.0))

End Function