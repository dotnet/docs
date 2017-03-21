    <EditorAttribute(GetType(System.Web.UI.Design.XmlUrlEditor), GetType(UITypeEditor))> _
    Public Property XmlFileURL() As String
        Get
            Return xmlURL
        End Get
        Set(ByVal Value As String)
            xmlURL = Value
        End Set
    End Property

    Private xmlURL As String