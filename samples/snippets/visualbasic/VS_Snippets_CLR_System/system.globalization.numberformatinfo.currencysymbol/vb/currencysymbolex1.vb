' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim value As Decimal = 106.25d
      Console.WriteLine("Current Culture: {0}",
                        CultureInfo.CurrentCulture.Name)
      Console.WriteLine("Currency Symbol: {0}",
                        NumberFormatInfo.CurrentInfo.CurrencySymbol)
      Console.WriteLine("Currency Value:  {0:C2}", value)
   End Sub
End Module
' The example displays output like the following:
'       Current Culture: en-US
'       Currency Symbol: $
'       Currency Value:  $106.25
' </Snippet1>