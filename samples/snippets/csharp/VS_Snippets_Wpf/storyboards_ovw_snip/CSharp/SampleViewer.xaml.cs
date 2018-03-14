using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;


namespace Microsoft.Samples.Animation
{


    public partial class SampleViewer : Page
    {

        public SampleViewer()
        {
            InitializeComponent();
            StoryboardsExampleFrame.Content = new StoryboardsExample();
            IndirectTargetingExampleFrame.Content = new IndirectTargetingExample();
        }
    
    
    }
}
