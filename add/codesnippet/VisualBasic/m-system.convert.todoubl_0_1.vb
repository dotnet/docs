      Dim numbers() As UShort = { UInt16.MinValue, 121, 12345, UInt16.MaxValue }
      Dim result As Double
      
      For Each number As UShort In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the UInt16 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '       Converted the UInt16 value 0 to 0.
      '       Converted the UInt16 value 121 to 121.
      '       Converted the UInt16 value 12345 to 12345.
      '       Converted the UInt16 value 65535 to 65535.      