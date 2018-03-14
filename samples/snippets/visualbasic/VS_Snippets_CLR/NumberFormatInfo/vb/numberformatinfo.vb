' <Snippet1>
Imports System.Globalization
Imports System.Text

Public Module Example
   Public Sub Main() 
      Dim sb As New StringBuilder()

      ' Loop through all the specific cultures known to the CLR.
      For Each ci In CultureInfo.GetCultures(CultureTypes.SpecificCultures) 
         ' Only show the currency symbols for cultures that speak English.
         If ci.TwoLetterISOLanguageName <> "en" Then Continue For

         ' <Snippet2>
         ' Display the culture name and currency symbol.
         Dim nfi As NumberFormatInfo = ci.NumberFormat
         sb.AppendFormat("The currency symbol for '{0}' is '{1}'",
                         ci.DisplayName, nfi.CurrencySymbol)
         sb.AppendLine()
         ' </Snippet2>
      Next
      Console.WriteLine(sb.ToString())
   End Sub
End Module
' The example displays output like the following:
'       The currency symbol for 'English (United States)' is '$'
'       The currency symbol for 'English (United Kingdom)' is '£'
'       The currency symbol for 'English (Australia)' is '$'
'       The currency symbol for 'English (Canada)' is '$'
'       The currency symbol for 'English (New Zealand)' is '$'
'       The currency symbol for 'English (Ireland)' is '?'
'       The currency symbol for 'English (South Africa)' is 'R'
'       The currency symbol for 'English (Jamaica)' is 'J$'
'       The currency symbol for 'English (Caribbean)' is '$'
'       The currency symbol for 'English (Belize)' is 'BZ$'
'       The currency symbol for 'English (Trinidad and Tobago)' is 'TT$'
'       The currency symbol for 'English (Zimbabwe)' is 'Z$'
'       The currency symbol for 'English (Republic of the Philippines)' is 'Php'
'       The currency symbol for 'English (India)' is 'Rs.'
'       The currency symbol for 'English (Malaysia)' is 'RM'
'       The currency symbol for 'English (Singapore)' is '$'
' </Snippet1>