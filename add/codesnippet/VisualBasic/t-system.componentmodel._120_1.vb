   <EditorAttribute(GetType(System.ComponentModel.Design.CollectionEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testCollection() As ICollection
      Get
         Return Icollection
      End Get
      Set
         Icollection = value
      End Set
   End Property
   Private Icollection As ICollection