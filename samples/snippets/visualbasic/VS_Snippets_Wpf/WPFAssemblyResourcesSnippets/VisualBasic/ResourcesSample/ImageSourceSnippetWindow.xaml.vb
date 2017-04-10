'<SnippetSetImageSourceCODEBEHIND1>

Imports System ' Uri
Imports System.Windows.Media.Imaging ' BitmapImage
'</SnippetSetImageSourceCODEBEHIND1>
Imports System.IO ' Stream
Imports System.Windows.Resources ' StreamResourceInfo
Imports System.Windows
Imports System.Windows.Controls

Namespace ResourcesSample
    Partial Public Class ImageSourceSnippetWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
            '<SnippetSetImageSourceCODEBEHIND2>
            ' Create Uri that maps to a resource
            Dim uri As New Uri("EmbeddedOrLooseResource.bmp", UriKind.Relative)
            ' Load embedded resource
            Me.resourceImage.Source = New System.Windows.Media.Imaging.BitmapImage(uri)
            '</SnippetSetImageSourceCODEBEHIND2>
        End Sub
    End Class
End Namespace