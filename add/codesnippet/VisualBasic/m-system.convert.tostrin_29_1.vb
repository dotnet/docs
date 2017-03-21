      Dim numbers() As Short = { Int16.MinValue, -138, 0, 19, Int16.MaxValue }
      Dim result As String
      
      For Each number As Short In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next     
      ' The example displays the following output:
      '    Converted the Int16 value -32768 to the String value -32768.
      '    Converted the Int16 value -138 to the String value -138.
      '    Converted the Int16 value 0 to the String value 0.
      '    Converted the Int16 value 19 to the String value 19.
      '    Converted the Int16 value 32767 to the String value 32767.