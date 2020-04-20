using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Annotations;
using System.Windows.Input;

namespace SDKSamples
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

        //<SnippetKeyboardSampleGotFocus>
        private void TextBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox source = e.Source as TextBox;

            if (source != null)
            {
                // Change the TextBox color when it obtains focus.
                source.Background = Brushes.LightBlue;

                // Clear the TextBox.
                source.Clear();
            }
        }
        //</SnippetKeyboardSampleGotFocus>

        //<SnippetKeyboardSampleLostFocus>
        private void TextBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox source = e.Source as TextBox;

            if (source != null)
            {
                // Change the TextBox color when it loses focus.
                source.Background = Brushes.White;

                // Set the  hit counter back to zero and updates the display.
                this.ResetCounter();
            }
        }
        //</SnippetKeyboardSampleLostFocus>

        public void ResetCounter()
        {
            numberOfHits = 0;
            lblNumberOfTargetHits.Content = numberOfHits;
        }

        //<SnippetKeyboardSampleKeyConverter>
        // Compares the key which was pressed with a target key.
        // If they are the same, updates a label which keeps track
        // of the number of times the target key has been pressed.
        private void SourceTextKeyDown(object sender, KeyEventArgs e)
        {
            // The key converter.
            KeyConverter converter = new KeyConverter();
            Key target = Key.None;

            // Verifying there is only one character in the string.
            if (txtTargetKey.Text.Length == 1)
            {
                // Converting the string to a Key.
                target = (Key)converter.ConvertFromString(txtTargetKey.Text);
            }

            // If the pressed key is equal to the target key.
            if(e.Key == target)
            {
                // Incrementing  the number of hits, and updating
                // the label which displays the number of hits.
                numberOfHits++;
                lblNumberOfTargetHits.Content = numberOfHits;
            }
        }
        //</SnippetKeyboardSampleKeyConverter>

        int numberOfHits = 0;
    }
}