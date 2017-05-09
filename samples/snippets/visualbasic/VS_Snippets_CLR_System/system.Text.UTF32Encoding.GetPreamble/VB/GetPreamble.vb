' The following code example retrieves and displays the byte order mark for different UTF32Encoding instances.

' <Snippet1>
Imports System.Text

Public Class SamplesUTF32Encoding   
   Public Shared Sub Main()
      ' Create instances of UTF32Encoding, with the byte order mark and without.
      Dim u32LeNone As New UTF32Encoding()
      Dim u32BeNone As New UTF32Encoding(True, False)
      Dim u32LeBom As New UTF32Encoding(False, True)
      Dim u32BeBom As New UTF32Encoding(True, True)

      ' Display the preamble for each instance.
      PrintHexBytes(u32LeNone.GetPreamble())
      PrintHexBytes(u32BeNone.GetPreamble())
      PrintHexBytes(u32LeBom.GetPreamble())
      PrintHexBytes(u32BeBom.GetPreamble())
   End Sub

   Public Shared Sub PrintHexBytes(bytes() As Byte)
      If bytes Is Nothing OrElse bytes.Length = 0 Then
         Console.WriteLine("<none>")
      Else
         Dim i As Integer
         For i = 0 To bytes.Length - 1
            Console.Write("{0:X2} ", bytes(i))
         Next i
         Console.WriteLine()
      End If
   End Sub
End Class
'This example displays the following output:
'       FF FE 00 00
'       <none>
'       FF FE 00 00
'       00 00 FE FF
' </Snippet1>
