using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Resources;
using System.IO;

namespace ResourcesSample
{
    /// <summary>
    /// Interaction logic for SOOPage.xaml
    /// </summary>

    public partial class SOOPage : Page
    {
        public SOOPage()
        {
            InitializeComponent();

            Method1();
            Method2();
            Method3();
            Method4();
            Method5();
        }

void Method1()
{
//<SnippetGetRemoteStreamRootFolderCODE>
// Load file from site of origin (application launch location)
Uri uri = new Uri("SiteOfOriginFile.xaml", UriKind.Relative);
StreamResourceInfo rootFolderInfo = Application.GetRemoteStream(uri);
//</SnippetGetRemoteStreamRootFolderCODE> 
}

void Method2()
{
//<SnippetGetRemoteStreamRootSubFolderCODE>
// Load file from site of origin (application launch location)
Uri uri = new Uri("/SiteOfOriginFile.xaml", UriKind.Relative);
StreamResourceInfo subFolderInfo = Application.GetRemoteStream(uri);
//</SnippetGetRemoteStreamRootSubFolderCODE>
}

void Method3()
{
//<SnippetCallApplicationGetRemoteStreamCODEBEHIND2>
// Create a URI that identifies the compiled resource file
Uri uri = new Uri("/SiteOfOriginFile.xaml", UriKind.Relative);
// Load resource file
StreamResourceInfo info = Application.GetRemoteStream(uri);
string resourceType = info.ContentType; // Resource file type
Stream resourceStream = info.Stream; // Resource file stream
//</SnippetCallApplicationGetRemoteStreamCODEBEHIND2>
}

void Method4()
{
//<SnippetLoadAPageSOOFileManuallyCODE>
// Navigate to xaml page
Uri uri = new Uri("/SiteOfOriginFile.xaml", UriKind.Relative);
StreamResourceInfo info = Application.GetRemoteStream(uri);
System.Windows.Markup.XamlReader reader = new System.Windows.Markup.XamlReader();
Page page = (Page)reader.LoadAsync(info.Stream);
this.pageFrame.Content = page;
//</SnippetLoadAPageSOOFileManuallyCODE>
}

void Method5()
{
//<SnippetLoadPageSOOFileFromCODE>
Uri pageUri = new Uri("pack://siteoforigin:,,,/SiteOfOriginFile.xaml", UriKind.Absolute);
this.pageFrame.Source = pageUri;
//</SnippetLoadPageSOOFileFromCODE>
}
    }
}