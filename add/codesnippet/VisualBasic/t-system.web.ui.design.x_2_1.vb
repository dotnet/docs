    <EditorAttribute(GetType(System.Web.UI.Design.XslUrlEditor), GetType(UITypeEditor))> _
    Public Property XslFileURL() As String
        Get
            Return xslURL
        End Get
        Set(ByVal Value As String)
            xslURL = Value
        End Set
    End Property

    Private xslURL As String