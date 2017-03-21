      Dim numbers() As UShort = { UInt16.MinValue, 40, 160, 255, 1028, _
                                  2011, UInt16.MaxValue }
      Dim result As Char
      For Each number As UShort In numbers
         result = Convert.ToChar(number)
         Console.WriteLine("{0} converts to '{1}'.", number, result)
      Next   
      ' The example displays the following output:
      '       0 converts to ' '.
      '       40 converts to '('.
      '       160 converts to ' '.
      '       255 converts to 'ÿ'.
      '       1028 converts to '?'.
      '       2011 converts to '?'.
      '       65535 converts to '?'.