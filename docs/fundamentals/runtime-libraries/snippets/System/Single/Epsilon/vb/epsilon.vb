' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example1
    Public Sub Main()
        Dim values() As Single = {0, Single.Epsilon, Single.Epsilon * 0.5}

        For ctr As Integer = 0 To values.Length - 2
            For ctr2 As Integer = ctr + 1 To values.Length - 1
                Console.WriteLine("{0:r} = {1:r}: {2}",
                              values(ctr), values(ctr2),
                              values(ctr).Equals(values(ctr2)))
            Next
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       0 = 1.401298E-45: False
'       0 = 0: True
'       
'       1.401298E-45 = 0: False
' </Snippet5>
