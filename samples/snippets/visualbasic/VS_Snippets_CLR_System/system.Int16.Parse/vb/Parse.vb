' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain

   Public Sub Main()
      CallParse1()
      Console.WriteLine("-----")
      CallParse3()
      Console.WriteLine("-----")
      CallParse4()
   End Sub
   
   Private Sub CallParse1()
      ' <Snippet1>
      Dim value As String
      Dim number As Short
      
      value = " 12603 "
      Try
         number = Short.Parse(value)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", _
                           value)
      End Try
      
      value = " 16,054"
      Try
         number = Short.Parse(value)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", _
                           value)
      End Try
                              
      value = " -17264"
      Try
         number = Short.Parse(value)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}' to a 16-bit signed integer.", _
                           value)
      End Try
      ' The example displays the following output to the console:
      '       Converted ' 12603 ' to 12603.
      '       Unable to convert ' 16,054' to a 16-bit signed integer.
      '       Converted ' -17264' to -17264.      
      ' </Snippet1>
   End Sub
   
   Private Sub CallParse3()
      ' <Snippet3>
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
      ' </Snippet3>
   End Sub

   Private Sub CallParse4()
      ' <Snippet4>      
      Dim stringToConvert As String
      Dim number As Short
      
      stringToConvert = " 214 "
      Try
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", _
                           stringToConvert)
      End Try
      
      stringToConvert = " + 214"                                 
      Try
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", _
                           stringToConvert)
      End Try
      
      stringToConvert = " +214 " 
      Try
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Catch e As FormatException
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert)
      Catch e As OverflowException
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", _
                           stringToConvert)
      End Try
      ' The example displays the following output to the console:
      '       Converted ' 214 ' to 214.
      '       Unable to parse ' + 214'.
      '       Converted ' +214 ' to 214.
      ' </Snippet4>      
   End Sub
End Module

