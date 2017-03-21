      Dim numbers() As UShort = { UInt16.MinValue, 121, 340, UInt16.MaxValue }
      Dim result As Integer
      For Each number As UShort In numbers
         Try
            result = Convert.ToInt32(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt16 value 0 to the Int32 value 0.
      '    Converted the UInt16 value 121 to the Int32 value 121.
      '    Converted the UInt16 value 340 to the Int32 value 340.
      '    Converted the UInt16 value 65535 to the Int32 value 65535.