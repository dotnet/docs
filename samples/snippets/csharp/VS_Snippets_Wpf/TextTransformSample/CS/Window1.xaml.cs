using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace SDKSample
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

        // Handle to Click event for the button.
        private void OnDisplayScaledTextClick(object sender, EventArgs e)
        {
            textblockScaleMaster.Text = textboxScaled.Text;
        }

        // Handle to Click event for the button.
        private void OnDisplaySkewedTextClick(object sender, EventArgs e)
        {
            textblockSkewMaster.Text = skewedText.Text;
        }

        // Handle to Click event for the button.
        private void OnDisplayTranslatedTextClick(object sender, EventArgs e)
        {
            textblockTranslateMaster.Text = translatedText.Text;
        }
    }
}