Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Imports System.Windows.Resources
Imports System.IO

Namespace ResourcesSample
    ''' <summary>
    ''' Interaction logic for SOOPage.xaml
    ''' </summary>

    Partial Public Class SOOPage
        Inherits Page
        Public Sub New()
            InitializeComponent()

            Method1()
            Method2()
            Method3()
            Method4()
            Method5()
        End Sub

        Private Sub Method1()
            '<SnippetGetRemoteStreamRootFolderCODE>
            ' Load file from site of origin (application launch location)
            Dim uri As New Uri("SiteOfOriginFile.xaml", UriKind.Relative)
            Dim rootFolderInfo As StreamResourceInfo = Application.GetRemoteStream(uri)
            '</SnippetGetRemoteStreamRootFolderCODE> 
        End Sub

        Private Sub Method2()
            '<SnippetGetRemoteStreamRootSubFolderCODE>
            ' Load file from site of origin (application launch location)
            Dim uri As New Uri("/SiteOfOriginFile.xaml", UriKind.Relative)
            Dim subFolderInfo As StreamResourceInfo = Application.GetRemoteStream(uri)
            '</SnippetGetRemoteStreamRootSubFolderCODE>
        End Sub

        Private Sub Method3()
            '<SnippetCallApplicationGetRemoteStreamCODEBEHIND2>
            ' Create a URI that identifies the compiled resource file
            Dim uri As New Uri("/SiteOfOriginFile.xaml", UriKind.Relative)
            ' Load resource file
            Dim info As StreamResourceInfo = Application.GetRemoteStream(uri)
            Dim resourceType As String = info.ContentType ' Resource file type
            Dim resourceStream As Stream = info.Stream ' Resource file stream
            '</SnippetCallApplicationGetRemoteStreamCODEBEHIND2>
        End Sub

        Private Sub Method4()
            '<SnippetLoadAPageSOOFileManuallyCODE>
            ' Navigate to xaml page
            Dim uri As New Uri("/SiteOfOriginFile.xaml", UriKind.Relative)
            Dim info As StreamResourceInfo = Application.GetRemoteStream(uri)
            Dim reader As New System.Windows.Markup.XamlReader()
            Dim page As Page = CType(reader.LoadAsync(info.Stream), Page)
            Me.pageFrame.Content = page
            '</SnippetLoadAPageSOOFileManuallyCODE>
        End Sub

        Private Sub Method5()
            '<SnippetLoadPageSOOFileFromCODE>
            Dim pageUri As New Uri("pack://siteoforigin:,,,/Subfolder/SiteOfOriginFile.xaml", UriKind.Absolute)
            Me.pageFrame.Source = pageUri
            '</SnippetLoadPageSOOFileFromCODE>
        End Sub
    End Class
End Namespace