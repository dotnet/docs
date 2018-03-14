' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   Public Sub Main()
      CallTryParse1()
      Console.WriteLIne("-----")
      CallTryParse2()
   End Sub
   
   Private Sub CallTryParse1()
      ' <Snippet1>
      Dim value As String
      Dim number As Decimal
      
      ' Parse a floating-point value with a thousands separator.
      value = "1,643.57"
      If Decimal.TryParse(value, number) Then
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)      
      End If   
      
      ' Parse a floating-point value with a currency symbol and a 
      ' thousands separator.
      value = "$1,643.57"
      If Decimal.TryParse(value, number) Then
         Console.WriteLine(number)  
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse value in exponential notation.
      value = "-1.643e6"
      If Decimal.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse a negative integer value.
      value = "-1689346178821"
      If Decimal.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      ' The example displays the following output to the console:
      '       1643.57
      '       Unable to parse '$1,643.57'.
      '       Unable to parse '-1.643e6'.
      '       -1689346178821      
      ' </Snippet1>
   End Sub

   Private Sub CallTryParse2()
      ' <Snippet2>
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
      ' </Snippet2>   
   End Sub
End Module

