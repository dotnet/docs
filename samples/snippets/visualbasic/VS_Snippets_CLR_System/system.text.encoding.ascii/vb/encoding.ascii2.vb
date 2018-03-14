' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Module Example
   Public Sub Main()
      Dim enc As Encoding = Encoding.GetEncoding("us-ascii", 
                                                 New EncoderExceptionFallback(),
                                                 New DecoderExceptionFallback())
      Dim value As String = String.Format("{0} {1} {2}", 
                            ChrW(&h00C4), ChrW(&h00F6), ChrW(&h00AE))
      
      Try
         Dim bytes() As Byte = enc.GetBytes(value)
         For Each byt As Byte In bytes
            Console.Write("{0:X2} ", byt)
         Next       
         Console.WriteLine()
         Dim value2 As String = enc.GetString(bytes)
         Console.WriteLine(value2)
      Catch e As EncoderFallbackException
         Console.WriteLine("Unable to encode {0} at index {1}", 
                           If(e.IsUnknownSurrogate(), 
                              String.Format("U+{0:X4} U+{1:X4}", 
                                            Convert.ToUInt16(e.CharUnknownHigh),
                                            Convert.ToUInt16(e.CharUnknownLow)),
                              String.Format("U+{0:X4}", 
                                            Convert.ToUInt16(e.CharUnknown))),
                           e.Index)
      End Try
   End Sub
End Module
' The example displays the following output:
'       Unable to encode U+00C4 at index 0
' </Snippet1>
