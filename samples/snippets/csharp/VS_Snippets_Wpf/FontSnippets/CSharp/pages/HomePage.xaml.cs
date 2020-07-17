using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Markup;

namespace SDKSample
{
    public partial class HomePage : Page
    {
        private void HomePageLoaded(object sender, RoutedEventArgs e)
        {
            PackageStub1();
        }

        public void PackageStub1()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontPackageSnippet4>
            // The font resource reference includes the base Uri (application directory level),
            // and the file resource location, which is relative to the base Uri.
            myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "/pages/#Pericles Light");
            // </SnippetFontPackageSnippet4>
        }
   }
}
