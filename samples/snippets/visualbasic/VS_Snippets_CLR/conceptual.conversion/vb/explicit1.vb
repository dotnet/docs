' Visual Basic .NET Document
Option Strict On

Module ExplicitExample
    Public Sub Main()
        PerformIntegerConversion()
        Console.WriteLine("-----")
        PerformCustomConversion()
    End Sub

    Private Sub PerformIntegerConversion()
        ' <Snippet4>
        Dim number1 As Long = Integer.MaxValue + 20L
        Dim number2 As UInteger = Integer.MaxValue - 1000
        Dim number3 As ULong = Integer.MaxValue

        Dim intNumber As Integer

        Try
            intNumber = CInt(number1)
            Console.WriteLine("After assigning a {0} value, the Integer value is {1}.",
                                number1.GetType().Name, intNumber)
        Catch e As OverflowException
            If number1 > Integer.MaxValue Then
                Console.WriteLine("Conversion failed: {0} exceeds {1}.",
                                                  number1, Integer.MaxValue)
            Else
                Console.WriteLine("Conversion failed: {0} is less than {1}.\n",
                                                  number1, Integer.MinValue)
            End If
        End Try

        Try
            intNumber = CInt(number2)
            Console.WriteLine("After assigning a {0} value, the Integer value is {1}.",
                                number2.GetType().Name, intNumber)
        Catch e As OverflowException
            Console.WriteLine("Conversion failed: {0} exceeds {1}.",
                                              number2, Integer.MaxValue)
        End Try

        Try
            intNumber = CInt(number3)
            Console.WriteLine("After assigning a {0} value, the Integer value is {1}.",
                                number3.GetType().Name, intNumber)
        Catch e As OverflowException
            Console.WriteLine("Conversion failed: {0} exceeds {1}.",
                                              number1, Integer.MaxValue)
        End Try
        ' The example displays the following output:
        '    Conversion failed: 2147483667 exceeds 2147483647.
        '    After assigning a UInt32 value, the Integer value is 2147482647.
        '    After assigning a UInt64 value, the Integer value is 2147483647.
        ' </Snippet4>
    End Sub

    Private Sub PerformCustomConversion()
        ' <Snippet6>
        Dim value As ByteWithSign

        Try
            Dim intValue As Integer = -120
            value = CType(intValue, ByteWithSign)
            Console.WriteLine(value)
        Catch e As OverflowException
            Console.WriteLine(e.Message)
        End Try

        Try
            Dim uintValue As UInteger = 1024
            value = CType(uintValue, ByteWithSign)
            Console.WriteLine(value)
        Catch e As OverflowException
            Console.WriteLine(e.Message)
        End Try
        ' The example displays the following output:
        '       -120
        '       '1024' is out of range of the ByteWithSign data type.
        ' </Snippet6>
    End Sub
End Module

' <Snippet5>
Public Structure ByteWithSign
    Private signValue As SByte
    Private value As Byte

    Private Const MaxValue As Byte = Byte.MaxValue
    Private Const MinValue As Integer = -1 * Byte.MaxValue

    Public Overloads Shared Narrowing Operator CType(value As Integer) As ByteWithSign
        ' Check for overflow.
        If value > ByteWithSign.MaxValue Or value < ByteWithSign.MinValue Then
            Throw New OverflowException(String.Format("'{0}' is out of range of the ByteWithSign data type.", value))
        End If

        Dim newValue As ByteWithSign

        newValue.signValue = CSByte(Math.Sign(value))
        newValue.value = CByte(Math.Abs(value))
        Return newValue
    End Operator

    Public Overloads Shared Narrowing Operator CType(value As UInteger) As ByteWithSign
        If value > ByteWithSign.MaxValue Then
            Throw New OverflowException(String.Format("'{0}' is out of range of the ByteWithSign data type.", value))
        End If

        Dim NewValue As ByteWithSign

        newValue.signValue = 1
        newValue.value = CByte(value)
        Return newValue
    End Operator

    Public Overrides Function ToString() As String
        Return (signValue * value).ToString()
    End Function
End Structure
' </Snippet5>
