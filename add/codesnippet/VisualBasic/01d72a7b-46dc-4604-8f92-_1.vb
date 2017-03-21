      Dim bigNumber As BigInteger = BigInteger.Pow(2, 63) - BigInteger.One
      Dim uNumber As ULong = CULng(Int64.MaxValue And CULng(&h7FFFFFFFFFFFFFFF))
      If uNumber <> bigNumber Then
         ' Do something...
      End If