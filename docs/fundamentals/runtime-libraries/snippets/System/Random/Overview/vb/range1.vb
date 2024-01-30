' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Module Example12
    Public Sub Main()
        Dim rnd As New Random()
        For ctr As Integer = 1 To 15
            Console.Write("{0,3}    ", rnd.Next(-10, 11))
            If ctr Mod 5 = 0 Then Console.WriteLine()
        Next
    End Sub
End Module
' The example displays output like the following:
'        -2     -5     -1     -2     10
'        -3      6     -4     -8      3
'        -7     10      5     -2      4
' </Snippet15>
