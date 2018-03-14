' Visual Basic .NET Document
Option Strict On

'Imports System.Globalization

Module Example
   Public Sub Main()
      DefaultTryParse()
      Console.WriteLine("----------")
      TryParseWithConstraints()
   End Sub
   
   Private Sub DefaultTryParse()
      ' <Snippet1>
      Dim value As String
      Dim number As Single
      
      ' Parse a floating-point value with a thousands separator.
      value = "1,643.57"
      If Single.TryParse(value, number) Then
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)      
      End If   
      
      ' Parse a floating-point value with a currency symbol and a 
      ' thousands separator.
      value = "$1,643.57"
      If Single.TryParse(value, number) Then
         Console.WriteLine(number)  
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse value in exponential notation.
      value = "-1.643e6"
      If Single.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse a negative integer number.
      value = "-168934617882109132"
      If Single.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      ' The example displays the following output:
      '       1643.57
      '       Unable to parse '$1,643.57'.
      '       -1643000
      '       -1.68934617882109E+17
      ' </Snippet1>
   End Sub
   
   Private Sub TryParseWithConstraints()
      ' <Snippet2>
      Dim value As String
      Dim style As System.Globalization.NumberStyles
      Dim culture As System.Globalization.CultureInfo
      Dim number As Single
      
      ' Parse currency value using en-GB culture.
      value = "£1,097.63"
      style = System.Globalization.NumberStyles.Number Or _
              System.Globalization.NumberStyles.AllowCurrencySymbol
      culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")
      If Single.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      
      value = "1345,978"
      style = System.Globalization.NumberStyles.AllowDecimalPoint
      culture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")
      If Single.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      
      value = "1.345,978"
      style = System.Globalization.NumberStyles.AllowDecimalPoint Or _
              System.Globalization.NumberStyles.AllowThousands
      culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES")
      If Single.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      
      value = "1 345,978"
      If Single.TryParse(value, style, culture, number) Then
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Else
         Console.WriteLine("Unable to convert '{0}'.", value)
      End If    
      ' The example displays the following output:
      '       Converted '£1,097.63' to 1097.63.
      '       Converted '1345,978' to 1345.978.
      '       Converted '1.345,978' to 1345.978.
      '       Unable to convert '1 345,978'.
      ' </Snippet2>   
   End Sub
End Module

