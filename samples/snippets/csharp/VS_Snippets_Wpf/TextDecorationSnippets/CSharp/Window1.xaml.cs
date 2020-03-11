using System;
using System.Windows;
using System.Windows.Media;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
         private void WindowLoaded(object sender, EventArgs e)
         {
             SetDefaultStrikethrough();
             //SetRedUnderline();
             SetLinearGradientUnderline();
             SetMaroonBaseline();
             SetToNone();
             //Stub01();
         }

        // <SnippetTextDecorationSnippets1>
        // Use the default font values for the strikethrough text decoration.
        private void SetDefaultStrikethrough()
        {
            // Set the underline decoration directly to the text block.
            TextBlock1.TextDecorations = TextDecorations.Strikethrough;
        }
        // </SnippetTextDecorationSnippets1>

        // <SnippetTextDecorationSnippets2>
        // Use a Red pen for the underline text decoration.
        private void SetRedUnderline()
        {
            // Create an underline text decoration. Default is underline.
            TextDecoration myUnderline = new TextDecoration();

            // Create a solid color brush pen for the text decoration.
            myUnderline.Pen = new Pen(Brushes.Red, 1);
            myUnderline.PenThicknessUnit = TextDecorationUnit.FontRecommended;

            // Set the underline decoration to a TextDecorationCollection and add it to the text block.
            TextDecorationCollection myCollection = new TextDecorationCollection();
            myCollection.Add(myUnderline);
            TextBlock2.TextDecorations = myCollection;
        }
        // </SnippetTextDecorationSnippets2>

        // <SnippetTextDecorationSnippets3>
        // Use a linear gradient pen for the underline text decoration.
        private void SetLinearGradientUnderline()
        {
            // Create an underline text decoration. Default is underline.
            TextDecoration myUnderline = new TextDecoration();

            // Create a linear gradient pen for the text decoration.
            Pen myPen = new Pen();
            myPen.Brush = new LinearGradientBrush(Colors.Yellow, Colors.Red, new Point(0, 0.5), new Point(1, 0.5));
            myPen.Brush.Opacity = 0.5;
            myPen.Thickness = 1.5;
            myPen.DashStyle = DashStyles.Dash;
            myUnderline.Pen = myPen;
            myUnderline.PenThicknessUnit = TextDecorationUnit.FontRecommended;

            // Set the underline decoration to a TextDecorationCollection and add it to the text block.
            TextDecorationCollection myCollection = new TextDecorationCollection();
            myCollection.Add(myUnderline);
            TextBlock3.TextDecorations = myCollection;
        }
        // </SnippetTextDecorationSnippets3>

        private void SetToNone()
        {
            // <SnippetTextDecorationSnippets5a>
            TextBlock2.TextDecorations.Clear();
            // </SnippetTextDecorationSnippets5a>
        }

        // <SnippetTextDecorationSnippets6>
        // Use a Maroon pen for the baseline text decoration.
        private void SetMaroonBaseline()
        {
            // Create an baseline text decoration 2 units lower than the default.
            TextDecoration myBaseline = new TextDecoration(
                    TextDecorationLocation.Baseline,
                    new Pen(Brushes.Maroon, 1),
                    2.0,
                    TextDecorationUnit.Pixel,
                    TextDecorationUnit.Pixel);

            // Set the baseline decoration to a TextDecorationCollection and add it to the text block.
            TextDecorationCollection myCollection = new TextDecorationCollection();
            myCollection.Add(myBaseline);
            TextBlock2.TextDecorations = myCollection;
        }
        // </SnippetTextDecorationSnippets6>

        private void Stub01()
        {
            // Create an underline text decoration.
            TextDecoration myUnderline = new TextDecoration();
            myUnderline.Location = TextDecorationLocation.Underline;

            // Create a solid color brush pen for the text decoration.
            myUnderline.Pen = new Pen(Brushes.Red, 1);

            // <SnippetTextDecorationSnippets7>
            // Move the text decoration lower using pixel value units.
            myUnderline.PenOffset = 2;
            myUnderline.PenOffsetUnit = TextDecorationUnit.Pixel;
            myUnderline.PenThicknessUnit = TextDecorationUnit.Pixel;
            // </SnippetTextDecorationSnippets7>

            // Set the underline decoration to a TextDecorationCollection and add it to the text block.
            TextDecorationCollection myCollection = new TextDecorationCollection();
            myCollection.Add(myUnderline);
            TextBlock2.TextDecorations = myCollection;
        }
    }
}