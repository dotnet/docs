  Public MustInherit Class shape
      Public acrossLine As Double
      Public MustOverride Function area() As Double
  End Class
  Public Class circle : Inherits shape
      Public Overrides Function area() As Double
          Return Math.PI * acrossLine
      End Function
  End Class
  Public Class square : Inherits shape
      Public Overrides Function area() As Double
          Return acrossLine * acrossLine
      End Function
  End Class
  Public Class consumeShapes
      Public Sub makeShapes()
          Dim shape1, shape2 As shape
          shape1 = New circle
          shape2 = New square
      End Sub
  End Class