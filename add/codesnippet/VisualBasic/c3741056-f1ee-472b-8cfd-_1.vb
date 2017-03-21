      Dim value As String
      Dim style As NumberStyles
      Dim culture As CultureInfo
      Dim number As Decimal
      
      ' Parse currency value using en-GB culture.
      value = "£1,097.63"
      style = NumberStyles.Number Or NumberStyles.AllowCurrencySymbol
      culture = CultureInfo.CreateSpecificCulture("en-GB")
      If Decimal.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      ' Displays: 
      '       Converted '£1,097.63' to 1097.63.
      
      value = "1345,978"
      style = NumberStyles.AllowDecimalPoint
      culture = CultureInfo.CreateSpecificCulture("fr-FR")
      If Decimal.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      ' Displays:
      '       Converted '1345,978' to 1345.978.

      value = "1.345,978"
      style = NumberStyles.AllowDecimalPoint Or NumberStyles.AllowThousands
      culture = CultureInfo.CreateSpecificCulture("es-ES")
      If Decimal.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      ' Displays: 
      '       Converted '1.345,978' to 1345.978.
      
      value = "1 345,978"
      If Decimal.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      ' Displays:
      '       Unable to convert '1 345,978'.