using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Windows.Media.Animation;

namespace TextElementSnippets
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
            ForgroundBackground();
            ContentStartEnd();
            FontProps();
            TypographyProps();
            ContentStartEnd();
            TextEffectsProp();

            TextBlockTextEffectsProp();
        }

        void ForgroundBackground()
        {
            // <Snippet_TextElement_Background>
            Run run = new Run(
                "This text has a foreground color of dark green, and a background color of bisque.");
            Paragraph par = new Paragraph(run);

            par.Background = Brushes.Bisque;
            par.Foreground = Brushes.DarkGreen;
            // </Snippet_TextElement_Background>
        }

        void FontProps()
        {
            // <Snippet_TextElement_FontProps>
            Run run = new Run(
                "This text will use the Century Gothic font (if available), with fallback to Courier New."
                + "It will render with a font size of 16 pixels in ultra-expanded demi-bold italic.");
            Paragraph par = new Paragraph(run);

            par.FontFamily = new FontFamily("Century Gothic, Courier New");
            par.FontSize = 16;
            par.FontStretch = FontStretches.UltraExpanded;
            par.FontStyle = FontStyles.Italic;
            par.FontWeight = FontWeights.DemiBold;
            // </Snippet_TextElement_FontProps>
        }

        void TypographyProps()
        {
            // <Snippet_TextElement_Typog>
            Paragraph par = new Paragraph();

            Run runText = new Run(
                "This text has some altered typography characteristics.  Note" +
                "that use of an open type font is necessary for most typographic" +
                "properties to be effective.");
            Run runNumerals = new Run("0123456789 10 11 12 13");
            Run runFractions = new Run("1/2 2/3 3/4");

            par.Inlines.Add(runText);
            par.Inlines.Add(new LineBreak());
            par.Inlines.Add(new LineBreak());
            par.Inlines.Add(runNumerals);
            par.Inlines.Add(new LineBreak());
            par.Inlines.Add(new LineBreak());
            par.Inlines.Add(runFractions);

            par.TextAlignment = TextAlignment.Left;
            par.FontSize = 18;
            par.FontFamily = new FontFamily("Palatino Linotype");

            par.Typography.NumeralStyle = FontNumeralStyle.OldStyle;
            par.Typography.Fraction = FontFraction.Stacked;
            par.Typography.Variants = FontVariants.Inferior;
            // </Snippet_TextElement_Typog>
        }

        void ContentStartEnd()
        {
            /*
            // <Snippet_TextElement_ContStartEnd>
            Paragraph par = new Paragraph();

            Run run1 = new Run("Run 1...");
            Run run2 = new Run("Run 2...");
            Run run3 = new Run("Run 3...");
            Run run4 = new Run("Run 4...");

            par.ContentEnd.InsertTextInRun("Run 1...");
            par.ContentEnd.InsertParagraphBreak();
            par.ContentEnd.InsertTextInRun("Run 2...");

            par.ContentStart.InsertParagraphBreak();
            par.ContentStart.InsertTextInRun("Run 3...");
            par.ContentStart.InsertParagraphBreak();
            par.ContentStart.InsertTextInRun("Run 4...");
            // </Snippet_TextElement_ContStartEnd>

            // flowDoc.Blocks.Add(par);
            */
        }

        void TextEffectsProp()
        {
            // <Snippet_TextElement_TextEffects>
            // Create and configure a simple color animation sequence.  Timespan is in 100ns ticks.
            ColorAnimation blackToWhite = new ColorAnimation(Colors.White, Colors.Black, new Duration(new TimeSpan(100000)));
            blackToWhite.AutoReverse = true;
            blackToWhite.RepeatBehavior = RepeatBehavior.Forever;

            // Create a new brush and apply the color animation.
            SolidColorBrush scb = new SolidColorBrush(Colors.Black);
            scb.BeginAnimation(SolidColorBrush.ColorProperty, blackToWhite);

            // Create a new TextEffect object; set foreground brush to the previously created brush.
            TextEffect tfe = new TextEffect();
            tfe.Foreground = scb;
            // Range of text to apply effect to (all).
            tfe.PositionStart = 0;
            tfe.PositionCount = int.MaxValue;

            // Create a new text run, and add the previously created text effect to the run's effects collection.
            Run flickerRun = new Run("Text that flickers...");
            flickerRun.TextEffects = new TextEffectCollection();
            flickerRun.TextEffects.Add(tfe);
            // </Snippet_TextElement_TextEffects>

            flowDoc.Blocks.Add(new Paragraph(flickerRun));
        }

        void TextBlockTextEffectsProp()
        {
            // <Snippet_TextBlock_TextEffects>
            // Create and configure a simple color animation sequence.  Timespan is in 100ns ticks.
            ColorAnimation blackToWhite = new ColorAnimation(Colors.White, Colors.Black, new Duration(new TimeSpan(100000)));
            blackToWhite.AutoReverse = true;
            blackToWhite.RepeatBehavior = RepeatBehavior.Forever;

            // Create a new brush and apply the color animation.
            SolidColorBrush scb = new SolidColorBrush(Colors.Black);
            scb.BeginAnimation(SolidColorBrush.ColorProperty, blackToWhite);

            // Create a new TextEffect object; set foreground brush to the previously created brush.
            TextEffect tfe = new TextEffect();
            tfe.Foreground = scb;
            // Range of text to apply effect to (all).
            tfe.PositionStart = 0;
            tfe.PositionCount = int.MaxValue;

            // Create a new TextBlock with some text.
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Text that flickers...";

            // The TextEffects property is null (no collection) by default.  Create a new one.
            textBlock.TextEffects = new TextEffectCollection();

            // Add the previously created effect to the TextEffects collection.
            textBlock.TextEffects.Add(tfe);
            // </Snippet_TextBlock_TextEffects>
        }
    }
}