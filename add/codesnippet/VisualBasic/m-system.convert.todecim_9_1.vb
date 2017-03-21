      Dim numbers() As UInteger = { UInt32.MinValue, 121, 12345, UInt32.MaxValue }
      Dim result As Decimal
      
      For Each number As UInteger In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the UInt32 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '       Converted the UInt32 value 0 to 0.
      '       Converted the UInt32 value 121 to 121.
      '       Converted the UInt32 value 12345 to 12345.
      '       Converted the UInt32 value 4294967295 to 4294967295.