' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example10
    Public Sub Main()
        Dim rnd As New Random()
        For ctr As Integer = 0 To 9
            Console.Write("{0,-19:R}   ", rnd.NextDouble())
            If (ctr + 1) Mod 3 = 0 Then Console.WriteLine()
        Next
    End Sub
End Module
' The example displays output like the following:
'    0.7911680553998649    0.0903414949264105    0.79776258291572455    
'    0.615568345233597     0.652644504165577     0.84023809378977776   
'    0.099662564741290441  0.91341467383942321   0.96018602045261581   
'    0.74772306473354022
' </Snippet7>
