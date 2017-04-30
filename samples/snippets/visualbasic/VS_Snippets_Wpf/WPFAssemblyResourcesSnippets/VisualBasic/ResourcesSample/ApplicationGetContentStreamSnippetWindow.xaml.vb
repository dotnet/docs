'<SnippetCallApplicationGetContentStreamCODEBEHIND1>

Imports System
Imports System.IO
Imports System.Windows.Resources
'</SnippetCallApplicationGetContentStreamCODEBEHIND1>
Imports System.Windows
Imports System.Windows.Controls

Namespace ResourcesSample
    Partial Public Class ApplicationGetContentStreamSnippetWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()

            Method1()
            Method2()
            Method3()
        End Sub

        Private Sub Method1()
            '<SnippetCallApplicationGetContentStreamCODEBEHIND2>
            ' Create a URI that identifies the compiled content file
            Dim uri As New Uri("/ContentFile.xaml", UriKind.Relative)
            ' Load resource file
            Dim info As StreamResourceInfo = Application.GetContentStream(uri)
            Dim resourceType As String = info.ContentType ' Content file type
            Dim resourceStream As Stream = info.Stream ' Content file stream
            '</SnippetCallApplicationGetContentStreamCODEBEHIND2>
        End Sub

        Private Sub Method2()
            '<SnippetLoadAPageContentFileManuallyCODE>
            ' Navigate to xaml page
            Dim uri As New Uri("/PageContentFile.xaml", UriKind.Relative)
            Dim info As StreamResourceInfo = Application.GetContentStream(uri)
            Dim reader As New System.Windows.Markup.XamlReader()
            Dim page As Page = CType(reader.LoadAsync(info.Stream), Page)
            Me.pageFrame.Content = page
            '</SnippetLoadAPageContentFileManuallyCODE>
        End Sub

        Private Sub Method3()
            '<SnippetLoadPageContentFileFromCODE>
            Dim pageUri As New Uri("/PageContentFile.xaml", UriKind.Relative)
            Me.pageFrame.Source = pageUri
            '</SnippetLoadPageContentFileFromCODE>
        End Sub
    End Class
End Namespace