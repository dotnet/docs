'<SnippetPersonClassCODE>

Namespace SDKSample
	Public Class Person
        Private _name As String
        Private _favoriteColor As Color

		Public Sub New()
		End Sub
		Public Sub New(ByVal name As String, ByVal favoriteColor As Color)
            Me._name = name
            Me._favoriteColor = favoriteColor
		End Sub

		Public Property Name() As String
			Get
                Return Me._name
			End Get
			Set(ByVal value As String)
                Me._name = value
			End Set
		End Property

		Public Property FavoriteColor() As Color
			Get
                Return Me._favoriteColor
			End Get
			Set(ByVal value As Color)
                Me._favoriteColor = value
			End Set
		End Property
	End Class
End Namespace
'</SnippetPersonClassCODE>