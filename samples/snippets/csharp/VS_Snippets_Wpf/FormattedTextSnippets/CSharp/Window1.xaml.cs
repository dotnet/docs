using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace SDKSample
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

        private void WindowLoaded(object sender, EventArgs e)
        {
            MyControl myControl1 = new MyControl();
            myCanvas.Children.Add(myControl1);
        }
    }

    public class MyControl : FrameworkElement
    {
        // <SnippetFormattedTextSnippets1>
        protected override void OnRender(DrawingContext drawingContext)
        {
            string testString = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor";

            // Create the initial formatted text string.
            FormattedText formattedText = new FormattedText(
                testString,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                32,
                Brushes.Black);

            // Set a maximum width and height. If the text overflows these values, an ellipsis "..." appears.
            formattedText.MaxTextWidth = 300;
            formattedText.MaxTextHeight = 240;

            // Use a larger font size beginning at the first (zero-based) character and continuing for 5 characters.
            // <SnippetFormattedTextSnippets2>
            // The font size is calculated in terms of points -- not as device-independent pixels.
            formattedText.SetFontSize(36 * (96.0 / 72.0), 0, 5);
            // </SnippetFormattedTextSnippets2>

            // Use a Bold font weight beginning at the 6th character and continuing for 11 characters.
            formattedText.SetFontWeight(FontWeights.Bold, 6, 11);

            // Use a linear gradient brush beginning at the 6th character and continuing for 11 characters.
            formattedText.SetForegroundBrush(
                                    new LinearGradientBrush(
                                    Colors.Orange,
                                    Colors.Teal,
                                    90.0),
                                    6, 11);

            // Use an Italic font style beginning at the 28th character and continuing for 28 characters.
            formattedText.SetFontStyle(FontStyles.Italic, 28, 28);

            // Draw the formatted text string to the DrawingContext of the control.
            drawingContext.DrawText(formattedText, new Point(10, 0));
        }
        // </SnippetFormattedTextSnippets1>

        // Provide a required override for the MeasureOverride method.
        protected override Size MeasureOverride(Size availableSize)
        {
            // Return the value of the parameter.
            return base.MeasureOverride(availableSize);
        }

        // Provide a required override for the ArrangeOverride method.
        protected override Size ArrangeOverride(Size finalSize)
        {
            // Return the value of the parameter.
            return base.ArrangeOverride(finalSize);
        }
    }

    public class MyControl02 : FrameworkElement
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            string testString = "The quick red fox jumps over the lazy brown dog.";

            // Create the initial formatted text string.
            FormattedText formattedText = new FormattedText(
                testString,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Narkism"),
                24,
                Brushes.Black);

            // <SnippetFormattedTextSnippets3>
            // Get the minimimum line width for the text content -- that is, the widest word.
            double minWidth = formattedText.MinWidth;

            // Set the maximum text width to the widest word in the text content.
            formattedText.MaxTextWidth = minWidth;
            // </SnippetFormattedTextSnippets3>

            //formattedText.MaxTextWidth = 40.863333333333344;

            // Set a maximum height. If the text overflows this value, an ellipsis "..." appears.
            formattedText.MaxTextHeight = 400;

            // Draw the formatted text string to the DrawingContext of the control.
            drawingContext.DrawText(formattedText, new Point(10, 0));
        }

        // Provide a required override for the MeasureOverride method.
        protected override Size MeasureOverride(Size availableSize)
        {
            // Return the value of the parameter.
            return base.MeasureOverride(availableSize);
        }

        // Provide a required override for the ArrangeOverride method.
        protected override Size ArrangeOverride(Size finalSize)
        {
            // Return the value of the parameter.
            return base.ArrangeOverride(finalSize);
        }
    }
}
