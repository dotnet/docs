   <EditorAttribute(GetType(System.Windows.Forms.Design.FileNameEditor), GetType(System.Drawing.Design.UITypeEditor))>  _
   Public Property testFilename() As String
      Get
         Return filename
      End Get
      Set
         filename = value
      End Set
   End Property
   Private filename As String   