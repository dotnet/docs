using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Navigation;

namespace HyperlinkSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            Constructors();
        }

        void Constructors()
        {
            {
                // <Snippet_Hyperlink_Const1>
                // A child Inline element for the new Hyperlink element.
                Run runx = new Run("Link text for the Hyperlink element.");

                // After this line executes, the new element "hyper1"
                // contains the specified Inline element, "runx".
                Hyperlink hyperl = new Hyperlink(runx);
                // </Snippet_Hyperlink_Const1>
            }
            {
                // <Snippet_Hyperlink_Const2>
                // A child Inline element for the new Hyperlink element.
                Run runx = new Run("Link text for the Hyperlink element.");

                // An empty paragraph will serve as the container for the new Hyperlink element.
                Paragraph parx = new Paragraph();

                // After this line executes, the new element "hyperl"
                // contains the specified Inline element, "runx".  Also, "hyperl" is
                // inserted at the point indicated by the insertionPosition parameter, 
                // which in this case indicates the content start position in the Paragraph 
                // element "parx".
                Hyperlink hyperl = new Hyperlink(runx, parx.ContentStart);
                // </Snippet_Hyperlink_Const2>
            }
            {
                // <Snippet_Hyperlink_Const3>
                // Create a paragraph and three text runs to serve as example content.  
                Paragraph parx = new Paragraph();
                Run run1 = new Run("Text run 1.");
                Run run2 = new Run("Text to link.");
                Run run3 = new Run("Text run 3.");

                // Add the three text runs to the paragraph, separated by linebreaks.
                parx.Inlines.Add(run1);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run2);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run3);

                // After this line executes, the selection of content
                // indicated by the "start" and "end" parameters will be
                // enclosed by the new Hyperlink.  In this case, the new Hyperlink
                // will enclose the entire contents of the the text run "run2".  
                Hyperlink hyperl = new Hyperlink(run2.ContentStart, run2.ContentEnd);
                // </Snippet_Hyperlink_Const3>

                flowDoc.Blocks.Add(parx);
            }
        }

        void Props()
        {
            // <Snippet_Hyperlink_NavUri>
            Paragraph parx = new Paragraph();
            Run run1 = new Run("Text preceeding the hyperlink.");
            Run run2 = new Run("Text following the hyperlink.");
            Run run3 = new Run("Link Text.");

            Hyperlink hyperl = new Hyperlink(run3);
            hyperl.NavigateUri = new Uri("http://search.msn.com");

            parx.Inlines.Add(run1);
            parx.Inlines.Add(hyperl);
            parx.Inlines.Add(run2);
            // </Snippet_Hyperlink_NavUri>
        }
     }
}
