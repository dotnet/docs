      Dim numbers() As ULong = { UInt64.MinValue, 121, 12345, UInt64.MaxValue }
      Dim result As Decimal
      
      For Each number As ULong In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the UInt64 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to 0.
      '    Converted the UInt64 value 121 to 121.
      '    Converted the UInt64 value 12345 to 12345.
      '    Converted the UInt64 value 18446744073709551615 to 18446744073709551615.