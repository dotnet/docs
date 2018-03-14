' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module modMain
   Public Sub Main()
      Dim byteString As String 
      
      byteString = " 123"
      ParseString(byteString, NumberStyles.None)
      ParseString(byteString, NumberStyles.Integer)
      
      byteString = "3A"
      ParseString(byteString, NumberStyles.AllowHexSpecifier) 
      
      byteString = "21"
      ParseString(byteString, NumberStyles.Integer)
      ParseString(byteString, NumberStyles.AllowHexSpecifier)
      
      byteString = "-22"
      ParseString(byteString, NumberStyles.Integer)
      ParseString(byteString, NumberStyles.AllowParentheses)
      
      byteString = "(45)"
      ParseString(byteString, NumberStyles.AllowParentheses)
     
      byteString = "000,000,056"
      ParseString(byteString, NumberStyles.Integer)
      ParseString(byteString, NumberStyles.Integer Or NumberStyles.AllowThousands)
   End Sub
   
   Private Sub ParseString(value As String, style As NumberStyles)
      Dim number As SByte
      
      If value Is Nothing Then Console.WriteLine("Cannot parse a null string...") 
      
      Try
         number = SByte.Parse(value, style, NumberFormatInfo.CurrentInfo)
         Console.WriteLine("SByte.Parse('{0}', {1}) = {2}", value, style, number)   
      Catch e As FormatException
         Console.WriteLine("'{0}' and {1} throw a FormatException", value, style)   
      Catch e As OverflowException
         Console.WriteLine("'{0}' is outside the range of a signed byte",
                           value)
      End Try     
   End Sub
End Module
' The example displays the following information to the console:
'       ' 123' and None throw a FormatException
'       SByte.Parse(" 123", Integer)) = 123
'       SByte.Parse("3A", AllowHexSpecifier)) = 58
'       SByte.Parse("21", Integer)) = 21
'       SByte.Parse("21", AllowHexSpecifier)) = 33
'       SByte.Parse("-22", Integer)) = -22
'       '-22' and AllowParentheses throw a FormatException
'       SByte.Parse("(45)", AllowParentheses)) = -45
'       '000,000,056' and Integer throw a FormatException
'       SByte.Parse("000,000,056", Integer, AllowThousands)) = 56
' </Snippet2>

