      Dim values() As Decimal = { Decimal.MinValue, -1034.23d, -12d, 0d, 147d, _
                                  9214.16d, Decimal.MaxValue }
      Dim result As Short
      
      For Each value As Decimal In values
         Try
            result = Convert.ToInt16(value)
            Console.WriteLine("Converted {0} to {1}.", value, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Int16 type.", _
                              value)
         End Try   
      Next                                  
      ' The example displays the following output:
      '    -79228162514264337593543950335 is outside the range of the Int16 type.
      '    Converted -1034.23 to -1034.
      '    Converted -12 to -12.
      '    Converted 0 to 0.
      '    Converted 147 to 147.
      '    Converted 9214.16 to 9214.
      '    79228162514264337593543950335 is outside the range of the Int16 type.