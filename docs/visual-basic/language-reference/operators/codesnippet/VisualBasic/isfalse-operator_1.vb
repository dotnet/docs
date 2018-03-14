    Public Structure p
        Dim a As Double
        Public Shared Operator IsFalse(ByVal w As p) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsFalse of w.
            Return b
        End Operator
        Public Shared Operator IsTrue(ByVal w As p) As Boolean
            Dim b As Boolean
            ' Insert code to calculate IsTrue of w.
            Return b
        End Operator
    End Structure