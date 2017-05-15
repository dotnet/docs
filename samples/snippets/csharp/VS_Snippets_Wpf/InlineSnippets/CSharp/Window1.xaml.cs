using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace InlineSnippets
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
            Siblings();
        }

        void FlowDir()
        {
            // <Snippet_Inline_FlowDirection>
            Run run = new Run("This text run will flow from left to right.");
            run.FlowDirection = FlowDirection.LeftToRight;
            // </Snippet_Inline_FlowDirection>
        }

        void Siblings()
        {
            // <Snippet_Inline_SiblingBase>
            // A host paragraph to hold the example Inline elements..
            Paragraph par = new Paragraph();

            // Some arbitrary Inline elements.
            Run run1 = new Run("Text run number 1.");
            Run run2 = new Run("Text run number 2.");
            Bold bold = new Bold(new Run("Bold text."));
            Italic ital = new Italic(new Run("Italic text."));
            Span span1 = new Span(new Run("Span number 1"));
            Span span2 = new Span(new Run("Span number 2"));

            // Add the Inline elements to the Paragraph. Note the order
            // of the inline elements in the paragraph; the order is 
            // arbitrary, but the notion of an order is important with 
            // respect to  what are 'previous' and 'next' elements.
            par.Inlines.Add(run1);
            par.Inlines.Add(run2);
            par.Inlines.Add(bold);
            par.Inlines.Add(ital);
            par.Inlines.Add(span1);
            par.Inlines.Add(span2);
            // </Snippet_Inline_SiblingBase>

            // <Snippet_Inline_NextSibling>
            // After this line executes, "nextSibling" holds "run2", which is
            // the next peer-level Inline following "run1".
            Inline nextSibling = run1.NextInline;

            // After this line executes, "nextSibling" holds "span1", which is
            // the next peer-level Inline following "ital".
            nextSibling = ital.NextInline;

            // After this line executes, "nextSibling" is null, since "span2" is the
            // last Inline element in the Paragraph.
            nextSibling = span2.NextInline;
            // </Snippet_Inline_NextSibling>

            // <Snippet_Inline_PreviousSibling>
            // After this line exectues, "previousSibling" is null, since "run1" is
            // the first Inline element in the Paragraph.
            Inline previousSibling = run1.PreviousInline;

            // After this line executes, "previousSibling" holds "bold", which is the
            // first peer-level Inline preceeding "ital".
            previousSibling = ital.PreviousInline;

            // After this line executes, "previousSibling" holds "span1", which is the
            // first peer-level Inline preceeding "span1".
            previousSibling = span2.NextInline;
            // </Snippet_Inline_PreviousSibling>

            // <Snippet_Inline_Siblings>
            // After this line executes, "siblingInlines" holds "run1", "run2",
            // "bold", "ital", "span1", and "span2", which are all of the sibling
            // Inline elements for "run1" (including "run1");
            InlineCollection siblingInlines = run1.SiblingInlines;

            // Since "bold" is a sibling to "run1", this call will return the
            // same collection of sibling elements as the previous call.
            siblingInlines = bold.SiblingInlines;
            // </Snippet_Inline_Siblings>
        }

        void TextDec()
        {
            {
                // <Snippet_Inline_TextDec>
                Run run1 = new Run("This text will render with the strikethrough effect.");
                run1.TextDecorations = TextDecorations.Strikethrough;
                // </Snippet_Inline_TextDec>
            }
            {
                // <Snippet_Paragraph_TextDec>
                Paragraph parx = new Paragraph(new Run("This text will render with the strikethrough effect."));
                parx.TextDecorations = TextDecorations.Strikethrough;
                // </Snippet_Paragraph_TextDec>
            }
            {
                // <Snippet_TextBlock_TextDec>
                TextBlock textBlock = new TextBlock(new Run("This text will render with the strikethrough effect."));
                textBlock.TextDecorations = TextDecorations.Strikethrough;
                // </Snippet_TextBlock_TextDec>
            }
        }
    }
}