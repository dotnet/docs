      Dim numbers() As ULong = { UInt64.MinValue, 121, 340, UInt64.MaxValue }
      Dim result As UInteger
      
      For Each number As ULong In numbers
         Try
            result = Convert.ToUInt32(number)
            Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the UInt32 type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to a UInt32 value 0.
      '    Converted the UInt64 value 121 to a UInt32 value 121.
      '    Converted the UInt64 value 340 to a UInt32 value 340.
      '    The UInt64 value 18446744073709551615 is outside the range of the UInt32 type.