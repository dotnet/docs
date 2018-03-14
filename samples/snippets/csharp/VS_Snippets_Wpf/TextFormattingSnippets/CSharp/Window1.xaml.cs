using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;

using CustomTextClasses;

namespace WindowsApplication1
{
    public partial class Window1 : Window
    {
        private CustomTextSource customTextSource;

        public Window1()
        {
            InitializeComponent();

        }

        private void OnClick(object sender, EventArgs e)
        {
            // Initialize the text store.
            if (customTextSource == null)
                customTextSource = new CustomTextSource();

            UpdateFormattedText03();
        }

        private void UpdateFormattedText()
        {
            // Index into the text of the TextSource object.
            int textStorePosition = 0;

            // The position of the current line.
            Point linePosition = new Point(0, 0);

            // Create a DrawingGroup object for storing formatted text.
            myTextDisplay = new DrawingGroup();
            DrawingContext drawingContext = myTextDisplay.Open();

            // Update the text store.
            customTextSource.Text = textToFormat.Text;

            // <SnippetTextFormattingSnippet1>
            // Create a TextFormatter object.
            TextFormatter formatter = TextFormatter.Create();

            // Create common paragraph property settings.
            CustomTextParagraphProperties customTextParagraphProperties
                = new CustomTextParagraphProperties();

            // Format each line of text from the text store and draw it.
            while (textStorePosition < customTextSource.Text.Length)
            {
                // Create a textline from the text store using the TextFormatter object.
                using (TextLine myTextLine = formatter.FormatLine(
                    customTextSource,
                    textStorePosition,
                    96 * 6,
                    customTextParagraphProperties,
                    null))
                {
                    // Draw the formatted text into the drawing context.
                    myTextLine.Draw(drawingContext, linePosition, InvertAxes.None);

                    // Update the index position in the text store.
                    textStorePosition += myTextLine.Length;

                    // Update the line position coordinate for the displayed line.
                    linePosition.Y += myTextLine.Height;
                }
            }
            // </SnippetTextFormattingSnippet1>

            // Persist the drawn text content.
            drawingContext.Close();

            // Display the formatted text in the DrawingGroup object.
            myDrawingBrush.Drawing = myTextDisplay;
        }

        private void UpdateFormattedText02()
        {
            // Create a DrawingGroup object for storing formatted text.
            myTextDisplay = new DrawingGroup();
            DrawingContext drawingContext = myTextDisplay.Open();

            // Update the text store.
            customTextSource.Text = "The quick red fox jumped over the lazy brown dog.";

            // Create a TextFormatter object.
            TextFormatter formatter = TextFormatter.Create();

            // Create common paragraph property settings.
            CustomTextParagraphProperties customTextParagraphProperties
                = new CustomTextParagraphProperties();

            // <SnippetTextFormattingSnippet2>
            // Create a textline from the text store using the TextFormatter object.
            TextLine myTextLine = formatter.FormatLine(
                customTextSource,
                0,
                400,
                customTextParagraphProperties,
                null);

            // Draw the formatted text into the drawing context.
            myTextLine.Draw(drawingContext, new Point(0, 0), InvertAxes.None);
            // </SnippetTextFormattingSnippet2>

            // Persist the drawn text content.
            drawingContext.Close();

            // Display the formatted text in the DrawingGroup object.
            myDrawingBrush.Drawing = myTextDisplay;
        }

        private void UpdateFormattedText03()
        {
            // Index into the text of the TextSource object.
            int textStorePosition = 0;

            // The position of the current line.
            Point linePosition = new Point(0, 0);

            // Create a DrawingGroup object for storing formatted text.
            myTextDisplay = new DrawingGroup();
            DrawingContext drawingContext = myTextDisplay.Open();

            // Update the text store.
            customTextSource.Text = textToFormat.Text;

            // Create a TextFormatter object.
            TextFormatter formatter = TextFormatter.Create();

            // Create common paragraph property settings.
            CustomTextParagraphProperties customTextParagraphProperties
                = new CustomTextParagraphProperties();

            // <SnippetTextFormattingSnippet3>
            MinMaxParagraphWidth minMaxParaWidth =
                formatter.FormatMinMaxParagraphWidth(customTextSource, 0, customTextParagraphProperties);

            // Format each line of text from the text store and draw it.
            while (textStorePosition < customTextSource.Text.Length)
            {
                // Create a textline from the text store using the TextFormatter object.
                using (TextLine myTextLine = formatter.FormatLine(
                    customTextSource,
                    textStorePosition,
                    minMaxParaWidth.MinWidth,
                    customTextParagraphProperties,
                    null))
                {
                    // Draw the formatted text into the drawing context.
                    myTextLine.Draw(drawingContext, linePosition, InvertAxes.None);

                    // Update the index position in the text store.
                    textStorePosition += myTextLine.Length;

                    // Update the line position coordinate for the displayed line.
                    linePosition.Y += myTextLine.Height;
                }
            }
            // </SnippetTextFormattingSnippet3>

            TextLine myTextLine2 = formatter.FormatLine(
                    customTextSource,
                    0,
                    minMaxParaWidth.MaxWidth,
                    customTextParagraphProperties,
                    null);
            myTextLine2.Draw(drawingContext, linePosition, InvertAxes.None);

            // Persist the drawn text content.
            drawingContext.Close();

            // Display the formatted text in the DrawingGroup object.
            myDrawingBrush.Drawing = myTextDisplay;
        }
    }
}