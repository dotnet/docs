Option Strict Off

Public Class Class2

    ' Int, Fix Functions (Visual Basic)
    Class Class2855c7fe20054f9988786c9f070f5af8

        Public Sub Method4()
            ' <snippet4>
            ' This code requires Option Strict Off
            Dim MyNumber As Integer
            MyNumber = Int(99.8)   ' Returns 99.
            MyNumber = Fix(99.8)   ' Returns 99.

            MyNumber = Int(-99.8)  ' Returns -100.
            MyNumber = Fix(-99.8)  ' Returns -99.

            MyNumber = Int(-99.2)  ' Returns -100.
            MyNumber = Fix(-99.2)  ' Returns -99.
            ' </snippet4>
        End Sub

    End Class

End Class
