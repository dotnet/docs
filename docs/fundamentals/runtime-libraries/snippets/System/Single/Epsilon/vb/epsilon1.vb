' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example2
    Public Sub Main()
        Dim values() As Single = {0.0, Single.Epsilon}
        For Each value In values
            Console.WriteLine(GetComponentParts(value))
            Console.WriteLine()
        Next
    End Sub

    Private Function GetComponentParts(value As Single) As String
        Dim result As String = String.Format("{0:R}: ", value)
        Dim indent As Integer = result.Length

        ' Convert the single to an 8-byte array.
        Dim bytes() As Byte = BitConverter.GetBytes(value)
        Dim formattedSingle As Integer = BitConverter.ToInt32(bytes, 0)

        ' Get the sign bit (byte 3, bit 7).
        result += String.Format("Sign: {0}{1}",
                              If(formattedSingle >> 31 <> 0, "1 (-)", "0 (+)"),
                              vbCrLf)

        ' Get the exponent (byte 2 bit 7 to byte 3, bits 6)
        Dim exponent As Integer = (formattedSingle >> 23) And &HFF
        Dim adjustment As Integer = If(exponent <> 0, 127, 126)
        result += String.Format("{0}Exponent: 0x{1:X4} ({1}){2}",
                              New String(" "c, indent), exponent - adjustment,
                              vbCrLf)

        ' Get the significand (bits 0-22)
        Dim significand As Long = If(exponent <> 0,
                         (formattedSingle And &H7FFFFF) Or &H800000,
                         formattedSingle And &H7FFFFF)
        result += String.Format("{0}Mantissa: 0x{1:X13}{2}",
                              New String(" "c, indent), significand, vbCrLf)

        Return result
    End Function
End Module
' The example displays the following output:
'       0: Sign: 0 (+)
'          Exponent: 0xFFFFFF82 (-126)
'          Mantissa: 0x0000000000000
'       
'       
'       1.401298E-45: Sign: 0 (+)
'                     Exponent: 0xFFFFFF82 (-126)
'                     Mantissa: 0x0000000000001
' </Snippet6>

