   Private Sub DecimalToCurrencyString(sender As Object, cevent As ConvertEventArgs)
      ' The method converts only to string type. 
      If cevent.DesiredType IsNot GetType(String) Then
         Return
      End If 
      cevent.Value = CDec(cevent.Value).ToString("c")
   End Sub 
    
    
   Private Sub CurrencyStringToDecimal(sender As Object, cevent As ConvertEventArgs)
      ' The method converts only to decimal type.
      If cevent.DesiredType IsNot GetType(Decimal) Then
         Return
      End If 
    cevent.Value = Decimal.Parse(cevent.Value.ToString, _
    NumberStyles.Currency, nothing)
   End Sub 