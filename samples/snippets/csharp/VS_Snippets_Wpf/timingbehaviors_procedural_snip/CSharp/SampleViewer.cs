// <Snippet101>
// EllipseGeometryExample.cs
//
// This sample demonstrates how to animate the center
// position of an EllipseGeometry using a PointAnimation.

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using HexConverter;

namespace Microsoft.Samples.Animation.TimingBehavior
{

    public class SampleViewer : Page {

        public SampleViewer()
        {
            this.WindowTitle = "Timing Behaviors";

            DockPanel myDockPanel = new DockPanel();
            myDockPanel.Background = Brushes.White;

            TabControl myTabControl = new TabControl();
            myTabControl.Name = "sampleSelector";
            myDockPanel.Children.Add(myTabControl);

            TabItem myTabItem = new TabItem();
            myTabItem.Header = "RepeatBehavior Example";
            Frame myFrame = new Frame();
            //myFrame.Source = new Uri("RepeatBehaviorExample.cs");
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            myTabItem = new TabItem();
            myTabItem.Header = "AutoReverse Example";
            myFrame = new Frame();
            //myFrame.Source = new Uri("AutoReverseExample.cs");
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            myTabItem = new TabItem();
            myTabItem.Header = "BeginTime Example";
            myFrame = new Frame();
           // myFrame.Source = new Uri("BeginTimeExample.cs");
            //myFrame.Content = new BeginTimeExample();
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            myTabItem = new TabItem();
            myTabItem.Header = "FillBehavior Example";
            myFrame.Content = new FillBehaviorExample();
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            myTabItem = new TabItem();
            myTabItem.Header = "Speed Example";
            myFrame = new Frame();
            //myFrame.Source = new Uri("SpeedExample.cs");
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            myTabItem = new TabItem();
            myTabItem.Header = "Acceleration and Deceleration Example";
            myFrame = new Frame();
            myFrame.Content = new AccelDecelExample();
            //myFrame.Source = new Uri("AccelDecelExample.cs");
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            myTabItem = new TabItem();
            myTabItem.Header = "Opacity Animation Example";
            myFrame = new Frame();
            //myFrame.Source = new Uri("OpacityAnimationExample.cs");
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            myTabItem = new TabItem();
            myTabItem.Header = "Styles Example";
            myFrame = new Frame();
            // myFrame.Source = new Uri("StyleStoryboardsExample.cs");
            myFrame.Background = Brushes.White;
            myTabControl.Items.Add(myTabItem);

            this.Content = myDockPanel;
        }
    }
}
// </Snippet101>
