using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FloaterFigureSnippets
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

        void WindowLoaded(Object sender, RoutedEventArgs ags)
        {
            Consts();
            FigureProps();
            FloaterProps();
        }

        void Consts()
        {
            {
                // <Snippet_FigureConst1>
                Paragraph parx = new Paragraph(new Run("Figure content..."));
                Figure figx = new Figure(parx);
                // </Snippet_FigureConst1>
            }

            {
                // <Snippet_FigureConst2>
                Span spanx = new Span();
                Paragraph parx = new Paragraph(new Run("Figure content..."));
                // This will populate the Figure with the Paragraph parx, and insert
                // the Figure at the beginning of the Span spanx.
                Figure figx = new Figure(parx, spanx.ContentStart);
                // </Snippet_FigureConst2>
            }

            {
                // <Snippet_FloaterConst1>
                Paragraph parx = new Paragraph(new Run("Floater content..."));
                Floater flotx = new Floater(parx);
                // </Snippet_FloaterConst1>
            }

            {
                // <Snippet_FloaterConst2>
                Span spanx = new Span();
                Paragraph parx = new Paragraph(new Run("Floater content..."));

                // This will populate the Floater with the Paragraph parx, and insert
                // the Floater at the beginning of the Span spanx.
                Floater flotx = new Floater(parx, spanx.ContentStart);
                // </Snippet_FloaterConst2>
            }
        }

        void FigureProps()
        {
            // <Snippet_FigureProps>
            Figure figx = new Figure();
            figx.Name = "myFigure";
            figx.Width = new FigureLength(140);
            figx.Height = new FigureLength(50);
            figx.HorizontalAnchor = FigureHorizontalAnchor.PageCenter;
            figx.VerticalAnchor = FigureVerticalAnchor.PageCenter;
            figx.HorizontalOffset = 100;
            figx.VerticalOffset = 20;
            figx.WrapDirection = WrapDirection.Both;

            Paragraph parx = new Paragraph(figx);
            FlowDocument flowDoc = new FlowDocument(parx);
            // </Snippet_FigureProps>
        }

        void FloaterProps()
        {
            // <Snippet_FloaterProps>
            Floater flotx = new Floater();
            flotx.Name = "myFloater";
            flotx.Width = 100;
            flotx.HorizontalAlignment = HorizontalAlignment.Left;

            Paragraph parx = new Paragraph(flotx);
            FlowDocument flowDoc = new FlowDocument(parx);
            // </Snippet_FloaterProps>
        }

        
    }
}