using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsoft.Samples.PerFrameAnimations
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class SimpleExample : Page
    {
        Random rand = new Random();

        public SimpleExample()
            : base()
        {
            CompositionTarget.Rendering += UpdateColor;
        }

        private void UpdateColor(object sender, EventArgs e)
        {
            // Set a random color
            animatedBrush.Color = Color.FromRgb((byte)rand.Next(255),
                                              (byte)rand.Next(255),
                                              (byte)rand.Next(255));
        }
    }
}