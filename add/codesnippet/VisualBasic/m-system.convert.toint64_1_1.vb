      Dim numbers() As Short = { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue }
      Dim result As Long
      
      For Each number As Short In numbers
         result = Convert.ToInt64(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the Int16 value -32768 to the Int64 value -32768.
      '    Converted the Int16 value -1 to the Int64 value -1.
      '    Converted the Int16 value 0 to the Int64 value 0.
      '    Converted the Int16 value 121 to the Int64 value 121.
      '    Converted the Int16 value 340 to the Int64 value 340.
      '    Converted the Int16 value 32767 to the Int64 value 32767.