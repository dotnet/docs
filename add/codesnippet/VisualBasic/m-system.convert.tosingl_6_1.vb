      Dim numbers() As Byte = { Byte.MinValue, 10, 100, Byte.MaxValue }
      Dim result As Single
      
      For Each number As Byte In numbers
         result = Convert.ToSingle(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '       Converted the Byte value 0 to the Single value 0.
      '       Converted the Byte value 10 to the Single value 10.
      '       Converted the Byte value 100 to the Single value 100.
      '       Converted the Byte value 255 to the Single value 255.