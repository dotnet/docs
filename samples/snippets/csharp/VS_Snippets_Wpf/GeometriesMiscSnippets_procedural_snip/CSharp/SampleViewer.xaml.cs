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
            MyCompositeShapeExampleFrame.Content = new CompositeShapeExample();
            MyStreamGeometryExampleFrame.Content = new StreamGeometryExample();
            MyStreamGeometryTriangleExampleFrame.Content = new StreamGeometryTriangleExample();
            MyStreamGeometryArcToExampleFrame.Content = new StreamGeometryArcToExample();
            MyStreamGeometryBezierToExampleFrame.Content = new StreamGeometryBezierToExample();
            MyStreamGeometryPolyBezierToExampleFrame.Content = new StreamGeometryPolyBezierToExample();
            MyStreamGeometryPolyLineToExampleFrame.Content = new StreamGeometryPolyLineToExample();
            MyStreamGeometryPolyQuadraticBezierToExampleFrame.Content = new StreamGeometryPolyQuadraticBezierToExample();
            MyStreamGeometryQuadraticBezierToExampleFrame.Content = new StreamGeometryQuadraticBezierToExample();
            MyPolyQuadraticBezierSegmentExampleFrame.Content = new PolyQuadraticBezierSegmentExample();
            MyPolyBezierSegmentExampleFrame.Content = new PolyBezierSegmentExample();
        }
        
    }

 
}
