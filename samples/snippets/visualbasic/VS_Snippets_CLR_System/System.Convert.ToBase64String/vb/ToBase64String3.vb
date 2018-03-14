' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
       ' Define a byte array.
       Dim bytes(99) As Byte
       Dim originalTotal As Integer = 0
       For ctr As Integer = 0 To bytes.GetUpperBound(0)
          bytes(ctr) = CByte(ctr + 1)
          originalTotal += bytes(ctr)
       Next
       ' Display summary information about the array.
       Console.WriteLine("The original byte array:")
       Console.WriteLine("   Total elements: {0}", bytes.Length)
       Console.WriteLine("   Length of String Representation: {0}",
                         BitConverter.ToString(bytes).Length)
       Console.WriteLine("   Sum of elements: {0:N0}", originalTotal)                  
       Console.WriteLine()
       
       ' Convert the array to a base 64 sring.
       Dim s As String = Convert.ToBase64String(bytes, 
                                               Base64FormattingOptions.InsertLineBreaks)
       Console.WriteLine("The base 64 string:{1}   {0}{1}", 
                         s, vbCrLf)
       
       ' Restore the byte array.
       Dim newBytes() As Byte = Convert.FromBase64String(s)
       Dim newTotal As Integer = 0
       For Each newByte In newBytes
          newTotal += newByte
       Next
       ' Display summary information about the restored array.
       Console.WriteLine("   Total elements: {0}", newBytes.Length)
       Console.WriteLine("   Length of String Representation: {0}",
                         BitConverter.ToString(newBytes).Length)
       Console.WriteLine("   Sum of elements: {0:N0}", newTotal)                  
   End Sub
End Module
' The example displays the following output:
'   The original byte array:
'      Total elements: 100
'      Length of String Representation: 299
'      Sum of elements: 5,050
'   
'   The base 64 string:
'      AQIDBAUGBwgJCgsMDQ4PEBESExQVFhcYGRobHB0eHyAhIiMkJSYnKCkqKywtLi8wMTIzNDU2Nzg5
'   Ojs8PT4/QEFCQ0RFRkdISUpLTE1OT1BRUlNUVVZXWFlaW1xdXl9gYWJjZA==
'   
'      Total elements: 100
'      Length of String Representation: 299
'      Sum of elements: 5,050
' </Snippet3>
