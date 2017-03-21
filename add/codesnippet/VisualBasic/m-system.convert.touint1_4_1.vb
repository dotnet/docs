      Dim numbers() As Long = { Int64.MinValue, -1, 0, 121, 340, Int64.MaxValue }
      Dim result As UShort
      For Each number As Long In numbers
         Try
            result = Convert.ToUInt16(number)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the UInt16 type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    The Int64 value -9223372036854775808 is outside the range of the UInt16 type.
      '    The Int64 value -1 is outside the range of the UInt16 type.
      '    Converted the Int64 value '0' to the UInt16 value 0.
      '    Converted the Int64 value '121' to the UInt16 value 121.
      '    Converted the Int64 value '340' to the UInt16 value 340.
      '    The Int64 value 9223372036854775807 is outside the range of the UInt16 type.