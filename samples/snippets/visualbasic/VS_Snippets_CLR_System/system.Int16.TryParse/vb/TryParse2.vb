' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Imports System.Globalization

Module StringParsing
   Public Sub Main()
      Dim numericString As String
      Dim styles As NumberStyles
      
      numericString = "10677"
      styles = NumberStyles.Integer
      CallTryParse(numericString, styles)
      
      numericString = "-30677"
      styles = NumberStyles.None
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
      Dim number As Short
      Dim result As Boolean = Int16.TryParse(stringToConvert, styles, _
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
'       Converted '10677' to 10677.
'       Attempted conversion of '-30677' failed.
'       Converted '10345.00' to 10345.
'       Attempted conversion of '10345.72' failed.
'       Converted '22,593' to 22593.
'       Attempted conversion of '12E-01' failed.
'       Converted '12E03' to 12000.
'       Converted '80c1' to -32575.
'       Attempted conversion of '0x80C1' failed.
' </Snippet2>
