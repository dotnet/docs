' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text

Module Example
   Public Sub Main()
      Dim bytes() As Byte = { &h00, &h20, &hd8, &h01, &h00, &h68, &hA7, &h00}
      Dim enc As Encoding = New UnicodeEncoding(True, True, True)
      
      Try
         Dim value As String = enc.GetString(bytes)
         Console.WriteLine()
         Console.WriteLine("'{0}'", value)
      Catch e As DecoderFallbackException      
         Console.WriteLine("Unable to decode {0} at index {1}", 
                           ShowBytes(e.BytesUnknown), e.Index)
      End Try
   End Sub
   
   Private Function ShowBytes(bytes As Byte()) As String
      Dim returnString As String = Nothing
      For Each byteValue In bytes
         returnString += String.Format("0x{0:X2} ", byteValue)
      Next
      Return returnString.Trim()
   End Function
End Module
' The example displays the following output:
'       Unable to decode 0xD8 0x01 at index 4
' </Snippet2>
