//<SnippetCallApplicationGetResourceStreamCODEBEHIND1>
using System;
using System.IO;
using System.Windows.Resources;
//</SnippetCallApplicationGetResourceStreamCODEBEHIND1>
using System.Windows;
using System.Windows.Controls;
namespace ResourcesSample
{
    /// <summary>
    /// Interaction logic for ApplicationGetResourceStreamSnippetWindow.xaml
    /// </summary>

    public partial class ApplicationGetResourceStreamSnippetWindow : Window
    {

        public ApplicationGetResourceStreamSnippetWindow()
        {
            InitializeComponent();

            Method1();
            Method2();
            Method3();
        }
void Method1()
{
//<SnippetCallApplicationGetResourceStreamCODEBEHIND2>
// Create a URI that identifies the compiled resource file
Uri uri = new Uri("/ResourceFile.xaml", UriKind.Relative);
// Load resource file
StreamResourceInfo info = Application.GetResourceStream(uri);
string resourceType = info.ContentType; // Resource file type
Stream resourceStream = info.Stream; // Resource file stream
//</SnippetCallApplicationGetResourceStreamCODEBEHIND2>
}

void Method2()
{
//<SnippetLoadAPageResourceFileManuallyCODE>
// Navigate to xaml page
Uri uri = new Uri("/PageResourceFile.xaml", UriKind.Relative);
StreamResourceInfo info = Application.GetResourceStream(uri);
System.Windows.Markup.XamlReader reader = new System.Windows.Markup.XamlReader();
Page page = (Page)reader.LoadAsync(info.Stream);
this.pageFrame.Content = page;
//</SnippetLoadAPageResourceFileManuallyCODE>
}

void Method3()
{
//<SnippetLoadPageResourceFileFromCODE>
Uri pageUri = new Uri("/PageResourceFile.xaml", UriKind.Relative);
this.pageFrame.Source = pageUri;
//</SnippetLoadPageResourceFileFromCODE>
}

    }
}