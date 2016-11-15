    Public Class ImplementationClass2
        Implements Interface2
        Dim INum As Integer = 0
        Sub sub1(ByVal i As Integer) Implements Interface2.sub1
            ' Insert code here that implements this method.
        End Sub
        Sub M1(ByVal x As Integer) Implements Interface2.M1
            ' Insert code here to implement this method.
        End Sub

        ReadOnly Property Num() As Integer Implements Interface2.Num
            Get
                Num = INum
            End Get
        End Property
    End Class