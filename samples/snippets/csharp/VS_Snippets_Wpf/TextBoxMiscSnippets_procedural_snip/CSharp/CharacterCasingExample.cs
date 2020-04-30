// <SnippetCharacterCasingCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
namespace SDKSample
{
    public partial class CharacterCasingExample : Page
    {
        public CharacterCasingExample()
        {
            StackPanel myStackPanel = new StackPanel();

            //Create TextBox
            TextBox myTextBox = new TextBox();
            myTextBox.Width = 100;

            // The CharacterCasing property of this TextBox is set to
            // "Upper" which causes all manually typed characters to
            // be converted to upper case.
            myTextBox.CharacterCasing = CharacterCasing.Upper;
            myStackPanel.Children.Add(myTextBox);
            this.Content = myStackPanel;
        }
    }
}
// </SnippetCharacterCasingCodeExampleWholePage>