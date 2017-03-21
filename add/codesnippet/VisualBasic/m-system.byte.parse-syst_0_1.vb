      Dim stringToConvert As String = " 162"
      Dim byteValue As Byte
      Try
         byteValue = Byte.Parse(stringToConvert)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try  
      ' The example displays the following output to the console:
      '       Converted ' 162' to 162.         