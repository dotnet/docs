      Dim numbers() As ULong = { UInt64.MinValue, 1031, 189045, UInt64.MaxValue }
      Dim result As String
      
      For Each number As ULong In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to the String value 0.
      '    Converted the UInt64 value 1031 to the String value 1031.
      '    Converted the UInt64 value 189045 to the String value 189045.
      '    Converted the UInt64 value 18446744073709551615 to the String value 18446744073709551615.