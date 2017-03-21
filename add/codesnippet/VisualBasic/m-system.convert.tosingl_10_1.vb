      Dim values() As Decimal = { Decimal.MinValue, -1034.23d, -12d, 0d, 147d, _
                                  199.55d, 9214.16d, Decimal.MaxValue }
      Dim result As Single
      
      For Each value As Decimal In values
         result = Convert.ToSingle(value)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           value.GetType().Name, value, _
                           result.GetType().Name, result)
      Next                                  
      ' The example displays the following output:
      '    Converted the Decimal value '-79228162514264337593543950335' to the Single value -7.922816E+28.
      '    Converted the Decimal value '-1034.23' to the Single value -1034.23.
      '    Converted the Decimal value '-12' to the Single value -12.
      '    Converted the Decimal value '0' to the Single value 0.
      '    Converted the Decimal value '147' to the Single value 147.
      '    Converted the Decimal value '199.55' to the Single value 199.55.
      '    Converted the Decimal value '9214.16' to the Single value 9214.16.
      '    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.