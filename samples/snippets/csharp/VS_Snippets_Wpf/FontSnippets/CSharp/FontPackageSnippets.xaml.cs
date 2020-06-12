using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class FontPackageSnippets : Page
    {
        private void FontPackageSnippetsLoaded(object sender, RoutedEventArgs e)
        {
            PackageStub6();
        }

        public void PackageStub1()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontPackageSnippet2>
            // The font resource reference includes the base URI reference (application directory level),
            // and a relative URI reference.
            myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./resources/#Pericles Light");
            // </SnippetFontPackageSnippet2>
        }

        public void PackageStub2()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontPackageSnippet5>
            // The base URI reference can include an application subdirectory.
            myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/resources/"), "./#Pericles Light");
            // </SnippetFontPackageSnippet5>
        }

        public void PackageStub3()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontPackageSnippet6>
            // Create a new FontFamily object, using an absolute URI reference.
            myTextBlock.FontFamily = new FontFamily("file:///d:/MyFonts/#Pericles Light");
            // </SnippetFontPackageSnippet6>
        }

                public void PackageStub4()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontPackageSnippet7>
            // Create a new FontFamily object, using a base URI reference and a relative URI reference.
            myTextBlock.FontFamily = new FontFamily(new Uri("file:///d:/MyFonts/"), "./#Pericles Light");
            // </SnippetFontPackageSnippet7>
        }

        public void PackageStub5()
        {
            myTextBlock.Foreground = Brushes.Teal;

            // <SnippetFontPackageSnippet9>
            // Create a new FontFamily object, using a font in the system fonts collection.
            myTextBlock.FontFamily = new FontFamily("Comic Sans MS");

            // The value of baseUri is null.
            Uri baseUri = myTextBlock.FontFamily.BaseUri;

            // Create a new FontFamily object, using an absolute URI reference.
            myTextBlock.FontFamily = new FontFamily("file:///d:/MyFonts/#Pericles Light");

            // The value of baseUri is null.
            baseUri = myTextBlock.FontFamily.BaseUri;

            // Create a new FontFamily object, using a base URI reference and a relative URI reference.
            myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/resources/"), "./#Pericles Light");

            // The value of baseUri.AbsoluteUri is "pack://application:,,,/resources/".
            baseUri = myTextBlock.FontFamily.BaseUri;
            // </SnippetFontPackageSnippet9>
        }

        public void PackageStub6()
        {
            myTextBlock.Foreground = Brushes.SlateBlue;

            // <SnippetFontPackageSnippet10>
            // Create a new FontFamily object, using a base URI reference and a relative URI reference.
            myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/resources/"), "./#Pericles Light");

            // The value of baseUri.AbsoluteUri is "pack://application:,,,/resources/".
            Uri baseUri = myTextBlock.FontFamily.BaseUri;

            // The value of source is "./#Pericles Light".
            string source = myTextBlock.FontFamily.Source;
            // </SnippetFontPackageSnippet10>
        }
    }
}
