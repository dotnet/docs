   <EditorAttribute(GetType(System.Drawing.Design.ImageEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testImage() As Image
      Get
         Return testImg
      End Get
      Set
         testImg = value
      End Set
   End Property
   Private testImg As Image