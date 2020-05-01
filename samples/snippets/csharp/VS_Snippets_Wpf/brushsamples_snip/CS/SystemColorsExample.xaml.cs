using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Data;

namespace Microsoft.Samples.Brushes
{

    public partial class SystemColorsExample : Page
    {

        public SystemColorsExample()
        {
        }

        private void temp(object Sender, RoutedEventArgs e)
        {

            mainPanel.Background = System.Windows.Media.Brushes.Orange;
            //MessageBox.Show("!");
            mainPanel.Background = SystemColors.DesktopBrush;
            //mainPanel.SetResourceReference(Panel.BackgroundProperty, SystemColors.DesktopBrush);
            mainPanel.Height = 800;
        }
    }
}
