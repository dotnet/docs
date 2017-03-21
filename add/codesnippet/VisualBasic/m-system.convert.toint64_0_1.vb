      Dim values() As Decimal = { Decimal.MinValue, -1034.23d, -12d, 0d, 147d, _
                                  199.55d, 9214.16d, Decimal.MaxValue }
      Dim result As Long
      
      For Each value As Decimal In values
         Try
            result = Convert.ToInt64(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Int64 type.", _
                              value)
         End Try   
      Next                                  
      ' The example displays the following output:
      '    -79228162514264337593543950335 is outside the range of the Int64 type.
      '    Converted the Decimal value '-1034.23' to the Int64 value -1034.
      '    Converted the Decimal value '-12' to the Int64 value -12.
      '    Converted the Decimal value '0' to the Int64 value 0.
      '    Converted the Decimal value '147' to the Int64 value 147.
      '    Converted the Decimal value '199.55' to the Int64 value 200.
      '    Converted the Decimal value '9214.16' to the Int64 value 9214.
      '    79228162514264337593543950335 is outside the range of the Int64 type.