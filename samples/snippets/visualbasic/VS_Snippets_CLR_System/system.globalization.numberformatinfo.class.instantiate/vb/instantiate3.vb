' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim culture As CultureInfo
      Dim nfi As NumberFormatInfo
      
      culture = CultureInfo.CurrentCulture
      nfi = culture.NumberFormat
      Console.WriteLine("Culture Name:    {0}", culture.Name)
      Console.WriteLine("User Overrides:  {0}", culture.UseUserOverride)
      Console.WriteLine("Currency Symbol: {0}", culture.NumberFormat.CurrencySymbol)
      Console.WriteLine()
            
      culture = New CultureInfo(CultureInfo.CurrentCulture.Name, False)
      Console.WriteLine("Culture Name:    {0}", culture.Name)
      Console.WriteLine("User Overrides:  {0}", culture.UseUserOverride)
      Console.WriteLine("Currency Symbol: {0}", culture.NumberFormat.CurrencySymbol)
   End Sub
End Module
' The example displays the following output:
'       Culture Name:    en-US
'       User Overrides:  True
'       Currency Symbol: USD
'       
'       Culture Name:    en-US
'       User Overrides:  False
'       Currency Symbol: $
' </Snippet3>
