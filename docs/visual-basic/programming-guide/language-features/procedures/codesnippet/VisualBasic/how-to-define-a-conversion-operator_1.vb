  Public Structure digit
  Private dig As Byte
      Public Sub New(ByVal b As Byte)
          If (b < 0 OrElse b > 9) Then Throw New System.ArgumentException(
              "Argument outside range for Byte")
          Me.dig = b
      End Sub
      Public Shared Widening Operator CType(ByVal d As digit) As Byte
          Return d.dig
      End Operator
      Public Shared Narrowing Operator CType(ByVal b As Byte) As digit
          Return New digit(b)
      End Operator
  End Structure