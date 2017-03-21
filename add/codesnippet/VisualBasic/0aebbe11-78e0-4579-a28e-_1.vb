      ' The statement
      '    Dim number As BigInteger = Int64.MaxValue * 3
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Multiply(Int64.MaxValue, 3)