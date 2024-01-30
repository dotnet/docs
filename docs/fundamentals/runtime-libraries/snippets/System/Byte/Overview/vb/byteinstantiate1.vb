' Visual Basic .NET Document
Option Strict On

Module Example3
    Public Sub Main()
        InstantiateByAssignment()
        InstantiateByNarrowingConversion()
        Parse()
    End Sub

    Private Sub InstantiateByAssignment()
        ' <Snippet1>
        Dim value1 As Byte = 64
        Dim value2 As Byte = 255
        ' </Snippet1>
    End Sub

    Private Sub InstantiateByNarrowingConversion()
        ' <Snippet2>
        Dim int1 As Integer = 128
        Try
            Dim value1 As Byte = CByte(int1)
            Console.WriteLine(value1)
        Catch e As OverflowException
            Console.WriteLine("{0} is out of range of a byte.", int1)
        End Try

        Dim dbl2 As Double = 3.997
        Try
            Dim value2 As Byte = CByte(dbl2)
            Console.WriteLine(value2)
        Catch e As OverflowException
            Console.WriteLine("{0} is out of range of a byte.", dbl2)
        End Try
        ' The example displays the following output:
        '       128
        '       4
        ' </Snippet2> 
    End Sub

    Private Sub Parse()
        ' <Snippet3>
        Dim string1 As String = "244"
        Try
            Dim byte1 As Byte = Byte.Parse(string1)
            Console.WriteLine(byte1)
        Catch e As OverflowException
            Console.WriteLine("'{0}' is out of range of a byte.", string1)
        Catch e As FormatException
            Console.WriteLine("'{0}' is out of range of a byte.", string1)
        End Try

        Dim string2 As String = "F9"
        Try
            Dim byte2 As Byte = Byte.Parse(string2,
                                   System.Globalization.NumberStyles.HexNumber)
            Console.WriteLine(byte2)
        Catch e As OverflowException
            Console.WriteLine("'{0}' is out of range of a byte.", string2)
        Catch e As FormatException
            Console.WriteLine("'{0}' is out of range of a byte.", string2)
        End Try
        ' The example displays the following output:
        '       244
        '       249
        ' </Snippet3>     
    End Sub
End Module

