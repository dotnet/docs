    Public Class CustomStyle
        Inherits System.Web.UI.MobileControls.Style
        Private themeNameKey As String

        Public Sub New(ByVal name As String)
            themeNameKey = _
                RegisterStyle(name, GetType(String), _
                    String.Empty, True).ToString()
        End Sub
        
        Public Property ThemeName() As String
            Get
                Return Me(themeNameKey).ToString()
            End Get
            Set(ByVal value As String)
                Me(themeNameKey) = value
            End Set
        End Property
    End Class