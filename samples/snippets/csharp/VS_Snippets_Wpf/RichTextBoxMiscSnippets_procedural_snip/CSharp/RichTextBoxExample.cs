// <SnippetRichTextBoxCodeOnlyExample>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
namespace SDKSample
{
    public partial class RichTextBoxExample : Page
    {
        public RichTextBoxExample()
        {

            StackPanel myStackPanel = new StackPanel();

            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();

            // Add paragraphs to the FlowDocument.
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 1")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 2")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 3")));
            RichTextBox myRichTextBox = new RichTextBox();

            // Add initial content to the RichTextBox.
            myRichTextBox.Document = myFlowDoc;
            
            myStackPanel.Children.Add(myRichTextBox);
            this.Content = myStackPanel;
            
        }
    }
}
// </SnippetRichTextBoxCodeOnlyExample>