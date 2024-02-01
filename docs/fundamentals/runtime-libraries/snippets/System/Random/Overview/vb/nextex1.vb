' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example11
    Public Sub Main()
        Dim rnd As New Random()
        For ctr As Integer = 0 To 9
            Console.Write("{0,3}   ", rnd.Next(-10, 11))
        Next
    End Sub
End Module
' The example displays output like the following:
'    2     9    -3     2     4    -7    -3    -8    -8     5
' </Snippet6>
