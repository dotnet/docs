    Public Class Car
        ' The speedValue variable can be accessed by
        ' any procedure in the Car class.
        Private speedValue As Integer = 0

        Public ReadOnly Property Speed() As Integer
            Get
                Return speedValue
            End Get
        End Property

        Public Sub Accelerate(ByVal speedIncrease As Integer)
            speedValue += speedIncrease
        End Sub
    End Class