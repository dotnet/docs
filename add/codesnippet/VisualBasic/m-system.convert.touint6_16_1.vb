      Dim numbers() As UShort = { UInt16.MinValue, 121, 340, UInt16.MaxValue }
      Dim result As ULong

      For Each number As UShort In numbers
         result = Convert.ToUInt64(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt16 value 0 to the UInt64 value 0.
      '    Converted the UInt16 value 121 to the UInt64 value 121.
      '    Converted the UInt16 value 340 to the UInt64 value 340.
      '    Converted the UInt16 value 65535 to the UInt64 value 65535.