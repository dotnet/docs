' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example1
    Public Sub Main()
        Dim flags() As Boolean = {True, False}
        For Each flag In flags
            ' Get binary representation of flag.
            Dim value As Byte = BitConverter.GetBytes(flag)(0)
            Console.WriteLine("Original value: {0}", flag)
            Console.WriteLine("Binary value:   {0} ({1})", value,
                           GetBinaryString(value))
            ' Restore the flag from its binary representation.
            Dim newFlag As Boolean = BitConverter.ToBoolean({value}, 0)
            Console.WriteLine("Restored value: {0}", flag)
            Console.WriteLine()
        Next
    End Sub

    Private Function GetBinaryString(value As Byte) As String
        Dim retVal As String = Convert.ToString(value, 2)
        Return New String("0"c, 8 - retVal.Length) + retVal
    End Function
End Module
' The example displays the following output:
'       Original value: True
'       Binary value:   1 (00000001)
'       Restored value: True
'       
'       Original value: False
'       Binary value:   0 (00000000)
'       Restored value: False
' </Snippet1>
