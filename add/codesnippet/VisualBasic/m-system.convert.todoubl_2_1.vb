      Dim numbers() As Short = { Int16.MinValue, -1032, 0, 192, Int16.MaxValue }
      Dim result As Double
      
      For Each number As Short In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the UInt16 value {0} to {1}.", _
                           number, result)
      Next                     
      '       Converted the UInt16 value -32768 to -32768.
      '       Converted the UInt16 value -1032 to -1032.
      '       Converted the UInt16 value 0 to 0.
      '       Converted the UInt16 value 192 to 192.
      '       Converted the UInt16 value 32767 to 32767.