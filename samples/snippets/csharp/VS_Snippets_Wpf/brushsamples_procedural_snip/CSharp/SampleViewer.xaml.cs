using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;


namespace Microsoft.Samples.BrushExamples
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
            MyOpacityExampleFrame.Content = new OpacityExample();
            MySolidColorBrushExampleFrame.Content = new SolidColorBrushExample();
        }
    }

}
