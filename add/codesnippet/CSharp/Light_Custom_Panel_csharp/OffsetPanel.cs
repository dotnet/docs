using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;

namespace OffsetPanel
{
	public class MyApp : Application
	{
        Window mainWindow;
        OffsetPanel offsetPanel1;
        TextBlock txt1;
        Rectangle rect1;
        Button btn1;
        Border border1;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }

        private void CreateAndShowMainWindow()
        {
            // ********* Create the application's main Window and Border and instantiate a OffsetPanel *********
            border1 = new Border();
            border1.VerticalAlignment = VerticalAlignment.Top;
            border1.HorizontalAlignment = HorizontalAlignment.Left;
            border1.BorderThickness = new Thickness(2);
            border1.BorderBrush = Brushes.DarkOrange;

            offsetPanel1 = new OffsetPanel();
            offsetPanel1.Width = 500;
            offsetPanel1.Height = 500;
            offsetPanel1.VerticalAlignment = VerticalAlignment.Stretch;
            offsetPanel1.HorizontalAlignment = HorizontalAlignment.Stretch;

            // ********* Add a child TextBlock Element *********         
            txt1 = new TextBlock();
            txt1.Text = "This is a line of Text within a TextBlock Element.";
            txt1.Background = Brushes.Red;
            OffsetPanel.SetOffsetLeft(txt1, 100);
            OffsetPanel.SetOffsetTop(txt1, 100);
            OffsetPanel.SetInflateSize(txt1, 50);
            OffsetPanel.SetShareCoordinates(txt1, true);

            // ********* Add a Button Element *********
            btn1 = new Button();
            btn1.Background = Brushes.RoyalBlue;
            btn1.Content = "A Button";
            btn1.BorderBrush = Brushes.Black;
            OffsetPanel.SetOffsetLeft(btn1, 100);
            OffsetPanel.SetOffsetTop(btn1, 100);
            OffsetPanel.SetInflateSize(btn1, 50);
            OffsetPanel.SetShareCoordinates(btn1, false);

            // ********* Add a child Rectangle Element ********* 
            rect1 = new Rectangle();
            rect1.Fill = Brushes.Purple;
            OffsetPanel.SetOffsetLeft(rect1, 100);
            OffsetPanel.SetOffsetTop(rect1, 100);
            OffsetPanel.SetInflateSize(rect1, 10);
            OffsetPanel.SetShareCoordinates(rect1, false);

            // ********* Add the text element defined above as a child of the OffsetPanel *********
			offsetPanel1.Children.Add(txt1);
            offsetPanel1.Children.Add(btn1);
            offsetPanel1.Children.Add(rect1);
            
            // ********* Add the OffsetPanel to the Border *********
            border1.Child = offsetPanel1;

            // ********* Add the OffsetPanel as a Child of the MainWindow and show the Window *********
            mainWindow = new Window();
            mainWindow.Content = border1;
            mainWindow.Title = "Custom OffsetPanel Sample";
            mainWindow.Show();
        }

		// Define the custom OffsetPanel class, derived from Panel
		
        public class OffsetPanel : Panel
        {

            // ********* Define a default Constructor *********
            public OffsetPanel() : base()
            {
            }
            
            // <Snippet1>
            // Override the OnRender call to add a Background and Border to the OffSetPanel
            protected override void OnRender(DrawingContext dc)
            {
                SolidColorBrush mySolidColorBrush  = new SolidColorBrush();
                mySolidColorBrush.Color = Colors.LimeGreen;
                Pen myPen = new Pen(Brushes.Blue, 10);
                Rect myRect = new Rect(0, 0, 500, 500);
                dc.DrawRectangle(mySolidColorBrush, myPen, myRect);
            }
            //</Snippet1>
            // ********* Override the Measure method of Panel *********
            protected override Size MeasureOverride(Size constraint)
            {
                Size childConstraint = new Size(Double.PositiveInfinity, Double.PositiveInfinity);

                foreach (UIElement child in InternalChildren)
                {
                    if (child == null) { continue; }
                    child.Measure(childConstraint);
                }

                return new Size();
            }

