using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpanSnippets
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
            Span spanx = new Span();
            Constructors();
            BoldConstructors();
            ItalicConstructors();
            UnderlineConstructors();
            UIContConstructors();
            ParagraphConst();

            TextProp();
        }

        void Constructors()
        {
            {
                // <Snippet_Span_Const1>
                // A child Inline element for the new Span element.
                Run runx = new Run("The Run element derives from Inline, and is therefore" +
                    "an acceptable child element for this new Span.");

                // After this line executes, the new element "spanx"
                // contains the specified Inline element, "runx".
                Span spanx = new Span(runx);
                // </Snippet_Span_Const1>
            }
            {
                // <Snippet_Span_Const2>
                // A child Inline element for the new Span element.
                Run runx = new Run("The Run element derives from Inline, and is therefore" +
                    "an acceptable child element for this new Span.");

                // An empty paragraph will serve as the container for the new Span element.
                Paragraph parx = new Paragraph();

                // After this line executes, the new element "spanx"
                // contains the specified Inline element, "runx".  Also, "spanx" is
                // inserted at the point indicated by the insertionPosition parameter,
                // which in this case indicates the content start position in the Paragraph
                // element "parx".
                Span spanx = new Span(runx, parx.ContentStart);
                // </Snippet_Span_Const2>
            }
            {
                // <Snippet_Span_Const3>
                // Create a paragraph and three text runs to serve as example content.
                Paragraph parx = new Paragraph();
                Run run1 = new Run("Text run 1.");
                Run run2 = new Run("Text run 2.");
                Run run3 = new Run("Text run 3.");

                // Add the three text runs to the paragraph, separated by linebreaks.
                parx.Inlines.Add(run1);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run2);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run3);

                // After this line executes, the selection of content
                // indicated by the "start" and "end" parameters will be
                // enclosed by the new Span.  In this case, the new Span
                // will enclose the entire contents of the Paragraph "parx",
                // which happens to contain three text runs and two linebreaks.
                Span spanx = new Span(parx.ContentStart, parx.ContentEnd);

                // Now, properties set on "spanx" will override default properties
                // on elements contained by "spanx".  For example, setting
                // these arbitrary display properties on "spanx" will affect
                // the child text runs enclosed by "spanx".
                spanx.Foreground = Brushes.Blue;
                spanx.Background = Brushes.GhostWhite;
                spanx.FontFamily = new FontFamily("Century Gothic");

                // Non-default property values override any settings on the
                // enclosing Span element.
                run2.Foreground = Brushes.Red;
                run2.Background = Brushes.AntiqueWhite;
                run2.FontFamily = new FontFamily("Lucida Handwriting");
                // </Snippet_Span_Const3>

                flowDoc.Blocks.Add(parx);
            }

            {
                // <Snippet_Section_Const1>
                // A child Block element for the new Section element.
                Paragraph parx = new Paragraph(new Run("A bit of text content..."));

                // After this line executes, the new element "secx"
                // contains the specified Block element, "parx".
                Section secx = new Section(parx);
                // </Snippet_Section_Const1>
            }
        }

        void InlinesProp()
        {
            // Append an Inline element (Run) to the contents of a Span.
            // <Snippet_SpanInlinesAdd>
            Span spanx = new Span();
            spanx.Inlines.Add(new Run("A bit of text content..."));
            spanx.Inlines.Add(new Run("A bit more text content..."));
            // </Snippet_SpanInlinesAdd>

            // Insert a content inline at the begining of the Span.
            // <Snippet_SpanInlinesInsert>
            Run runx = new Run("Text to insert...");
            spanx.Inlines.InsertBefore(spanx.Inlines.FirstInline, runx);
            // </Snippet_SpanInlinesInsert>

            // Get the number of top-level Inline elements in the Span.
            // <Snippet_SpanInlinesCount>
            int countTopLevelInlines = spanx.Inlines.Count;
            // </Snippet_SpanInlinesCount>

            // Remove the last inline in the Span.
            // <Snippet_SpanInlinesRemoveLast>
            spanx.Inlines.Remove(spanx.Inlines.LastInline);
            // </Snippet_SpanInlinesRemoveLast>

            // Clear all of the inlines (contents) of the Span.
            // <Snippet_SpanInlinesClear>
            spanx.Inlines.Clear();
            // </Snippet_SpanInlinesClear>
        }

        void TextProp()
        {
            // <Snippet_Span_Text>
            Span spanx = new Span();
            spanx.Inlines.Add(new Run("The text contents of this Span."));
            // </Snippet_Span_Text>

            // <Snippet_Paragraph_Text>
            Paragraph parx = new Paragraph();
            parx.Inlines.Add(new Run("The text contents of this Paragraph."));
            // </Snippet_Paragraph_Text>

            // <Snippet_TextBlock_Text>
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "The text contents of this TextBlock.";
            // </Snippet_TextBlock_Text>
        }

        void BoldConstructors()
        {
            {
                // <Snippet_Bold_Const1>
                // A child Inline element for the new Bold element.
                Run runx = new Run("Text to make bold.");

                // After this line executes, the new element "boldx"
                // contains the specified Inline element, "runx".
                Bold boldx = new Bold(runx);
                // </Snippet_Bold_Const1>
            }
            {
                // <Snippet_Bold_Const2>
                // A child Inline element for the new Bold element.
                Run runx = new Run("Text to make bold.");

                // An empty paragraph will serve as the container for the new Bold element.
                Paragraph parx = new Paragraph();

                // After this line executes, the new element "boldx"
                // contains the specified Inline element, "runx".  Also, "boldx" is
                // inserted at the point indicated by the insertionPosition parameter,
                // which in this case indicates the content start position in the Paragraph
                // element "parx".
                Bold boldx = new Bold(runx, parx.ContentStart);
                // </Snippet_Bold_Const2>
            }
            {
                // <Snippet_Bold_Const3>
                // Create a paragraph and three text runs to serve as example content.
                Paragraph parx = new Paragraph();
                Run run1 = new Run("Text run 1.");
                Run run2 = new Run("Text run 2, make bold.");
                Run run3 = new Run("Text run 3.");

                // Add the three text runs to the paragraph, separated by linebreaks.
                parx.Inlines.Add(run1);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run2);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run3);

                // After this line executes, the selection of content
                // indicated by the "start" and "end" parameters will be
                // enclosed by the new Bold.  In this case, the new Bold
                // will enclose the second text run, "run2".
                Bold boldx = new Bold(run2.ContentStart, run2.ContentEnd);
                // </Snippet_Bold_Const3>
            }
        }

        void ItalicConstructors()
        {
            {
                // <Snippet_Italic_Const1>
                // A child Inline element for the new Italic element.
                Run runx = new Run("Text to make italic.");

                // After this line executes, the new element "italx"
                // contains the specified Inline element, "runx".
                Italic italx = new Italic(runx);
                // </Snippet_Italic_Const1>
            }
            {
                // <Snippet_Italic_Const2>
                // A child Inline element for the new Italic element.
                Run runx = new Run("Text to make italic.");

                // An empty paragraph will serve as the container for the new Italic element.
                Paragraph parx = new Paragraph();

                // After this line executes, the new element "italx"
                // contains the specified Inline element, "runx".  Also, "italx" is
                // inserted at the point indicated by the insertionPosition parameter,
                // which in this case indicates the content start position in the Paragraph
                // element "parx".
                Italic italx = new Italic(runx, parx.ContentStart);
                // </Snippet_Italic_Const2>
            }
            {
                // <Snippet_Italic_Const3>
                // Create a paragraph and three text runs to serve as example content.
                Paragraph parx = new Paragraph();
                Run run1 = new Run("Text run 1.");
                Run run2 = new Run("Text run 2, make italic.");
                Run run3 = new Run("Text run 3.");

                // Add the three text runs to the paragraph, separated by linebreaks.
                parx.Inlines.Add(run1);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run2);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run3);

                // After this line executes, the selection of content
                // indicated by the "start" and "end" parameters will be
                // enclosed by the new Italic.  In this case, the new Italic
                // will enclose the second text run, "run2".
                Italic italx = new Italic(run2.ContentStart, run2.ContentEnd);
                // </Snippet_Italic_Const3>
            }
        }

        void UnderlineConstructors()
        {
            {
                // <Snippet_Underline_Const1>
                // A child Inline element for the new Underline element.
                Run runx = new Run("Text to make underlined.");

                // After this line executes, the new element "underx"
                // contains the specified Inline element, "runx".
                Underline underx = new Underline(runx);
                // </Snippet_Underline_Const1>
            }
            {
                // <Snippet_Underline_Const2>
                // A child Inline element for the new Underline element.
                Run runx = new Run("Text to make underlined.");

                // An empty paragraph will serve as the container for the new Underline element.
                Paragraph parx = new Paragraph();

                // After this line executes, the new element "underx"
                // contains the specified Inline element, "runx".  Also, "underx" is
                // inserted at the point indicated by the insertionPosition parameter,
                // which in this case indicates the content start position in the Paragraph
                // element "parx".
                Underline underx = new Underline(runx, parx.ContentStart);
                // </Snippet_Underline_Const2>
            }
            {
                // <Snippet_Underline_Const3>
                // Create a paragraph and three text runs to serve as example content.
                Paragraph parx = new Paragraph();
                Run run1 = new Run("Text run 1.");
                Run run2 = new Run("Text run 2, make underlined.");
                Run run3 = new Run("Text run 3.");

                // Add the three text runs to the paragraph, separated by linebreaks.
                parx.Inlines.Add(run1);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run2);
                parx.Inlines.Add(new LineBreak());
                parx.Inlines.Add(run3);

                // After this line executes, the selection of content
                // indicated by the "start" and "end" parameters will be
                // enclosed by the new Underline.  In this case, the new Underline
                // will enclose the second text run, "run2".
                Underline underx = new Underline(run2.ContentStart, run2.ContentEnd);
                // </Snippet_Underline_Const3>
            }
        }

        void InlineUI()
        {
            {
                // <Snippet_InlineUI_Child>
                Paragraph parx = new Paragraph();
                Run run1 = new Run(" Text to precede the button... ");
                Run run2 = new Run(" Text to follow the button... ");

                // Create a new button to be hosted in the paragraph.
                Button buttonx = new Button();
                buttonx.Content = "Click me!";

                // Create a new InlineUIContainer, and assign the button
                // as the UI container's child.
                InlineUIContainer uiCont = new InlineUIContainer();
                uiCont.Child = buttonx;

                // Add the text runs and UI container to the paragraph, in order.
                parx.Inlines.Add(run1);
                parx.Inlines.Add(uiCont);
                parx.Inlines.Add(run2);
                // </Snippet_InlineUI_Child>
            }

            {
                // <Snippet_BlockUI_Child>
                Section secx = new Section();
                Paragraph par1 = new Paragraph(new Run(" Text to precede the button... "));
                Paragraph par2 = new Paragraph(new Run(" Text to follow the button... "));

                // Create a new button to be hosted in the section.
                Button buttonx = new Button();
                buttonx.Content = "Click me!";

                // Create a new BlockUIContainer, and assign the button
                // as the UI container's child.
                BlockUIContainer uiCont = new BlockUIContainer();
                uiCont.Child = buttonx;

                // Add the text runs and UI container to the paragraph, in order.
                secx.Blocks.Add(par1);
                secx.Blocks.Add(uiCont);
                secx.Blocks.Add(par2);
                // </Snippet_BlockUI_Child>
            }
        }

        void UIContConstructors()
        {
            {
                // <Snippet_InlineUI_Const1>
                // A child UIElement element for the new InlineUIContainer element.
                Button buttonx = new Button();
                buttonx.Content = "Click me!";

                // After this line executes, the new element "inlineUI"
                // contains the specified Inline element, "runx".
                InlineUIContainer inlineUI = new InlineUIContainer(buttonx);
                // </Snippet_InlineUI_Const1>
            }

            {
                // <Snippet_InlineUI_Const2>
                // A child UIElement element for the new InlineUIContainer element.
                Button buttonx = new Button();
                buttonx.Content = "Click me!";

                // An empty paragraph will serve as the container for the new InlineUIContainer element.
                Paragraph parx = new Paragraph();

                // After this line executes, the new element "inlineUI"
                // contains the specified UIElement element, "buttonx".  Also, "inlineUI" is
                // inserted at the point indicated by the insertionPosition parameter,
                // which in this case indicates the content start position in the Paragraph
                // element "parx".
                InlineUIContainer inlineUI = new InlineUIContainer(buttonx, parx.ContentStart);
                // </Snippet_InlineUI_Const2>
            }
            {
                // <Snippet_BlockUI_Const1>
                // A child UIElement element for the new BlockUIContainer element.
                Button buttonx = new Button();
                buttonx.Content = "Click me!";

                // After this line executes, the new element "inlineUI"
                // contains the specified Inline element, "runx".
                BlockUIContainer blockUI = new BlockUIContainer(buttonx);
                // </Snippet_BlockUI_Const1>
            }
        }
        void ParagraphConst()
        {
            // <Snippet_Paragraph_Const1>
            // A child Inline element for the new Paragraph element.
            Run runx = new Run("Text to be hosted in the new paragraph...");

            // After this line executes, the new element "parx"
            // contains the specified Inline element, "runx".
            Paragraph parx = new Paragraph(runx);
            // </Snippet_Paragraph_Const1>
        }
    }
}