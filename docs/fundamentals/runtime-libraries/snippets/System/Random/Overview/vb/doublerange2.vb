' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Module Example6
    Public Sub Main()
        Dim rnd As New Random()
        For ctr As Integer = 1 To 10
            Console.WriteLine(rnd.NextDouble() - 1)
        Next
    End Sub
End Module
' The example displays output like the following:
'       -0.930412760437658
'       -0.164699016215605
'       -0.9851692803135
'       -0.43468508843085
'       -0.177202483255976
'       -0.776813320245972
'       -0.0713201854710096
'       -0.0912875561468711
'       -0.540621722368813
'       -0.232211863730201
' </Snippet17>
