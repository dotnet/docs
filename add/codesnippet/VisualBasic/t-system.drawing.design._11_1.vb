   <EditorAttribute(GetType(System.Drawing.Design.FontEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testFont() As Font
      Get
         Return font
      End Get
      Set
         font = value
      End Set
   End Property
   Private font As Font