' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Imports System.Globalization

Module StringParsing
   Public Sub Main()
      Dim numericString As String
      Dim styles As NumberStyles
      
      numericString = "106779"
      styles = NumberStyles.Integer
      CallTryParse(numericString, styles)
      
      numericString = "-30677"
      styles = NumberStyles.None
      CallTryParse(numericString, styles)
      
      styles = NumberStyles.AllowLeadingSign
      CallTryParse(numericString, styles)
      
      numericString = "301677-"
      CallTryParse(numericString, styles)
      
      styles = styles Or NumberStyles.AllowTrailingSign
      CallTryParse(numericString, styles)
      
      numericString = "$10634"
      styles = NumberStyles.Integer
      CallTryParse(numericString, styles)
      
      styles = NumberStyles.Integer Or NumberStyles.AllowCurrencySymbol
      CallTryParse(numericString, styles)

      numericString = "10345.00"
      styles = NumberStyles.Integer Or NumberStyles.AllowDecimalPoint
      CallTryParse(numericString, styles)
      
      numericString = "10345.72"
      styles = NumberStyles.Integer Or NumberStyles.AllowDecimalPoint
      CallTryParse(numericString, styles)

      numericString = "22,593" 
      styles = NumberStyles.Integer Or NumberStyles.AllowThousands
      CallTryParse(numericString, styles)
      
      numericString = "12E-01"
      styles = NumberStyles.Integer Or NumberStyles.AllowExponent
      CallTryParse(numericString, styles) 
          
      numericString = "12E03"
      CallTryParse(numericString, styles) 
      
      numericString = "80c1"
      CallTryParse(numericString, NumberStyles.HexNumber)
      
      numericString = "0x80C1"
      CallTryParse(numericString, NumberStyles.HexNumber)
   End Sub
   
   Private Sub CallTryParse(stringToConvert As String, styles AS NumberStyles)
      Dim number As Long
      Dim provider As CultureInfo
      
      ' If currency symbol is allowed, use en-US culture.
      If CBool(styles And NumberStyles.AllowCurrencySymbol) Then
         provider = CultureInfo.CurrentCulture
      Else
         provider = New CultureInfo("en-US")
      End If
      
      Dim result As Boolean = Int64.TryParse(stringToConvert, styles, _
                                             provider, number)
      If result Then
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Else
         Console.WriteLine("Attempted conversion of '{0}' failed.", _
                           Convert.ToString(stringToConvert))
      End If                                                                           
   End Sub
End Module
' The example displays the following output to the console:
'       Converted '106779' to 106779.
'       Attempted conversion of '-30677' failed.
'       Converted '-30677' to -30677.
'       Attempted conversion of '301677-' failed.
'       Converted '301677-' to -301677.
'       Attempted conversion of '$10634' failed.
'       Converted '$10634' to 10634.
'       Converted '10345.00' to 10345.
'       Attempted conversion of '10345.72' failed.
'       Converted '22,593' to 22593.
'       Attempted conversion of '12E-01' failed.
'       Converted '12E03' to 12000.
'       Converted '80c1' to 32961.
'       Attempted conversion of '0x80C1' failed.
' </Snippet2>
