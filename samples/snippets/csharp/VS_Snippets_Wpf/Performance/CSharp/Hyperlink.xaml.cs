using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class Page1 : Page
    {
        // <SnippetPerformanceSnippet15>
        // Display the underline on only the MouseEnter event.
        private void OnMouseEnter(object sender, EventArgs e)
        {
            myHyperlink.TextDecorations = TextDecorations.Underline;
        }

        // Remove the underline on the MouseLeave event.
        private void OnMouseLeave(object sender, EventArgs e)
        {
            myHyperlink.TextDecorations = null;
        }
        // </SnippetPerformanceSnippet15>
    }
}