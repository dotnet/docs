using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;


namespace SDKSample
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
            MyPaintWithVideoExampleFrame.Content = new PaintWithVideoExample();
            MyReflectionExampleFrame.Content = new ReflectionExample();
            MyAutoLayoutContentExampleFrame.Content = new AutoLayoutContentExample();
        }
        
    }

 
}
