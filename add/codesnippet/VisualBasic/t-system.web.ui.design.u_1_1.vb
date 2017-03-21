   <EditorAttribute(GetType(System.Web.UI.Design.UrlEditor), GetType(UITypeEditor))>  _
   Public Property URL() As String
      Get
         Return http_url
      End Get
      Set
         http_url = value
      End Set
   End Property
   
   Private http_url As String