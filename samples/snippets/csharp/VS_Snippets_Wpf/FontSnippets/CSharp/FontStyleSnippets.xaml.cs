using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class FontStyleSnippets : Page
    {
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            // <SnippetFontStyleSnippet2>
            FontStyle fontStyle = FontStyles.Normal;
            // </SnippetFontStyleSnippet2>

            Stub2();
        }

        public void Stub1()
        {
            // <SnippetFontStyleSnippet3>
            FontStyle fontStyle = FontStyles.Italic;
            // </SnippetFontStyleSnippet3>
        }

        public void Stub2()
        {
            // <SnippetFontStyleSnippet4>
            FontStyle fontStyle = FontStyles.Oblique;
            // </SnippetFontStyleSnippet4>
        }
    }
}
