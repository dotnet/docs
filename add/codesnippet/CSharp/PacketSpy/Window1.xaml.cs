using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Windows.Input;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace PacketSpy

{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        Rect constrainingRect;
        

        public Window1()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
            inkCanvas1.DefaultDrawingAttributes.IgnorePressure = false;
            inkCanvas1.DefaultDrawingAttributes.Height = 5;
            inkCanvas1.DefaultDrawingAttributes.Width = 5;
            inkCanvas1.StylusDown += new StylusDownEventHandler(inkCanvas1_StylusDown);
            inkCanvas1.StylusMove += new StylusEventHandler(inkCanvas1_StylusMove);
            inkCanvas1.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(inkCanvas1_MouseLeftButtonDown);
            

            inkCanvas1.DefaultStylusPointDescription = new StylusPointDescription(
                new StylusPointPropertyInfo[] {
                    new StylusPointPropertyInfo(StylusPointProperties.X),
                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure)});

            constrainingRect = new Rect(100, 100, 200, 200);

            this.KeyDown += new KeyEventHandler(Window1_KeyDown);

            //DrawRect();
            StylusPointConstructor();

            StylusPointCollectionSnippets();
            DescriptionSnippets();
            ClonePoints();
            StylusPropertySnippets();
            
            //CompareDescriptions();
            
            //MessageBox.Show(StylusPoint.MinXYValue.ToString() + ", " +
            //    StylusPoint.MaxXYValue.ToString());
        }

        void Window1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.T)
            {
                GetTabletStylusPointProperties();
            }
        }

        // <Snippet21>
        void inkCanvas1_StylusMove(object sender, StylusEventArgs e)
        {
            StylusPointCollection points = e.GetStylusPoints(inkCanvas1);
            StylusPointDescription description = points.Description;
            StringWriter normalPressureInfo = new StringWriter();

            if (description.HasProperty(StylusPointProperties.NormalPressure))
            {
                StylusPointPropertyInfo propertyInfo = 
                    description.GetPropertyInfo(StylusPointProperties.NormalPressure);

                normalPressureInfo.WriteLine("  Guid = {0}", propertyInfo.Id.ToString());
                normalPressureInfo.Write("  Min = {0}", propertyInfo.Minimum.ToString());
                normalPressureInfo.Write("  Max = {0}", propertyInfo.Maximum.ToString());
                normalPressureInfo.Write("  Unit = {0}", propertyInfo.Unit.ToString());
                normalPressureInfo.WriteLine("  Res = {0}", propertyInfo.Resolution.ToString());
            }
        }
        // </Snippet21>

        void inkCanvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point firstPoint = e.GetPosition(inkCanvas1);

            Ellipse circle = new Ellipse();
            circle.Width = 10;
            circle.Height = 10;
            circle.Fill = Brushes.Red;
            InkCanvas.SetTop(circle, firstPoint.Y - 5);
            InkCanvas.SetLeft(circle, firstPoint.X - 5);
            inkCanvas1.Children.Add(circle);

        }

        //<Snippet13>
        void inkCanvas1_StylusDown(object sender, StylusDownEventArgs e)
        {
            StylusPointCollection points = e.GetStylusPoints(inkCanvas1);
            Point firstPoint = (Point)points[0];

            Ellipse circle = new Ellipse();
            circle.Width = 5;
            circle.Height = 5;
            circle.Fill = Brushes.Red;
            InkCanvas.SetTop(circle, firstPoint.Y);
            InkCanvas.SetLeft(circle, firstPoint.X);
            inkCanvas1.Children.Add(circle);

        }
        //</Snippet13>

        void ValidateMinMaxX(StylusPoint point)
        {
            double x = 1000;

            //<Snippet14>
            if (x < StylusPoint.MinXY)
            {
                x = StylusPoint.MinXY;
            }
            else if (x > StylusPoint.MaxXY)
            {
                x = StylusPoint.MaxXY;
            }

            point.X = x;
            //</Snippet14>
        }


        // **save this snippet!!!**
        //<Snippet15>
        void inkCanvas1_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            this.Title = e.SystemGesture.ToString();
            switch (e.SystemGesture)
            {
                case SystemGesture.RightTap:
                    // Do something.
                    break;

                case SystemGesture.Tap:
                    // Do something else.
                    break;
            }
        }
        //</Snippet15>

        void GetTabletStylusPointProperties()
        {
            //<Snippet27>
            TabletDevice currentTablet = Tablet.CurrentTabletDevice;
            ReadOnlyCollection<StylusPointProperty> supportedProperties = 
                currentTablet.SupportedStylusPointProperties;

            StringWriter properties = new StringWriter();

            foreach (StylusPointProperty property in supportedProperties)
            {
                properties.WriteLine(property.ToString());
            }

            MessageBox.Show(properties.ToString());
            //</Snippet27>
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, EventArgs e) {}

        // Sample event handler:  
        //private void SaveStrokes_Click(object sender, RoutedEventArgs e) 
        //{
        //}

        private void DrawRect()
        {
            DrawingVisual myRectVisual;

            myRectVisual = new DrawingVisual();
            DrawingContext myDrawingContext = myRectVisual.RenderOpen();

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            Pen myPen = new Pen(Brushes.Red, 1);

            myDrawingContext.DrawRectangle(null, myPen, constrainingRect);

            // Important: Close the DrawingContext.
            myDrawingContext.Close();

            //VisualCollection collection = VisualOperations.GetChildren(inkCanvas1);

            //collection.Add(myRectVisual);

        }

        private void StylusMoveEventHandler(object sender, StylusEventArgs e)
        {

            StylusPointCollection points = e.GetStylusPoints(inkCanvas1);
            WriteStylusPointValues(points);
            WriteDescriptionInfo(points);
        }

        private void StylusEventHandler(object sender, StylusEventArgs e)
        {

        }

        void GetDescriptionFromStylusDevice()
        {    
            //<Snippet26>
            StylusDevice currentStylus = Stylus.CurrentStylusDevice;
            StylusPointDescription description1 =
                  new StylusPointDescription(new StylusPointPropertyInfo[]
                                {
                                    new StylusPointPropertyInfo(StylusPointProperties.X),
                                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                                    new StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.BarrelButton)
                                });

            StylusPointDescription description2 = currentStylus.GetStylusPoints(inkCanvas1).Description;

            StylusPointDescription description3 = 
                StylusPointDescription.GetCommonDescription(description1, description2);

            StylusPointCollection points = currentStylus.GetStylusPoints(inkCanvas1, description3);
            //</Snippet26>
        }

        //<Snippet2>
        private void WriteDescriptionInfo(StylusPointCollection points)
        {
            StylusPointDescription pointsDescription = points.Description;
            ReadOnlyCollection<StylusPointPropertyInfo> properties = 
                pointsDescription.GetStylusPointProperties();

            StringWriter descriptionStringWriter = new StringWriter();
            descriptionStringWriter.Write("Property Count:{0}", pointsDescription.PropertyCount.ToString());
            
            foreach (StylusPointPropertyInfo property in properties)
            {
                // GetStylusPointPropertyName is defined below and returns the
                // name of the property.
                descriptionStringWriter.Write("name = {0}", GetStylusPointPropertyName(property).ToString());
                descriptionStringWriter.WriteLine("  Guid = {0}", property.Id.ToString());
                descriptionStringWriter.Write("  IsButton = {0}", property.IsButton.ToString());
                descriptionStringWriter.Write("  Min = {0}", property.Minimum.ToString());
                descriptionStringWriter.Write("  Max = {0}", property.Maximum.ToString());
                descriptionStringWriter.Write("  Unit = {0}", property.Unit.ToString());
                descriptionStringWriter.WriteLine("  Res {0}", property.Resolution.ToString());
            }

            descriptionOutput.Text = descriptionStringWriter.ToString();
        }
        //</Snippet2>

        //<Snippet3>
        private void WriteStylusPointValues(StylusPointCollection points)
        {
            StylusPointDescription pointsDescription = points.Description;

            ReadOnlyCollection<StylusPointPropertyInfo> properties = 
                pointsDescription.GetStylusPointProperties();
            
            // Write the name and and value of each property in
            // every stylus point.
            StringWriter packetWriter = new StringWriter();
            packetWriter.WriteLine("{0} stylus points", points.Count.ToString());
            foreach (StylusPoint stylusPoint in points)
            {
                packetWriter.WriteLine("Stylus Point info");
                packetWriter.WriteLine("X: {0}", stylusPoint.X.ToString());
                packetWriter.WriteLine("Y: {0}", stylusPoint.Y.ToString());
                packetWriter.WriteLine("Pressure: {0}", stylusPoint.PressureFactor.ToString());

                // Get the property name and value for each StylusPoint.
                // Note that this loop reports the X, Y, and pressure values differantly than 
                // getting their values above.
                for (int i = 0; i < pointsDescription.PropertyCount; ++i)
                {
                    StylusPointProperty currentProperty = properties[i];

                    // GetStylusPointPropertyName is defined below and returns the
                    // name of the property.
                    packetWriter.Write("{0}: ", GetStylusPointPropertyName(currentProperty));
                    packetWriter.WriteLine(stylusPoint.GetPropertyValue(currentProperty).ToString());
                }
                packetWriter.WriteLine();

            }

            packetOutput.Text = packetWriter.ToString();
        }
        //</Snippet3>

        //<Snippet4>
        // Use reflection to get the name of currentProperty.
        private string GetStylusPointPropertyName(StylusPointProperty currentProperty)
        {
            Guid guid = currentProperty.Id;

            // Iterate through the StylusPointProperties to find the StylusPointProperty
            // that matches currentProperty, then return the name.
            foreach (FieldInfo theFieldInfo
                in typeof(StylusPointProperties).GetFields())
            {
                StylusPointProperty property = (StylusPointProperty) theFieldInfo.GetValue(currentProperty);
                if (property.Id == guid)
                {
                    return theFieldInfo.Name;
                }
            }
            return "Not found";
        }
        //</Snippet4>

        void StylusPointConstructor()
        {
            //<snippet5>
            StylusPointDescription newDescription =
                  new StylusPointDescription(new StylusPointPropertyInfo[]
                                {
                                    new StylusPointPropertyInfo(StylusPointProperties.X),
                                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                                    new StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.BarrelButton)
                                });


            int[] propertyValues = { 1800, 1000, 1 };

            StylusPoint newStylusPoint = new StylusPoint(100, 100, .5f, newDescription, propertyValues);
            //</snippet5>

            //<Snippet16>
            StylusPointPropertyInfo XTiltPropertyInfo = 
                new StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation,
                                   0, 3600, StylusPointPropertyUnit.Degrees, 10f);
            //</Snippet16>

            StylusPoint point = new StylusPoint();
            //<Snippet11>
            if (point.HasProperty(StylusPointProperties.PitchRotation))
            {
                int pitchRotation = point.GetPropertyValue(StylusPointProperties.PitchRotation);
            }
            //</Snippet11>

            //<Snippet12>
            if (point.HasProperty(StylusPointProperties.PitchRotation))
            {
                point.SetPropertyValue(StylusPointProperties.PitchRotation, 1000);
            }
            //</Snippet12>
        }

        // All equality tests pass
        void TestStylusPointsEquality()
        {
            //<Snippet6>
            StylusPoint point1 = new StylusPoint();
            StylusPoint point2 = new StylusPoint();

            point1.X = 150;
            point1.Y = 400;
            point1.PressureFactor = 0.45f;

            point2.X = 150;
            point2.Y = 400;
            point2.PressureFactor = 0.45f;
            //</Snippet6>

            //<Snippet7>
            if (point2.Equals(point1))
            {
                MessageBox.Show("The two StylusPoint objects are equal.");
            }
            else
            {
                MessageBox.Show("The two StylusPoint objects are not equal.");
            }
            //</Snippet7>

            //<Snippet8>
            if (StylusPoint.Equals(point1, point2))
            {
                MessageBox.Show("The two StylusPoint objects are equal.");
            }
            else
            {
                MessageBox.Show("The two StylusPoint objects are not equal.");
            }
            //</Snippet8>

            //<Snippet9>
            if (point1 == point2)
            {
                MessageBox.Show("The two StylusPoint objects are equal.");
            }
            else
            {
                MessageBox.Show("The two StylusPoint objects are not equal.");
            }
            //</Snippet9>

            //<Snippet10>
            if (point1 != point2)
            {
                MessageBox.Show("The two StylusPoint objects are not equal.");
            }
            else
            {
                MessageBox.Show("The two StylusPoint objects are equal.");
            }
            //</Snippet10>


        }

        //public void AddStroke(System.Windows.Ink.Stroke stroke)
        //{

        //    int[] packets = stroke.StylusPoints.ToHiMetricArray();
        //    Guid[] packetDescription = stroke.StylusPoints.Description.GetStylusPointPropertyIds();

        //    _inkAnalyzerBase.AddStroke(_strokeId++, packets, packetDescription);

        //}

        void StylusPointCollectionSnippets()
        {
            //MessageBox.Show("hi");
            //<Snippet20>
            StylusPointCollection points = new StylusPointCollection(new Point[]
                {
                    new Point(100, 100),
                    new Point(100, 200),
                    new Point(200, 250),
                    new Point(300, 300)
                });
            //</Snippet20>
            //points.RemoveAt(0);
            //points.RemoveAt(0);
            StylusPoint point = new StylusPoint(400, 300);
            //points.Insert(3, point);

            //points.Insert(2, point);


        }

        void StylusPointCollectionConstructor()
        {
            //<Snippet28>
            StylusPoint stylusPoint1 =  new StylusPoint(100, 100, .5f);
            StylusPoint stylusPoint2 = new StylusPoint(200, 200, .35f);

            StylusPointCollection points = new StylusPointCollection(
                new StylusPoint[] { stylusPoint1, stylusPoint2 });
            //</Snippet28>
        }

        void DescriptionSnippets()
        {
            //<Snippet17>
            StylusPointDescription description1 =
                  new StylusPointDescription(new StylusPointPropertyInfo[]
                                {
                                    new StylusPointPropertyInfo(StylusPointProperties.X),
                                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                                    new StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.BarrelButton)
                                });

            // Create a StylusPointCollection that uses description1 as its
            // StylusPointDescription.
            StylusPointCollection points = new StylusPointCollection(description1);

            StylusPointDescription description2 =   
                  new StylusPointDescription(new StylusPointPropertyInfo[]
                                {
                                    new StylusPointPropertyInfo(StylusPointProperties.X),
                                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                                    new StylusPointPropertyInfo(StylusPointProperties.ButtonPressure),
                                    new StylusPointPropertyInfo(StylusPointProperties.BarrelButton)
                                });

            // Find the common StylusPointDescription between description1
            // and description2.  Get a StylusPointCollection that uses the
            // common StylusPointDescription.
            StylusPointDescription common =
                StylusPointDescription.GetCommonDescription(description1, description2);
            
            StylusPointCollection points2 = points.Reformat(common);
            //</Snippet17>

            //Add two styluspoints with different descriptions.  Throws an exception.
            //StylusPoint stylusPoint1 = new StylusPoint(100, 100, .5f, description1, new int[]{0, 0, 1});
            //StylusPoint stylusPoint2 = new StylusPoint(200, 200, .35f, description2, new int[] {0, 1 });

            //StylusPointCollection points3 = new StylusPointCollection(
            //    new StylusPoint[] { stylusPoint1, stylusPoint2 });

            //StylusPointCollection points4 = new StylusPointCollection(description1);
            //StylusPoint stylusPoint1 = new StylusPoint(100, 100, .5f);
            //points4.Add(stylusPoint1);
            //MessageBox.Show(points2.Count.ToString());
        }

        void ClonePoints()
        {
            //<Snippet18>
            Point[] rawPoints = new Point[]
                {
                    new Point(100, 100),
                    new Point(100, 200),
                    new Point(200, 250),
                    new Point(300, 300)
                };

            StylusPointCollection points1 = new StylusPointCollection(rawPoints);
            
            // Create a copy of points1 and change the second StylusPoint.
            StylusPointCollection points2 = points1.Clone();
            points2[1] = new StylusPoint(200, 100);

            // Create a stroke from each StylusPointCollection and add them to
            // inkCanvas1. Note that changing a StylusPoint in point2 did not
            // affect points1.
            Stroke stroke1 = new Stroke(points1);
            inkCanvas1.Strokes.Add(stroke1);

            Stroke stroke2 = new Stroke(points2);
            stroke2.DrawingAttributes.Color = Colors.Red;
            inkCanvas1.Strokes.Add(stroke2);
            //</Snippet18>

            
        }

        void CompareDescriptions()
        {
            //<Snippet22>
            StylusPointDescription description1 =
                  new StylusPointDescription(new StylusPointPropertyInfo[]
                                {
                                    new StylusPointPropertyInfo(StylusPointProperties.X),
                                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                                    new StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation),
                                    new StylusPointPropertyInfo(StylusPointProperties.BarrelButton)
                                });

            StylusPointDescription description2 =
                  new StylusPointDescription(new StylusPointPropertyInfo[]
                                {
                                    new StylusPointPropertyInfo(StylusPointProperties.X),
                                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                                    new StylusPointPropertyInfo(StylusPointProperties.BarrelButton)
                                });
            //</Snippet22>

            //<Snippet23>
            if (StylusPointDescription.AreCompatible(description1, description2))
            {
                MessageBox.Show("The two descriptions are compatible.");
            }
            else
            {
                MessageBox.Show("The two descriptions are not compatible.");
            }
            //</Snippet23>

            //<Snippet24>
            if (description2.IsSubsetOf(description1))
            {
                MessageBox.Show("description2 is a subset of description1.");
            }
            else
            {
                MessageBox.Show("description2 is not a subset of description1.");
            }
            //</Snippet24>

        }

        void points_Changed(object sender, EventArgs e)
        {
            MessageBox.Show("The SylusPointCollection changed");
        }

        // The OnStylusDown method is to demonstrate how to create
        // a StylusPointCollection to collect stylus points in a custom control.
        // Nothing happens with stylusPoints, it's dead end code.
        //<Snippet19>
        StylusPointCollection stylusPoints;

        protected override void OnStylusDown(StylusDownEventArgs e)
        {
            base.OnStylusDown(e);

            StylusPointCollection eventPoints = e.GetStylusPoints(this);

            // Create a new StylusPointCollection using the StylusPointDescription
            // from the stylus points in the StylusDownEventArgs.
            stylusPoints = new StylusPointCollection(eventPoints.Description, eventPoints.Count);
            stylusPoints.Add(eventPoints);

        }
        //</Snippet19>

        void StylusPropertySnippets()
        {
            StylusPointPropertyInfo newProperty = new StylusPointPropertyInfo(StylusPointProperties.TwistOrientation);

            //<Snippet25>
            Guid guid = new Guid("12345678-1234-1234-1234-123456789012");
            StylusPointProperty newlyDefinedProperty = new StylusPointProperty(guid, false);
            //</Snippet25>
        }

        void StylusPropertyInfoSnippets()
        {
            //Guid guid = new Guid("12345678-1234-1234-1234-123456789012");
            //StylusPointPropertyInfo newlyDefinedProperty = new StylusPointPropertyInfo(guid, false);
        }
}
}