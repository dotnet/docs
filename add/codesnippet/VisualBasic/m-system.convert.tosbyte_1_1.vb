      Dim numbers() As UInteger = { UInt32.MinValue, 121, 340, UInt32.MaxValue }
      Dim result As SByte
      For Each number As UInteger In numbers
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
      '    Converted the UInt32 value 0 to the SByte value 0.
      '    Converted the UInt32 value 121 to the SByte value 121.
      '    The UInt32 value 340 is outside the range of the SByte type.
      '    The UInt32 value 4294967295 is outside the range of the SByte type.