//<SnippetCallApplicationGetContentStreamCODEBEHIND1>
using System;
using System.IO;
using System.Windows.Resources;
//</SnippetCallApplicationGetContentStreamCODEBEHIND1>
using System.Windows;
using System.Windows.Controls;

namespace ResourcesSample
{
    public partial class ApplicationGetContentStreamSnippetWindow : Window
    {
        public ApplicationGetContentStreamSnippetWindow()
        {
            InitializeComponent();

            Method1();
            Method2();
            Method3();
        }

void Method1()
{
//<SnippetCallApplicationGetContentStreamCODEBEHIND2>
// Create a URI that identifies the compiled content file
Uri uri = new Uri("/ContentFile.xaml", UriKind.Relative);
// Load resource file
StreamResourceInfo info = Application.GetContentStream(uri);
string resourceType = info.ContentType; // Content file type
Stream resourceStream = info.Stream; // Content file stream
//</SnippetCallApplicationGetContentStreamCODEBEHIND2>
}

void Method2()
{
//<SnippetLoadAPageContentFileManuallyCODE>
// Navigate to xaml page
Uri uri = new Uri("/PageContentFile.xaml", UriKind.Relative);
StreamResourceInfo info = Application.GetContentStream(uri);
System.Windows.Markup.XamlReader reader = new System.Windows.Markup.XamlReader();
Page page = (Page)reader.LoadAsync(info.Stream);
this.pageFrame.Content = page;
//</SnippetLoadAPageContentFileManuallyCODE>
}

void Method3()
{
//<SnippetLoadPageContentFileFromCODE>
Uri pageUri = new Uri("/PageContentFile.xaml", UriKind.Relative);
this.pageFrame.Source = pageUri;
//</SnippetLoadPageContentFileFromCODE>
}
    }
}