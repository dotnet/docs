' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example1
   Public Sub Main()
      Dim values() As Double = { 0.0, Double.Epsilon }
      For Each value In values
         Console.WriteLine(GetComponentParts(value))
         Console.WriteLine()
      Next
   End Sub

   Private Function GetComponentParts(value As Double) As String
      Dim result As String =  String.Format("{0:R}: ", value)
      Dim indent As Integer =  result.Length

      ' Convert the double to an 8-byte array.
      Dim bytes() As Byte = BitConverter.GetBytes(value)
      ' Get the sign bit (byte 7, bit 7).
      result += String.Format("Sign: {0}{1}",
                              If((bytes(7) And &H80) = &H80, "1 (-)", "0 (+)"),
                              vbCrLf)

      ' Get the exponent (byte 6 bits 4-7 to byte 7, bits 0-6)
      Dim exponent As Integer =  (bytes(7) And &H07F) << 4
      exponent = exponent Or ((bytes(6) And &HF0) >> 4)
      Dim adjustment As Integer = If(exponent <> 0, 1023, 1022)
      result += String.Format("{0}Exponent: 0x{1:X4} ({1}){2}",
                              New String(" "c, indent), exponent - adjustment,
                              vbCrLf)

      ' Get the significand (bits 0-51)
      Dim significand As Long =  ((bytes(6) And &H0F) << 48)
      significand = significand Or (bytes(5) << 40)
      significand = significand Or (bytes(4) << 32)
      significand = significand Or (bytes(3) << 24)
      significand = significand Or (bytes(2) << 16)
      significand = significand Or (bytes(1) << 8)
      significand = significand Or bytes(0)
      result += String.Format("{0}Mantissa: 0x{1:X13}{2}",
                              New String(" "c, indent), significand, vbCrLf)

      Return result
   End Function
End Module
' The example displays the following output:
'       0: Sign: 0 (+)
'          Exponent: 0xFFFFFC02 (-1022)
'          Mantissa: 0x0000000000000
'
'
'       4.94065645841247E-324: Sign: 0 (+)
'                              Exponent: 0xFFFFFC02 (-1022)
'                              Mantissa: 0x0000000000001
' </Snippet6>

