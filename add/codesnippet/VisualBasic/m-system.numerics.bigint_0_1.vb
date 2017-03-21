      ' The statement
      '    Dim number As BigInteger = -Int64.MinValue
      ' produces compiler error BC30439: Constant expression not representable in type 'Long'.
      ' The alternative:
      Dim number As BigInteger = BigInteger.Negate(Int64.MinValue)