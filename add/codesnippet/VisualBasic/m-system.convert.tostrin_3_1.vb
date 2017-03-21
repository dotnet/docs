      Dim numbers() As UInteger = { UInt32.MinValue, 103, 1045, 119543, UInt32.MaxValue }
      Dim result As String
      
      For Each number As UInteger In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt32 value 0 to the String value 0.
      '    Converted the UInt32 value 103 to the String value 103.
      '    Converted the UInt32 value 1045 to the String value 1045.
      '    Converted the UInt32 value 119543 to the String value 119543.
      '    Converted the UInt32 value 4294967295 to the String value 4294967295.