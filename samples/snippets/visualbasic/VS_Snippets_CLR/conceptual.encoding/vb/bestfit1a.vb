' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text

Module Example
    Public Sub Main()
        Dim cp1252r As Encoding = Encoding.GetEncoding(1252,
                                           New EncoderReplacementFallback("*"),
                                           New DecoderReplacementFallback("*"))

        Dim str1 As String = String.Format("{0} {1} {2}", ChrW(&h24C8), ChrW(&h2075), ChrW(&h221E))
        Console.WriteLine(str1)
        For Each ch In str1
            Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"))
        Next
        Console.WriteLine()

        Dim bytes() As Byte = cp1252r.GetBytes(str1)
        Dim str2 As String = cp1252r.GetString(bytes)
        Console.WriteLine("Round-trip: {0}", str1.Equals(str2))
        If Not str1.Equals(str2) Then
            Console.WriteLine(str2)
            For Each ch In str2
                Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"))
            Next
            Console.WriteLine()
        End If
    End Sub
End Module
' The example displays the following output:
'       Ⓢ ⁵ ∞
'       24C8 0020 2075 0020 221E
'       Round-trip: False
'       * * *
'       002A 0020 002A 0020 002A
' </Snippet3>

