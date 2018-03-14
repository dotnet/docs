using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
namespace SDKSample
{
    public partial class BeginChangeEndChangeExample : Page
    {
        public BeginChangeEndChangeExample()
        {

            StackPanel myStackPanel = new StackPanel();

            // <SnippetBeginChangeEndChangeCodeExampleInline1>
            TextBox myTextBox = new TextBox();

            // Begin the change block. Once BeginChange() is called
            // no text content or selection change events will be raised 
            // until EndChange is called. Also, all edits made within
            // a BeginChange/EndChange block are wraped in a single undo block.
            myTextBox.BeginChange();

            // Put some initial text in the TextBox.
            myTextBox.Text = "Initial text in TextBox";
            
            // Make other changes if desired...

            // Whenever BeginChange() is called EndChange() must also be
            // called to end the change block.
            myTextBox.EndChange();
            // </SnippetBeginChangeEndChangeCodeExampleInline1>

            myStackPanel.Children.Add(myTextBox);
            this.Content = myStackPanel;
            
        }

    }
}