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

            MyBasic3DShapeExampleFrame.Content = new Basic3DShapeExample();
            MyMisc3DOperationsExampleFrame.Content = new Misc3DOperationsExample();
            MyViewport3DVisualExampleFrame.Content = new Viewport3dVisualExample();
            MyEmissiveMaterialExampleFrame.Content = new EmissiveMaterialExample();
            MyMultipleTransformationsExampleFrame.Content = new MultipleTransformationsExample();
        }
    }
}
