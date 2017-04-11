' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim numericString As String
      Dim styles As NumberStyles
      
      numericString = "10603"
      styles = NumberStyles.Integer
      CallTryParse(numericString, styles)
      
      numericString = "-10603"
      styles = NumberStyles.None
      CallTryParse(numericString, styles)
      
      numericString = "29103.00"
      styles = NumberStyles.Integer Or NumberStyles.AllowDecimalPoint
      CallTryParse(numericString, styles)
      
      numericString = "10345.72"
      styles = NumberStyles.Integer Or NumberStyles.AllowDecimalPoint
      CallTryParse(numericString, styles)

      numericString = "2210E-01"
      styles = NumberStyles.Integer Or NumberStyles.AllowExponent
      CallTryParse(numericString, styles) 
      
      numericString = "9112E-01"
      CallTryParse(numericString, styles)
          
      numericString = "312E01"
      CallTryParse(numericString, styles) 
      
      numericString = "FFC8"
      CallTryParse(numericString, NumberStyles.HexNumber)
      
      numericString = "0x8F8C"
      CallTryParse(numericString, NumberStyles.HexNumber)
   End Sub
   
   Private Sub CallTryParse(stringToConvert As String, styles AS NumberStyles)
      Dim number As UShort
      Dim result As Boolean = UInt16.TryParse(stringToConvert, styles, _
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
'       Converted '10603' to 10603.
'       Attempted conversion of '-10603' failed.
'       Converted '29103.00' to 29103.
'       Attempted conversion of '10345.72' failed.
'       Converted '2210E-01' to 221.
'       Attempted conversion of '9112E-01' failed.
'       Converted '312E01' to 3120.
'       Converted 'FFC8' to 65480.
'       Attempted conversion of '0x8F8C' failed.
' </Snippet2>
