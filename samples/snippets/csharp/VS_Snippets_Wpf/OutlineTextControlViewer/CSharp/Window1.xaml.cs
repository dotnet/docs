using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

// Namespace that defines the OutlineText custom control class in the referenced assembly.
using OutlineText;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            cbFont.SelectedValue = new FontFamily("Arial");
        }

        // Reset the OutlineText control when a different font has been selected.
        private void OnFontChanged(object sender, SelectionChangedEventArgs args)
        {
            if (args.AddedItems.Count != 1)
            {
                return;
            }

            FontFamily selectedFont = args.AddedItems[0] as FontFamily;

            if (selectedFont != outlineText.Font)
            {
                outlineText.Font = selectedFont;
            }
        }

        // Reset the OutlineText control to custom Fill and Stroke styles.
        private void OnCustomStylesChanged(object sender, SelectionChangedEventArgs args)
        {
            if (outlineText == null) return;

            switch (cbCustomStyles.SelectedIndex)
            {
                case 0:
                    outlineText.Fill = Brushes.LightSteelBlue;
                    outlineText.Stroke = Brushes.Teal;
                    break;

                case 1:
                    outlineText.Fill = CreateLinearGradientSpectrumBrush();
                    outlineText.Stroke = Brushes.Black;
                    break;

                case 2:
                    outlineText.Fill = Brushes.Black;
                    outlineText.Stroke = CreateLinearGradientSpectrumBrush();
                    break;

                case 3:
                    outlineText.Fill = (ImageBrush)this.FindResource("FlamesBrush");
                    outlineText.Stroke = Brushes.Black;
                    break;

                case 4:
                    outlineText.Fill = Brushes.Black;
                    outlineText.Stroke = (ImageBrush)this.FindResource("FlamesBrush");
                    break;

                case 5:
                    outlineText.Fill = (ImageBrush)this.FindResource("ButterflyBrush");
                    outlineText.Stroke = Brushes.Black;
                    break;

                case 6:
                    outlineText.Fill = Brushes.Black;
                    outlineText.Stroke = (ImageBrush)this.FindResource("ButterflyBrush");
                    break;

                case 7:
                    outlineText.Fill = (ImageBrush)this.FindResource("CherriesBrush");
                    outlineText.Stroke = Brushes.Maroon;
                    break;

                case 8:
                    outlineText.Fill = Brushes.Maroon;
                    outlineText.Stroke = (ImageBrush)this.FindResource("CherriesBrush");
                    break;
            }
        }

        // Create a linear gradient brush for the spectrum custom Fill and Stroke.
        private LinearGradientBrush CreateLinearGradientSpectrumBrush()
        {
            GradientStopCollection gsc = new GradientStopCollection();
            gsc.Add(new GradientStop(Colors.Red, 0));
            gsc.Add(new GradientStop(Colors.Orange, 0.2));
            gsc.Add(new GradientStop(Colors.Yellow, 0.4));
            gsc.Add(new GradientStop(Colors.Green, 0.6));
            gsc.Add(new GradientStop(Colors.Blue, 0.8));
            gsc.Add(new GradientStop(Colors.Indigo, 1));

            return new LinearGradientBrush(gsc);
        }
    }
}