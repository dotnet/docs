      ' The statement
      '    Dim number As BigInteger = Int64.MaxValue + Int32.MaxValue
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Add(Int64.MaxValue, Int32.MaxValue)