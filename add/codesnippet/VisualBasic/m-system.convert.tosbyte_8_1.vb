      Dim numbers() As Decimal = { Decimal.MinValue, -129.5d, -12.7d, 0d, 16d, _
                                   103.6d, 255.0d, Decimal.MaxValue }
      Dim result As SByte
      
      For Each number As Decimal In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next                         
      ' The example displays the following output:
      '    The Decimal value -79228162514264337593543950335 is outside the range of the SByte type.
      '    The Decimal value -129.5 is outside the range of the SByte type.
      '    Converted the Decimal value -12.7 to the SByte value -13.
      '    Converted the Decimal value 0 to the SByte value 0.
      '    Converted the Decimal value 16 to the SByte value 16.
      '    Converted the Decimal value 103.6 to the SByte value 104.
      '    The Decimal value 255 is outside the range of the SByte type.
      '    The Decimal value 79228162514264337593543950335 is outside the range of the SByte type.