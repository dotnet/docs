Namespace SDKSample

    Public Class Person

        Dim _name As String = "No Name"

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

    End Class

End Namespace