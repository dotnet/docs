  Public Sub replace(ByRef a() As Long)
      Dim k() As Long = {100, 200, 300}
      a = k
      For j As Integer = 0 To UBound(a)
          a(j) = a(j) + 1
      Next j
  End Sub