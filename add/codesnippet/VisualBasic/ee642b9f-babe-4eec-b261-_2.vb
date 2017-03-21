      Dim bigNumber As BigInteger = BigInteger.Pow(Int32.MaxValue, 2)
      Dim number As ULong = UInt64.MaxValue
      If BigInteger.op_GreaterThanOrEqual(bigNumber, number) Then
         ' Do something
      End If