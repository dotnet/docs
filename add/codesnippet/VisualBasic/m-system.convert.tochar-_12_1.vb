      Dim bytes() As Byte = {Byte.MinValue, 40, 80, 120, 180, Byte.MaxValue}
      Dim result As Char
      For Each number As Byte In bytes
         result = Convert.ToChar(number)
         Console.WriteLine("{0} converts to '{1}'.", number, result)
      Next
      ' The example displays the following output:
      '       0 converts to ' '.
      '       40 converts to '('.
      '       80 converts to 'P'.
      '       120 converts to 'x'.
      '       180 converts to '''.
      '       255 converts to 'ÿ'.      