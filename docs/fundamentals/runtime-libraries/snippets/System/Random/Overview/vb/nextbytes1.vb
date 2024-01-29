' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example9
    Public Sub Main()
        Dim rnd As New Random()
        Dim bytes(19) As Byte
        rnd.NextBytes(bytes)
        For ctr As Integer = 1 To bytes.Length
            Console.Write("{0,3}   ", bytes(ctr - 1))
            If ctr Mod 10 = 0 Then Console.WriteLine()
        Next
    End Sub
End Module
' The example displays output like the following:
'       141    48   189    66   134   212   211    71   161    56
'       181   166   220   133     9   252   222    57    62    62
' </Snippet5>
