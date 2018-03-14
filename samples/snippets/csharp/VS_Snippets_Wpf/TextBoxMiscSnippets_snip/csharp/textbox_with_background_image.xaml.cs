// <SnippetTextBoxBackgroundCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public partial class TextBoxBackgroundExample : Page
    {

        void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

            if (myTextBox.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri(@"TextBoxBackground.gif", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                myTextBox.Background = textImageBrush;

            }
            else
            {

                myTextBox.Background = null;
            }

        }

    }
 
}
// </SnippetTextBoxBackgroundCodeExampleWholePage>