' <Snippet1>
Imports System
Imports System.Text

Public Class dec
    
    Public Shared Sub Main()
        ' These bytes in UTF-8 correspond to 3 different Unicode
        ' characters: space (U+0020), # (U+0023), and the biohazard
        ' symbol (U+2623).  Note the biohazard symbol requires 3 bytes
        ' in UTF-8 (hexadecimal e2, 98, a3).  Decoders store state across
        ' multiple calls to GetChars, handling the case when one char
        ' is in multiple byte arrays.
        Dim bytes1 As Byte() =  {&H20, &H23, &HE2}
        Dim bytes2 As Byte() =  {&H98, &HA3}
        Dim chars(3) As Char
        
        Dim d As Decoder = Encoding.UTF8.GetDecoder()
        Dim charLen As Integer = d.GetChars(bytes1, 0, bytes1.Length, chars, 0)
        ' The value of charLen should be 2 now.
        charLen += d.GetChars(bytes2, 0, bytes2.Length, chars, charLen)
        Dim c As Char
        For Each c In  chars
            Console.Write("U+{0:X4}  ", Convert.ToUInt16(c) )
        Next c
    End Sub
End Class
'</Snippet1>