    <EditorAttribute(GetType(System.Web.UI.Design.ImageUrlEditor), GetType(UITypeEditor))> _
    Public Property imageURL() As String
        Get
            Return imgURL
        End Get
        Set(ByVal Value As String)
            imgURL = Value
        End Set
    End Property

    Private imgURL As String