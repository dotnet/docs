// <SnippetFigureCodeOnlyExampleWholePage>
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
    public partial class FigureExample : Page
    {
        public FigureExample()
        {

            // Create strings to use as content.
            string strFigure = "A Figure embeds content into flow content with" +
                               " placement properties that can be customized" +
                               " independently from the primary content flow";
            string strOther = "Lorem ipsum dolor sit amet, consectetuer adipiscing" +
                              " elit, sed diam nonummy nibh euismod tincidunt ut laoreet" +
                              " dolore magna aliquam erat volutpat. Ut wisi enim ad" +
                              " minim veniam, quis nostrud exerci tation ullamcorper" +
                              " suscipit lobortis nisl ut aliquip ex ea commodo consequat." +
                              " Duis autem vel eum iriure.";

            // Create a Figure and assign content and layout properties to it.
            Figure myFigure = new Figure();
            myFigure.Width = new FigureLength(300);
            myFigure.Height = new FigureLength(100);
            myFigure.Background = Brushes.GhostWhite;
            myFigure.HorizontalAnchor = FigureHorizontalAnchor.PageLeft;
            Paragraph myFigureParagraph = new Paragraph(new Run(strFigure));
            myFigureParagraph.FontStyle = FontStyles.Italic;
            myFigureParagraph.Background = Brushes.Beige;
            myFigureParagraph.Foreground = Brushes.DarkGreen;
            myFigure.Blocks.Add(myFigureParagraph);

            // Create the paragraph and add content to it.
            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(myFigure);
            myParagraph.Inlines.Add(new Run(strOther));

            // Create a FlowDocument and add the paragraph to it.
            FlowDocument myFlowDocument = new FlowDocument();
            myFlowDocument.Blocks.Add(myParagraph);

            this.Content = myFlowDocument;
        }
    }
}
// </SnippetFigureCodeOnlyExampleWholePage>