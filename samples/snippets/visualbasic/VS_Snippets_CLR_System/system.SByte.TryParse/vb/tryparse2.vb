' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module StringParsing
   Public Sub Main()
      Dim numericString As String
      Dim styles As NumberStyles
      
      numericString = "106"
      styles = NumberStyles.Integer
      CallTryParse(numericString, styles)
      
      numericString = "-106"
      styles = NumberStyles.None
      CallTryParse(numericString, styles)
      
      numericString = "103.00"
      styles = NumberStyles.Integer Or NumberStyles.AllowDecimalPoint
      CallTryParse(numericString, styles)
      
      numericString = "103.72"
      styles = NumberStyles.Integer Or NumberStyles.AllowDecimalPoint
      CallTryParse(numericString, styles)

      numericString = "10E-01"
      styles = NumberStyles.Integer Or NumberStyles.AllowExponent
      CallTryParse(numericString, styles) 
      
      numericString = "12E-01"
      CallTryParse(numericString, styles)
          
      numericString = "12E01"
      CallTryParse(numericString, styles) 
      
      numericString = "C8"
      CallTryParse(numericString, NumberStyles.HexNumber)
      
      numericString = "0x8C"
      CallTryParse(numericString, NumberStyles.HexNumber)
   End Sub
   
   Private Sub CallTryParse(stringToConvert As String, styles AS NumberStyles)
      Dim number As SByte
      Dim result As Boolean = SByte.TryParse(stringToConvert, styles, _
                                             CultureInfo.InvariantCulture, number)
      If result Then
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number)
      Else
         Console.WriteLine("Attempted conversion of '{0}' failed.", _
                           Convert.ToString(stringToConvert))
      End If                                                                           
   End Sub
End Module
' The example displays the following output to the console:
'       Converted '106' to 106.
'       Attempted conversion of '-106' failed.
'       Converted '103.00' to 103.
'       Attempted conversion of '103.72' failed.
'       Converted '10E-01' to 1.
'       Attempted conversion of '12E-01' failed.
'       Converted '12E01' to 120.
'       Converted 'C8' to -56.
'       Attempted conversion of '0x8C' failed.
' </Snippet2>
