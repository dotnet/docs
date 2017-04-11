' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   Public Sub Main()
     CallParse()
     Console.WriteLine("-----")
     CallParseWithStyles()
     Console.WriteLine("-----")
     CallParseWithStylesAndProvider()
   End Sub
   
   Private Sub CallParse()
      ' <Snippet1>
      Dim value As String
      Dim number As Decimal
      
      ' Parse an integer with thousands separators. 
      value = "16,523,421"
      number = Decimal.Parse(value)
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays: 
      '    16,523,421' converted to 16523421.
      
      ' Parse a floating point value with thousands separators
      value = "25,162.1378"
      number = Decimal.Parse(value)
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays:
      '    25,162.1378' converted to 25162.1378.
      
      ' Parse a floating point number with US currency symbol.
      value = "$16,321,421.75"
      Try
         number = Decimal.Parse(value)
         Console.WriteLine("'{0}' converted to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)
      End Try
      ' Displays:
      '    Unable to parse '$16,321,421.75'.  
      
      ' Parse a number in exponential notation
      value = "1.62345e-02"
      Try
         number = Decimal.Parse(value)
         Console.WriteLine("'{0}' converted to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)
      End Try
      ' Displays: 
      '    Unable to parse '1.62345e-02'. 
      ' </Snippet1>
   End Sub

   Private Sub CallParseWithStyles()
      ' <Snippet2>
      Dim value As String
      Dim number As Decimal
      Dim style As NumberStyles
      
      ' Parse string with a floating point value using NumberStyles.None. 
      value = "8694.12"
      style = NumberStyles.None
      Try
         number = Decimal.Parse(value, style)  
         Console.WriteLine("'{0}' converted to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)
      End Try
      ' Displays:
      '    Unable to parse '8694.12'.
      
      ' Parse string with a floating point value and allow decimal point. 
      style = NumberStyles.AllowDecimalPoint
      number = Decimal.Parse(value, style)  
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays:
      '    '8694.12' converted to 8694.12.
      
      ' Parse string with negative value in parentheses
      value = "(1,789.34)"
      style = NumberStyles.AllowDecimalPoint Or NumberStyles.AllowThousands Or _
              NumberStyles.AllowParentheses 
      number = Decimal.Parse(value, style)  
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays:
      '    '(1,789.34)' converted to -1789.34.
      
      ' Parse string using Number style
      value = " -17,623.49 "
      style = NumberStyles.Number
      number = Decimal.Parse(value, style)  
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays:
      '    ' -17,623.49 ' converted to -17623.49.
      ' </Snippet2>   
   End Sub
   
   Private Sub CallParseWithStylesAndProvider()
      ' <Snippet3> 
      Dim value As String
      Dim number As Decimal
      Dim style As NumberStyles
      Dim provider As CultureInfo
      
      ' Parse string using "." as the thousands separator 
      ' and " " as the decimal separator. 
      value = "892 694,12"
      style = NumberStyles.AllowDecimalPoint Or NumberStyles.AllowThousands
      provider = New CultureInfo("fr-FR")

      number = Decimal.Parse(value, style, provider)  
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays: 
      '    892 694,12' converted to 892694.12.

      Try
         number = Decimal.Parse(value, style, CultureInfo.InvariantCulture)  
         Console.WriteLine("'{0}' converted to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)
      End Try
      ' Displays: 
      '    Unable to parse '892 694,12'.  
      
      ' Parse string using "$" as the currency symbol for en-GB and
      ' en-us cultures.
      value = "$6,032.51"
      style = NumberStyles.Number Or NumberStyles.AllowCurrencySymbol
      provider = New CultureInfo("en-GB")

      Try
         number = Decimal.Parse(value, style, provider)  
         Console.WriteLine("'{0}' converted to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", value)
      End Try
      ' Displays: 
      '    Unable to parse '$6,032.51'.

      provider = New CultureInfo("en-US")
      number = Decimal.Parse(value, style, provider)  
      Console.WriteLine("'{0}' converted to {1}.", value, number)
      ' Displays: 
      '    '$6,032.51' converted to 6032.51.
      ' </Snippet3>
   End Sub
End Module


