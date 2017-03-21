      Dim numbers() As SByte = { SByte.MinValue, -12, 0, 16, SByte.MaxValue }
      Dim result As String
      
      For Each number As SByte In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the SByte value -128 to the String value -128.
      '    Converted the SByte value -12 to the String value -12.
      '    Converted the SByte value 0 to the String value 0.
      '    Converted the SByte value 16 to the String value 16.
      '    Converted the SByte value 127 to the String value 127.