            // ********* Override the Arrange method of Panel *********
            protected override Size ArrangeOverride(Size arrangeSize)
            {
                foreach (UIElement child in InternalChildren)
                {
                    if (child == null) { continue; }

                    if (GetShareCoordinates(child) == true)
                    {
                        double x = GetOffsetLeft(child);
                        double y = GetOffsetTop(child);
                        double z = GetInflateSize(child);

                        if (z == 0 || z == Double.NaN)
                        {
                            child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                        }

                        else
                        {
                            child.Arrange(new Rect(new Point(x, y), new Size((child.DesiredSize.Width + z), (child.DesiredSize.Height + z))));
                        }
                    }

                    else
                    {
                        double x = GetOffsetLeft(child);
                        double y = GetOffsetTop(child);
                        double z = GetInflateSize(child);

                        for (int i = 0; i < InternalChildren.Count; i++)
                        {
                            if (i + 1 >= InternalChildren.Count) { break; }
                            if (GetOffsetLeft(InternalChildren[i]) == GetOffsetLeft(InternalChildren[i + 1])
                                && GetOffsetTop(InternalChildren[i]) == GetOffsetTop(InternalChildren[i + 1]))
                                {
                                    child.Arrange(new Rect(new Point(0, 0), new Size(0, 0)));
                                }
                                else
                                {
                                    if (z == 0 || z == Double.NaN)
                                    {
                                        child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                                    }
                                    else
                                    {
                                        child.Arrange(new Rect(new Point(x, y), new Size(z + child.DesiredSize.Width, z + child.DesiredSize.Height)));
                                    }
                                }
                        }

                    }
                    
                }
                return arrangeSize; // Returns the final Arrange size
                
            }

            // ********* OffsetLeft Property *********

            public static readonly DependencyProperty OffsetLeftProperty
                = DependencyProperty.RegisterAttached("OffsetLeft", typeof(double), typeof(OffsetPanel), new FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsParentArrange));


            public static double GetOffsetLeft(DependencyObject d)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                return (double)d.GetValue(OffsetLeftProperty);
            }

            public static void SetOffsetLeft(DependencyObject d, double length)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                d.SetValue(OffsetLeftProperty, length);
            }

            // ********* OffsetTop Property *********

            public static readonly DependencyProperty OffsetTopProperty
                = DependencyProperty.RegisterAttached("OffsetTop", typeof(double), typeof(OffsetPanel), new FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsParentArrange));

            public static double GetOffsetTop(DependencyObject d)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                return (double)d.GetValue(OffsetTopProperty);
            }

            public static void SetOffsetTop(DependencyObject d, double length)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                d.SetValue(OffsetTopProperty, length);
            }

            // ********* InflateSize Property *********

            public static readonly DependencyProperty InflateSizeProperty
                = DependencyProperty.RegisterAttached("InflateSize", typeof(double), typeof(OffsetPanel), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentArrange));

            public static double GetInflateSize(DependencyObject d)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                return (double)d.GetValue(InflateSizeProperty);
            }

            public static void SetInflateSize(DependencyObject d, double length)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                d.SetValue(InflateSizeProperty, length);
            }

            // ********* ShareCoordinates Property *********

            public static readonly DependencyProperty ShareCoordinatesProperty
                = DependencyProperty.RegisterAttached("ShareCoordinates", typeof(Boolean), typeof(OffsetPanel));

            public static Boolean GetShareCoordinates(DependencyObject d)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                return (bool)d.GetValue(ShareCoordinatesProperty);
            }

            public static void SetShareCoordinates(DependencyObject d, bool Boolean)
            {
                if (d == null) { throw new ArgumentNullException("d"); }
                d.SetValue(ShareCoordinatesProperty, Boolean);
            }

        }
    }

	// Run the application
	
    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main()
        {
            MyApp app = new MyApp();
            app.Run();
        }
    }
}
