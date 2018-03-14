' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module ByteConversion2
   Public Sub Main()
      Dim byteString As String 
      Dim styles As NumberStyles
      
      byteString = "1024"
      styles = NumberStyles.Integer
      CallTryParse(byteString, styles)
      
      byteString = "100.1"
      styles = NumberStyles.Integer Or NumberStyles.AllowDecimalPoint
      CallTryParse(byteString, styles)
      
      byteString = "100.0"
      CallTryParse(byteString, styles)
      
      byteString = "+100"
      styles = NumberStyles.Integer Or NumberStyles.AllowLeadingSign _
               Or NumberStyles.AllowTrailingSign
      CallTryParse(byteString, styles)
      
      byteString = "-100"
      CallTryParse(byteString, styles)
      
      byteString = "000000000000000100"
      CallTryParse(byteString, styles)
      
      byteString = "00,100"      
      styles = NumberStyles.Integer Or NumberStyles.AllowThousands
      CallTryParse(byteString, styles)
      
      byteString = "2E+3   "
      styles = NumberStyles.Integer Or NumberStyles.AllowExponent
      CallTryParse(byteString, styles)
      
      byteString = "FF"
      styles = NumberStyles.HexNumber
      CallTryParse(byteString, styles)
      
      byteString = "0x1F"
      CallTryParse(byteString, styles)
   End Sub
   
   Private Sub CallTryParse(stringToConvert As String, styles As NumberStyles)  
      Dim byteValue As Byte
      Dim result As Boolean = Byte.TryParse(stringToConvert, styles, Nothing, _
                                            byteValue)
      If result Then
         Console.WriteLine("Converted '{0}' to {1}", _
                        stringToConvert, byteValue)
      Else
         If stringToConvert Is Nothing Then stringToConvert = ""
         Console.WriteLine("Attempted conversion of '{0}' failed.", _
                           stringToConvert.ToString())
      End If                        
   End Sub
End Module
' The example displays the following output to the console:
'       Attempted conversion of '1024' failed.
'       Attempted conversion of '100.1' failed.
'       Converted '100.0' to 100
'       Converted '+100' to 100
'       Attempted conversion of '-100' failed.
'       Converted '000000000000000100' to 100
'       Converted '00,100' to 100
'       Attempted conversion of '2E+3   ' failed.
'       Converted 'FF' to 255
'       Attempted conversion of '0x1F' failed.
' </Snippet2>

