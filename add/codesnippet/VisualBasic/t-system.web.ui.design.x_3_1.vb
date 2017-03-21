   <EditorAttribute(GetType(System.Web.UI.Design.XmlFileEditor), GetType(UITypeEditor))>  _
   Public Property XmlFile() As String
      Get
         Return xml_
      End Get
      Set
         xml_ = value
      End Set
   End Property
   
   Private xml_ As String