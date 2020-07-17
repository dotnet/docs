// <SnippetInsertInlineIntoTextExampleWholePage>
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
    public partial class InsertInlineIntoTextExample : Page
    {
        public InsertInlineIntoTextExample()
        {

            // Create a paragraph with a short sentence
            Paragraph myParagraph = new Paragraph(new Run("Neptune has 72 times Earth's volume..."));

            // Create two TextPointers that will specify the text range the Span will cover
            TextPointer myTextPointer1 = myParagraph.ContentStart.GetPositionAtOffset(10);
            TextPointer myTextPointer2 = myParagraph.ContentEnd.GetPositionAtOffset(-5);

            // Create a Span that covers the range between the two TextPointers.
            Span mySpan = new Span(myTextPointer1, myTextPointer2);
            mySpan.Background = Brushes.Red;

            // Create a FlowDocument with the paragraph as its initial content.
            FlowDocument myFlowDocument = new FlowDocument(myParagraph);

            this.Content = myFlowDocument;
        }
    }
}
// </SnippetInsertInlineIntoTextExampleWholePage>