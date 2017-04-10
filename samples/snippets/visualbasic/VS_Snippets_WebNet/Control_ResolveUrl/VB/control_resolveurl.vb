' System.Web.UI.Control.ResolveUrl

'   The following program demonstrates the method 'ResolveUrl'
'   of 'System.Web.UI.Control' class.
'   A custom class 'MyResolveUrl' is created by inheriting from 
'   'Control' Class. Method 'RenderContents' is overridden to create 
'   a new Image instance. ImageUrl is obtained by resolving Url from 
'   one of the custom control's properties.

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.Web.UI.WebControls


Namespace ResolveUrlSample

' <Snippet1>
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
' </Snippet1>

End Namespace