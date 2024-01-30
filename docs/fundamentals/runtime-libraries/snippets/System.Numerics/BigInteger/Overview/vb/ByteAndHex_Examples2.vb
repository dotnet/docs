' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Globalization
Imports System.Numerics

Public Structure HexValue
    Public Sign As Integer
    Public Value As String
End Structure

Module Example2
    Public Sub Main()
        Dim positiveNumber As UInteger = 4039543321
        Dim negativeNumber As Integer = -255423975

        ' Convert the numbers to hex strings.
        Dim hexValue1, hexValue2 As HexValue
        hexValue1.Value = positiveNumber.ToString("X")
        hexValue1.Sign = Math.Sign(positiveNumber)

        hexValue2.Value = Convert.ToString(negativeNumber, 16)
        hexValue2.Sign = Math.Sign(negativeNumber)

        ' Round-trip the hexadecimal values to BigInteger values.
        Dim hexString As String
        Dim positiveBigInt, negativeBigInt As BigInteger

        hexString = CStr(IIf(hexValue1.Sign = 1, "0", "")) + hexValue1.Value
        positiveBigInt = BigInteger.Parse(hexString, NumberStyles.HexNumber)
        Console.WriteLine("Converted {0} to {1} and back to {2}.",
                        positiveNumber, hexValue1.Value, positiveBigInt)

        hexString = CStr(IIf(hexValue2.Sign = 1, "0", "")) + hexValue2.Value
        negativeBigInt = BigInteger.Parse(hexString, NumberStyles.HexNumber)
        Console.WriteLine("Converted {0} to {1} and back to {2}.",
                        negativeNumber, hexValue2.Value, negativeBigInt)

    End Sub
End Module
' The example displays the following output:
'       Converted 4039543321 to F0C68A19 and back to 4039543321.
'       Converted -255423975 to f0c68a19 and back to -255423975.
' </Snippet6>
