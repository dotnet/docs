   Public Sub New()
      Me.InitializeComponent()
      
      ' Assign icons to ToolStripButton controls.
      Me.InitializeImages()
      
      ' Set up renderers.
      Me.stackStrip.Renderer = New StackRenderer()
    End Sub
   