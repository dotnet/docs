      Dim value As String
      Dim number As Short
      Dim style As NumberStyles
      Dim provider As CultureInfo
      
      ' Parse string using "." as the thousands separator 
      ' and " " as the decimal separator.
      value = "19 694,00"
      style = NumberStyles.AllowDecimalPoint Or NumberStyles.AllowThousands
      provider = New CultureInfo("fr-FR")
      
      number = Int16.Parse(value, style, provider)
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays:
      '    '19 694,00' converted to 19694.

      Try
         number = Int16.Parse(value, style, CultureInfo.InvariantCulture)
         Console.WriteLine("'{0}' converted to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)
      End Try
      ' Displays:
      '    Unable to parse '19 694,00'.
      
      ' Parse string using "$" as the currency symbol for en_GB and
      ' en-US cultures.
      value = "$6,032.00"
      style = NumberStyles.Number Or NumberStyles.AllowCurrencySymbol
      provider = New CultureInfo("en-GB")
      
      Try
         number = Int16.Parse(value, style, CultureInfo.InvariantCulture)
         Console.WriteLine("'{0}' converted to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)
      End Try
      ' Displays:
      '    Unable to parse '$6,032.00'.
                              
      provider = New CultureInfo("en-US")
      number = Int16.Parse(value, style, provider)
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays:
      '    '$6,032.00' converted to 6032.      