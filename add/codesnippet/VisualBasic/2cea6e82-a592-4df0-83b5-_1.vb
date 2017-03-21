      ' The statement
      '    Dim number As BigInteger = Int64.MinValue - Int64.MaxValue
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Subtract(Int64.MinValue, Int64.MaxValue)