      Dim numbers() As Short = { Int16.MinValue, -1032, 0, 192, Int16.MaxValue }
      Dim result As Single
      
      For Each number As Short In numbers
         result = Convert.ToSingle(number)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next                     
      ' The example displays the following output:
      '    Converted the Int16 value '-32768' to the Single value -32768.
      '    Converted the Int16 value '-1032' to the Single value -1032.
      '    Converted the Int16 value '0' to the Single value 0.
      '    Converted the Int16 value '192' to the Single value 192.
      '    Converted the Int16 value '32767' to the Single value 32767.