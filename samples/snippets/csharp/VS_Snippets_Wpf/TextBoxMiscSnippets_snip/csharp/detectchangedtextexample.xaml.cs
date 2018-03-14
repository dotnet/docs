// <SnippetDetectChangedTextCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
 
    public partial class DetectChangedTextExample : Page
    {

        // This is a counter for the number of times the TextChanged fires
        // for the tbCountingChanges TextBox.
        private int uiChanges = 0;

        // Event handler for TextChanged Event.
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {

            uiChanges++;
            if (tbCounterText != null)
            {
                tbCounterText.Text = uiChanges.ToString();
            }

        }
    }
}
// </SnippetDetectChangedTextCodeExampleWholePage>