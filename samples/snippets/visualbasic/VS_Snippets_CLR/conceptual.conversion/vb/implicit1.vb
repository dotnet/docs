' Visual Basic .NET Document
Option Strict On

Module ImplicitExample
    Public Sub Main()
        PerformDecimalConversions()
        Console.WriteLine("-----")
        PerformCustomConversions()
    End Sub

    Private Sub PerformDecimalConversions()
        ' <Snippet1>
        Dim byteValue As Byte = 16
        Dim shortValue As Short = -1024
        Dim intValue As Integer = -1034000
        Dim longValue As Long = CLng(1024 ^ 6)
        Dim ulongValue As ULong = ULong.MaxValue

        Dim decimalValue As Decimal

        decimalValue = byteValue
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          byteValue.GetType().Name, decimalValue)

        decimalValue = shortValue
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          shortValue.GetType().Name, decimalValue)

        decimalValue = intValue
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          intValue.GetType().Name, decimalValue)

        decimalValue = longValue
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          longValue.GetType().Name, decimalValue)

        decimalValue = ulongValue
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          ulongValue.GetType().Name, decimalValue)
        ' The example displays the following output:
        '    After assigning a Byte value, the Decimal value is 16.
        '    After assigning a Int16 value, the Decimal value is -1024.
        '    After assigning a Int32 value, the Decimal value is -1034000.
        '    After assigning a Int64 value, the Decimal value is 1152921504606846976.
        '    After assigning a UInt64 value, the Decimal value is 18446744073709551615.
        ' </Snippet1>
    End Sub

    Private Sub PerformCustomConversions()
        ' <Snippet3>
        Dim sbyteValue As SByte = -120
        Dim value As ImplicitByteWithSign = sbyteValue
        Console.WriteLine(value.ToString())
        value = Byte.MaxValue
        Console.WriteLine(value.ToString())
        ' The example displays the following output:
        '       -120
        '       255
        ' </Snippet3>
    End Sub
End Module

' <Snippet2>
Public Structure ImplicitByteWithSign
    Private signValue As SByte
    Private value As Byte

    Public Overloads Shared Widening Operator CType(value As SByte) As ImplicitByteWithSign
        Dim newValue As ImplicitByteWithSign
        newValue.signValue = CSByte(Math.Sign(value))
        newValue.value = CByte(Math.Abs(value))
        Return newValue
    End Operator

    Public Overloads Shared Widening Operator CType(value As Byte) As ImplicitByteWithSign
        Dim NewValue As ImplicitByteWithSign
        newValue.signValue = 1
        newValue.value = value
        Return newValue
    End Operator

    Public Overrides Function ToString() As String
        Return (signValue * value).ToString()
    End Function
End Structure
' </Snippet2>
