' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Module Example
    Public Sub Main()
        ' Get an encoding for code page 1252 (Western Europe character set).
        Dim cp1252 As Encoding = Encoding.GetEncoding(1252)

        ' Define and display a string.
        Dim str As String = String.Format("{0} {1} {2}", ChrW(&h24c8), ChrW(&H2075), ChrW(&h221E))
        Console.WriteLine("Original string: " + str)
        Console.Write("Code points in string: ")
        For Each ch In str
            Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"))
        Next
        Console.WriteLine()
        Console.WriteLine()

        ' Encode a Unicode string.
        Dim bytes() As Byte = cp1252.GetBytes(str)
        Console.Write("Encoded bytes: ")
        For Each byt In bytes
            Console.Write("{0:X2} ", byt)
        Next
        Console.WriteLine()
        Console.WriteLine()

        ' Decode the string.
        Dim str2 As String = cp1252.GetString(bytes)
        Console.WriteLine("String round-tripped: {0}", str.Equals(str2))
        If Not str.Equals(str2) Then
            Console.WriteLine(str2)
            For Each ch In str2
                Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"))
            Next
        End If
    End Sub
End Module
' The example displays the following output:
'       Original string: Ⓢ ⁵ ∞
'       Code points in string: 24C8 0020 2075 0020 221E
'       
'       Encoded bytes: 3F 20 35 20 38
'       
'       String round-tripped: False
'       ? 5 8
'       003F 0020 0035 0020 0038
' </Snippet1>
