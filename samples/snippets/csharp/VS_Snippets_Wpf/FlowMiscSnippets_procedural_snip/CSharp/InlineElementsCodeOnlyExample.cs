// <SnippetInlineElementsCodeOnlyExampleWholePage>
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
    public partial class InlineElementsCodeOnlyExample : Page
    {
        public InlineElementsCodeOnlyExample()
        {

            // Create paragraph that will go into the Figure and populate with text.
            Paragraph myParagraph1 = new Paragraph(new Run("Neptune has 72 times Earth's volume..."));
            myParagraph1.FontStyle = FontStyles.Italic;
            myParagraph1.TextAlignment = TextAlignment.Left;
            myParagraph1.Background = Brushes.Beige;
            myParagraph1.Foreground = Brushes.DarkGreen;

            // Create a Figure with a paragraph in it. This Figure will go into another paragraph
            // below.
            Figure myFigure = new Figure(myParagraph1);

            myFigure.Width = new FigureLength(300, FigureUnitType.Pixel);
            myFigure.Height = new FigureLength(50, FigureUnitType.Pixel); ;
            myFigure.HorizontalAnchor = FigureHorizontalAnchor.PageLeft;
            myFigure.HorizontalOffset = 100;
            myFigure.VerticalOffset = 20;

            // Create some paragraph text.
            string paragraphString = "Neptune(planet), major planet in the solar system, eighth planet"
            + "from the Sun and fourth largest in diameter.  Neptune maintains an almost constant"
            + "distance, about 4,490 million km (about 2,790 million mi), from the Sun.  Neptune"
            + "revolves outside the orbit of Uranus and for most of its orbit moves inside the"
            + "elliptical path of the outermost planet Pluto (see Solar System). Every 248 years,"
            + "Pluto’s elliptical orbit brings the planet inside Neptune’s nearly circular orbit"
            + "for about 20 years, temporarily making Neptune the farthest planet from the Sun."
            + "The last time Pluto’s orbit brought it inside Neptune’s orbit was in 1979. In"
            + "1999 Pluto’s orbit carried it back outside Neptune’s orbit.";
            // A child Inline element for the new Paragraph element.
            Run myRun = new Run(paragraphString);
            Paragraph myParagraph = new Paragraph(myRun, myFigure);

            // Create a FlowDocument with the paragraph as its initial content.
            FlowDocument myFlowDocument = new FlowDocument(myParagraph);

            this.Content = myFlowDocument;

/*
                    <Figure
          Width="300" Height="50" Background="GhostWhite"
          HorizontalAnchor="PageLeft"
          HorizontalOffset="100" VerticalOffset="20"
          >
          <Paragraph
            FontStyle="Italic" TextAlignment="Left"
            Background="Beige" Foreground="DarkGreen"
            >
            Neptune has 72 times Earth's volume...
          </Paragraph>
        </Figure>

 */
        }
    }
}
// </SnippetInlineElementsCodeOnlyExampleWholePage>