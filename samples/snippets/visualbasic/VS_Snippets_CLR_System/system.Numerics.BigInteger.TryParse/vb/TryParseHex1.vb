' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim hexStrings() As String = { "80", "E293", "F9A2FF", "FFFFFFFF", 
                                     "080", "0E293", "0F9A2FF", "0FFFFFFFF",  
                                     "0080", "00E293", "00F9A2FF", "00FFFFFFFF" }
      Dim number As BigInteger = BigInteger.Zero
      
      For Each hexString As String In hexStrings
         If BigInteger.TryParse(hexString, NumberStyles.AllowHexSpecifier, 
                                Nothing, number) Then
            Console.WriteLine("Converted 0x{0} to {1}.", hexString, number)
         Else
            Console.WriteLine("Cannot convert '{0}' to a BigInteger.", hexString)
         End If
      Next         
   End Sub
End Module
' The example displays the following output:
'       Converted 0x80 to -128.
'       Converted 0xE293 to -7533.
'       Converted 0xF9A2FF to -417025.
'       Converted 0xFFFFFFFF to -1.
'       Converted 0x080 to 128.
'       Converted 0x0E293 to 58003.
'       Converted 0x0F9A2FF to 16360191.
'       Converted 0x0FFFFFFFF to 4294967295.
'       Converted 0x0080 to 128.
'       Converted 0x00E293 to 58003.
'       Converted 0x00F9A2FF to 16360191.
'       Converted 0x00FFFFFFFF to 4294967295.
' </Snippet1>
