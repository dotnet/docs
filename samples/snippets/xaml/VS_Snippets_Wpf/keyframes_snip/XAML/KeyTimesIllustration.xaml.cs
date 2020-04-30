using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Samples.KeyFrameExamples
{
    /// <summary>
    /// Interaction logic for KeyTimesIllustration.xaml
    /// </summary>

    public partial class KeyTimesIllustration : System.Windows.Controls.Page
    {
        public KeyTimesIllustration()
        {
            InitializeComponent();
        }

        private static Rectangle createGhostRectangle()
        {
            Rectangle r = new Rectangle();
            r.Width = 50;
            r.Height = 50;
            r.Stroke = Brushes.Black;
            r.StrokeThickness = 5;
            return r;
        }
    }
}