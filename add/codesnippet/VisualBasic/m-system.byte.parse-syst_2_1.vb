      Dim stringToConvert As String 
      Dim byteValue As Byte
      
      stringToConvert = " 214 "
      Try
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try  
      
      stringToConvert = " + 214 "
      Try
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try  
      
      stringToConvert = " +214 "
      Try
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", _
                           stringToConvert, Byte.MaxValue, Byte.MinValue)
      End Try
      ' The example displays the following output to the console:
      '       Converted ' 214 ' to 214.
      '       Unable to parse ' + 214 '.
      '       Converted ' +214 ' to 214.