      Dim style As NumberStyles
      Dim culture As CultureInfo
      Dim value As String
      Dim number As Byte
      
      ' Parse number with decimals.
      ' NumberStyles.Float includes NumberStyles.AllowDecimalPoint.
      style = NumberStyles.Float       
      culture = CultureInfo.CreateSpecificCulture("fr-FR")
      value = "12,000"

      number = Byte.Parse(value, style, culture)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)

      culture = CultureInfo.CreateSpecificCulture("en-GB")
      Try
         number = Byte.Parse(value, style, culture)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End Try      

      value = "12.000"
      number = Byte.Parse(value, style, culture)
      Console.WriteLine("Converted '{0}' to {1}.", value, number)
      ' The example displays the following output to the console:
      '       Converted '12,000' to 12.
      '       Unable to parse '12,000'.
      '       Converted '12.000' to 12.