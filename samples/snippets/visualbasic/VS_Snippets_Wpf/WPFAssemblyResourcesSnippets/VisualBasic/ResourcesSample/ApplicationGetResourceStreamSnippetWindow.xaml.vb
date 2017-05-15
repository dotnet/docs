'<SnippetCallApplicationGetResourceStreamCODEBEHIND1>

Imports System
Imports System.IO
Imports System.Windows.Resources
'</SnippetCallApplicationGetResourceStreamCODEBEHIND1>
Imports System.Windows
Imports System.Windows.Controls
Namespace ResourcesSample
    ''' <summary>
    ''' Interaction logic for ApplicationGetResourceStreamSnippetWindow.xaml
    ''' </summary>

    Partial Public Class ApplicationGetResourceStreamSnippetWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            Method1()
            Method2()
            Method3()
        End Sub
        Private Sub Method1()
            '<SnippetCallApplicationGetResourceStreamCODEBEHIND2>
            ' Create a URI that identifies the compiled resource file
            Dim uri As New Uri("/ResourceFile.xaml", UriKind.Relative)
            ' Load resource file
            Dim info As StreamResourceInfo = Application.GetResourceStream(uri)
            Dim resourceType As String = info.ContentType ' Resource file type
            Dim resourceStream As Stream = info.Stream ' Resource file stream
            '</SnippetCallApplicationGetResourceStreamCODEBEHIND2>
        End Sub

        Private Sub Method2()
            '<SnippetLoadAPageResourceFileManuallyCODE>
            ' Navigate to xaml page
            Dim uri As New Uri("/PageResourceFile.xaml", UriKind.Relative)
            Dim info As StreamResourceInfo = Application.GetResourceStream(uri)
            Dim reader As New System.Windows.Markup.XamlReader()
            Dim page As Page = CType(reader.LoadAsync(info.Stream), Page)
            Me.pageFrame.Content = page
            '</SnippetLoadAPageResourceFileManuallyCODE>
        End Sub

        Private Sub Method3()
            '<SnippetLoadPageResourceFileFromCODE>
            Dim pageUri As New Uri("/PageResourceFile.xaml", UriKind.Relative)
            Me.pageFrame.Source = pageUri
            '</SnippetLoadPageResourceFileFromCODE>
        End Sub

    End Class
End Namespace