    Public Structure abc
        Dim d As Date
        Public Shared Operator And(ByVal x As abc, ByVal y As abc) As abc
            Dim r As New abc
            ' Insert code to calculate And of x and y.
            Return r
        End Operator
        Public Shared Operator Or(ByVal x As abc, ByVal y As abc) As abc
            Dim r As New abc
            ' Insert code to calculate Or of x and y.
            Return r
        End Operator
        Public Shared Operator IsFalse(ByVal z As abc) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsFalse of z.
            Return b
        End Operator
        Public Shared Operator IsTrue(ByVal z As abc) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsTrue of z.
            Return b
        End Operator
    End Structure