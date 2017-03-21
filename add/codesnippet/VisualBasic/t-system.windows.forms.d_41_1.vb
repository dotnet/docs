   <EditorAttribute(GetType(System.Windows.Forms.Design.AnchorEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testAnchor() As System.Windows.Forms.AnchorStyles
      Get
         Return anchor
      End Get
      Set
         anchor = value
      End Set
   End Property
   Private anchor As AnchorStyles