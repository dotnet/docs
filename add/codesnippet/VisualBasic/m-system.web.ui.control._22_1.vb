   Public Class MyResolveUrl
      Inherits Control
      Private _ImageUrl As String

      Public Property ImageUrl() As String
         Get
            Return _ImageUrl
         End Get
         Set
            _ImageUrl = value
         End Set
      End Property

      Protected Overrides Sub Render(output As HtmlTextWriter)
         Dim myImage As New System.Web.UI.WebControls.Image()
         ' Resolve Url.
         myImage.ImageUrl = ResolveUrl(Me.ImageUrl)
         myImage.RenderControl(output)
      End Sub
   End Class