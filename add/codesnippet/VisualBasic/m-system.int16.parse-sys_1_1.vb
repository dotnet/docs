      Dim stringToConvert As String
      Dim number As Short
      
      stringToConvert = " 214 "
      Try
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", _
                           stringToConvert)
      End Try
      
      stringToConvert = " + 214"                                 
      Try
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", _
                           stringToConvert)
      End Try
      
      stringToConvert = " +214 " 
      Try
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", _
                           stringToConvert)
      End Try
      ' The example displays the following output to the console:
      '       Converted ' 214 ' to 214.
      '       Unable to parse ' + 214'.
      '       Converted ' +214 ' to 214.