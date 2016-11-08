  Public Sub increase(ByVal a() As Long)
      For j As Integer = 0 To UBound(a)
          a(j) = a(j) + 1
      Next j
  End Sub