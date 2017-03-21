      Dim numbers() As Short = { Int16.MinValue, 0, 40, 160, 255, 1028, _
                                 2011, Int16.MaxValue }
      Dim result As Char
      For Each number As Short In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next   
      ' The example displays the following output:
      '       -32768 is outside the range of the Char data type.
      '       0 converts to ' '.
      '       40 converts to '('.
      '       160 converts to ' '.
      '       255 converts to 'ÿ'.
      '       1028 converts to '?'.
      '       2011 converts to '?'.
      '       32767 converts to '?'.      