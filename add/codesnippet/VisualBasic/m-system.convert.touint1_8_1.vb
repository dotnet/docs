      Dim numbers() As SByte = { SByte.MinValue, -1, 0, 10, SByte.MaxValue }
      Dim result As UShort
      
      For Each number As SByte In numbers
         Try
            result = Convert.ToUInt16(number)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the UInt16 type.", number)
         End Try
      Next
      ' The example displays the following output:
      '    -128 is outside the range of the UInt16 type.
      '    -1 is outside the range of the UInt16 type.
      '    Converted the SByte value '0' to the UInt16 value 0.
      '    Converted the SByte value '10' to the UInt16 value 10.
      '    Converted the SByte value '127' to the UInt16 value 127.