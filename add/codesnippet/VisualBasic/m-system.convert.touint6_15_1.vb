      Dim numbers() As UInteger = { UInt32.MinValue, 121, 340, UInt32.MaxValue }
      Dim result As ULong

      For Each number As UInteger In numbers
         result = Convert.ToUInt64(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt32 value 0 to the UInt64 value 0.
      '    Converted the UInt32 value 121 to the UInt64 value 121.
      '    Converted the UInt32 value 340 to the UInt64 value 340.
      '    Converted the UInt32 value 4294967295 to the UInt64 value 4294967295.