' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Create an Integer from a 4-byte array.
      Dim bytes1() As Byte = { &hEC, &h00, &h00, &h00 }
      Console.WriteLine("{0}--> 0x{1:X4} ({1:N0})", FormatBytes(bytes1),
                                      BitConverter.ToInt32(bytes1, 0))
      ' Create an Integer from the upper four bytes of a byte array.
      Dim bytes2() As Byte = BitConverter.GetBytes(Int64.MaxValue \ 2)
      Console.WriteLine("{0}--> 0x{1:X4} ({1:N0})", FormatBytes(bytes2),
                                      BitConverter.ToInt32(bytes2, 4))
      
      ' Round-trip an integer value.
      Dim original As Integer = CInt(16^3)
      Dim bytes3() As Byte = BitConverter.GetBytes(original)
      Dim restored As Integer = BitConverter.ToInt32(bytes3, 0)
      Console.WriteLine("0x{0:X4} ({0:N0}) --> {1} --> 0x{2:X4} ({2:N0})", original, 
                        FormatBytes(bytes3), restored)
   End Sub
   
   Private Function FormatBytes(bytes() As Byte) As String
       Dim value As String = ""
       For Each byt In bytes
          value += String.Format("{0:X2} ", byt)
       Next
       Return value
   End Function
End Module
' The example displays the following output:
'       EC 00 00 00 --> 0x00EC (236)
'       FF FF FF FF FF FF FF 3F --> 0x3FFFFFFF (1,073,741,823)
'       0x1000 (4,096) --> 00 10 00 00  --> 0x1000 (4,096)
' </Snippet1>
