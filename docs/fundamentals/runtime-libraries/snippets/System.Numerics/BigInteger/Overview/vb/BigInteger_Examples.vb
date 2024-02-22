' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example1
    Public Sub Main()
        ' <Snippet1>
        Dim bigIntFromDouble As New BigInteger(179032.6541)
        Console.WriteLine(bigIntFromDouble)
        Dim bigIntFromInt64 As New BigInteger(934157136952)
        Console.WriteLine(bigIntFromInt64)
        ' The example displays the following output:
        '   179032
        '   934157136952		
        ' </Snippet1>

        Console.WriteLine()

        ' <Snippet2>
        Dim longValue As Long = 6315489358112
        Dim assignedFromLong As BigInteger = longValue
        Console.WriteLine(assignedFromLong)
        ' The example displays the following output:
        '   6315489358112
        ' </Snippet2>

        Console.WriteLine()

        ' <Snippet3>
        Dim assignedFromDouble As BigInteger = CType(179032.6541, BigInteger)
        Console.WriteLine(assignedFromDouble)
        Dim assignedFromDecimal As BigInteger = CType(64312.65D, BigInteger)
        Console.WriteLine(assignedFromDecimal)
        ' The example displays the following output:
        '   179032
        '   64312      
        ' </Snippet3>

        Console.WriteLine()

        ' <Snippet4>
        Dim byteArray() As Byte = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
        Dim newBigInt As New BigInteger(byteArray)
        Console.WriteLine("The value of newBigInt is {0} (or 0x{0:x}).", newBigInt)
        ' The example displays the following output:
        '   The value of newBigInt is 4759477275222530853130 (or 0x102030405060708090a).
        ' </Snippet4>

        Console.WriteLine()

        ' <Snippet5>
        Dim positiveString As String = "91389681247993671255432112000000"
        Dim negativeString As String = "-90315837410896312071002088037140000"
        Dim posBigInt As BigInteger = 0
        Dim negBigInt As BigInteger = 0

        Try
            posBigInt = BigInteger.Parse(positiveString)
            Console.WriteLine(posBigInt)
        Catch e As FormatException
            Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.",
                              positiveString)
        End Try

        If BigInteger.TryParse(negativeString, negBigInt) Then
            Console.WriteLine(negBigInt)
        Else
            Console.WriteLine("Unable to convert the string '{0}' to a BigInteger value.",
                               negativeString)
        End If
        ' The example displays the following output:
        '   9.1389681247993671255432112E+31
        '   -9.0315837410896312071002088037E+34
        ' </Snippet5>

        Console.WriteLine()

        ' <Snippet6>
        Dim number As BigInteger = BigInteger.Pow(UInt64.MaxValue, 3)
        Console.WriteLine(number)
        ' The example displays the following output:
        ' 6277101735386680762814942322444851025767571854389858533375
        ' </Snippet6>  
    End Sub
End Module
