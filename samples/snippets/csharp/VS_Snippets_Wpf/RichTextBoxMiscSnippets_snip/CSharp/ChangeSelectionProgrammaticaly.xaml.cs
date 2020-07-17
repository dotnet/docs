// <SnippetChangeSelectionProgrammaticalyCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
    public partial class ChangeSelectionProgrammaticaly : Page
	{

        // Change the current selection.
        void ChangeSelection(Object sender, RoutedEventArgs args)
        {
            // Create two arbitrary TextPointers to specify the range of content to select.
            TextPointer myTextPointer1 = myParagraph.ContentStart.GetPositionAtOffset(20);
            TextPointer myTextPointer2 = myParagraph.ContentEnd.GetPositionAtOffset(-10);

            // Programmatically change the selection in the RichTextBox.
            richTB.Selection.Select(myTextPointer1, myTextPointer2);
        }
    }
}
// </SnippetChangeSelectionProgrammaticalyCodeExampleWholePage>