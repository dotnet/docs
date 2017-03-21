      Dim numbers() As Short = { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue }
      Dim result As ULong
      
      For Each number As Short In numbers
         Try
            result = Convert.ToUInt64(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                                 number.GetType().Name, number, _
                                 result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.", _
                              number.GetType().Name, number)
         End Try   
      Next
      ' The example displays the following output:
      '    The Int16 value -32768 is outside the range of the UInt64 type.
      '    The Int16 value -1 is outside the range of the UInt64 type.
      '    Converted the Int16 value 0 to the UInt64 value 0.
      '    Converted the Int16 value 121 to the UInt64 value 121.
      '    Converted the Int16 value 340 to the UInt64 value 340.
      '    Converted the Int16 value 32767 to the UInt64 value 32767.