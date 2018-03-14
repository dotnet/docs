Public Class User

    Private NameValue As String
    Private RatingValue As Integer
    Private MemberSinceValue As DateTime

#Region "Property Getters and Setters"
    Public ReadOnly Property Name() As String
        Get
            Return NameValue
        End Get
    End Property

    Public Property Rating() As Integer
        Get
            Return RatingValue
        End Get
        Set(ByVal value As Integer)
            RatingValue = value
        End Set
    End Property

    Public ReadOnly Property MemberSince() As DateTime
        Get
            Return MemberSinceValue
        End Get
    End Property
#End Region

    Sub New(ByVal Name As String, ByVal Rating As Integer, ByVal MemberSince As DateTime)
        Me.NameValue = Name
        Me.RatingValue = Rating
        Me.MemberSinceValue = MemberSince
    End Sub
End Class
