Namespace SDKSample

  ' Need this to bind to, since System.DateTime is a struct (ie not a type with a default constructor)
    Public Class DateTime
        Public ReadOnly Property Now() As String
            Get
                Return Date.Now.ToString()
            End Get
        End Property
    End Class
End Namespace
