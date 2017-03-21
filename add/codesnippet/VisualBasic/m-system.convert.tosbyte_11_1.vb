      Dim numbers() As Byte = { Byte.MinValue, 10, 100, Byte.MaxValue }
      Dim result As SByte
      For Each number As Byte In numbers
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
      '    Converted the Byte value 0 to the SByte value 0.
      '    Converted the Byte value 10 to the SByte value 10.
      '    Converted the Byte value 100 to the SByte value 100.
      '    The Byte value 255 is outside the range of the SByte type.