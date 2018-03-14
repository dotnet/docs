using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Input.StylusPlugIns;

namespace StrokeSnippets_CS
{

    // This control initializes with strokes already on it and allows the
    // user to erase the strokes with the stylus.

    // Need this in MyStroke
    [Guid("03457307-3475-3450-3035-640435034540")]
    public class MyBorder : Border
    {
        public enum sMode
        {
            add,
            clip,
            remove,
            surround
        }

        sMode _state;

        public sMode state
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        bool _shadow;

        public bool shadow
        {
            get
            {
                return _shadow;
            }
            set
            {
                _shadow = value;
            }
        }

        bool fitToCurve = false;

        public bool FitToCurve
        {
            get
            {
                return fitToCurve;

            }

            set
            {
                fitToCurve = value;
                
            }

        }

        bool gotFirstStroke;

        // To save strokes in a file
        private StreamWriter myFile;
        private static string STROKE_FILE = "c:\\temp\\stroke";

        Stroke myStroke, shadowStroke;
        MyStroke myNewStroke;
        StrokeCollection myStrokeCollection;
        //StylusPackets[] myStylusPacketsArray;
        StylusPointCollection stylusPoints;
        IncrementalHitTester myIncrementalHitTester;
        InkPresenter myInkPresenter;
        DynamicRenderer renderer;

        DrawingAttributes inkAttributes;

        // The base-64 encoded string that contains ink data 
        // in ink serialized format (ISF).
        string strokesString =
            @"base64:AOoFAxBIEEVqGwIAWf9GahsCAFn/GRQyCACAEAIAAABCMwgAgA"
            + "wCAAAAQhWrqtNBq6rTQaVh0MSr+ivFHyEVVFVVVVV1OkBUVVVVVXU6QJ7"
            + "0SZ80DJrAVFVVVVV/pcAKU3yC/gEb+AX/k5Z8PwWBO5KktgJSUAAKjzyC"
            + "wBZYLEoCJLd+Cbti873JlTUvn158doCC/gKb+ApwAJslSywE2ALAAWPPI"
            + "FhKWBKWAKAmwJVglAKACiMjgv3d+8Xi+fHWM2WC0zcm89+NSoL+A5P4Dl"
            + "uNlhFIqpLKAAoaF4L+AhP4CFAWAWCggv4Dc/gNty2yy5SrlKAKIhyC/gI"
            + "b+Ai+JZc2XZOyb46vLQCC/gOL+A5YDNlWFjN3CwAKQFeC/gOr+A7VhUFZ"
            + "KCsS2WTc2SyhKuWVLR3ly2LAXx574ssUgv4Dm/gOcCwEEpUTYSixUsuWy"
            + "gVZ79AQsWGyWUAKLCiC/gQT+BA9SWbllDfGqy3Lcu+OmfH8EIL+BDv4EP"
            + "XLKSpY3lVFhZuVZvKACkFggv4F2/gXlKLFuCVKTcsqUlkoRKBmk8zfFll"
            + "S2ySlACwAgv4Ds/gO+WWWWLBLFllllSksAoSkWG1kSbFu5AoAAAo/YoL+"
            + "Biv4GJJU+P4qSalUBKWdkBYCbm+Nliyk1CVKgCxYNYqC/gQb+BBwO8ABY"
            + "olDz4gAEzaw2AVCUKAsWCooCiAegv4Hw/gfEJe8zUoSgLCC/gNT+A0xM7"
            + "Gdmdliay2VaAo0PoL+B7v4Hx5Yq3lc2xZsseeC3N8aDXjUpWW4UIL+A5P"
            + "4DnhYqAIWFkqpcrLZuJuWqSyxVAovNoL+CJP4IjnlkDvHeSbSVd9FqFlI"
            + "oWAAgv4Dk/gOVc7gbmdyZ1LajFFJmlRKsoAKVXmC/go7+CjdRvredypaK"
            + "myLC7ytZQqFiyWbikAEvfg2pSVKS7liSwWJNsrbi4CC/gQD+A/9M2ACxU"
            + "qKjcVuXKiosCWWKQSyhvKRUUWULCwEmyyu4gA=";

        public MyBorder()
        {
            gotFirstStroke = false;

            // Set the default state if no button is clicked
            state = sMode.add;

            myInkPresenter = new InkPresenter();

            Child = myInkPresenter;

            inkAttributes = new DrawingAttributes();
            inkAttributes.Color = Colors.Green;
            inkAttributes.Width = 5;
            inkAttributes.Height = 5;

            renderer = new DynamicRenderer();
            renderer.DrawingAttributes = inkAttributes;
            this.StylusPlugIns.Add(renderer);

            myInkPresenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes);

            StrokeConstructorSample();

        }

        static MyBorder()
        {
            // Allow ink to be drawn only within the bounds of the control.
            Type owner = typeof(MyBorder);
            ClipToBoundsProperty.OverrideMetadata(owner,
                new FrameworkPropertyMetadata(true));

        }

       
        // Prepare to collect stylus packets. Get the 
        // IncrementalHitTester from the InkPresenter's 
        // StrokeCollection and subscribe to its StrokeHitChanged event.
        protected override void OnStylusDown(StylusDownEventArgs e)
        {
            base.OnStylusDown(e);

            switch (state)
            {
                case sMode.add:
                    StylusPointCollection eventPoints = e.GetStylusPoints(this);
                    stylusPoints = new StylusPointCollection(eventPoints.Description);
                    break;
                case sMode.surround:
                    // Use StrokeChanged event handler to detect stroke encirclement when using percentage
                    myIncrementalHitTester = myInkPresenter.Strokes.GetIncrementalLassoHitTester(50);

                    ((IncrementalLassoHitTester) myIncrementalHitTester).SelectionChanged +=
                        new LassoSelectionChangedEventHandler(myIHT_StrokeHitChanged);
                       
                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(this));
                    break;
                default:
                    // Otherwise we detect when the IHT hits the existing strokes
                    // Use StrokeIntersectionChanged event handler to detect stroke hit when using stylus
                    EllipseStylusShape eraserTip = new EllipseStylusShape(3, 3, 0);

                    myIncrementalHitTester = myInkPresenter.Strokes.GetIncrementalStrokeHitTester(eraserTip);

                    ((IncrementalStrokeHitTester)myIncrementalHitTester).StrokeHit += 
                        new StrokeHitEventHandler(myIHT_StrokeIntersectionChanged);

                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(this));
                    break;
            }

            e.Handled = true;
        }

        // Collect the StylusPackets as the stylus moves.
        protected override void OnStylusMove(StylusEventArgs e)
        {
            switch (state)
            {
                case sMode.add:
                    stylusPoints.Add(e.GetStylusPoints(this));
                    break;
                default:
                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(this));
                    break;
            }

            e.Handled = true;
        }

        // Unsubscribe from the StrokeHitChanged event when the
        // user lifts the stylus.
        protected override void OnStylusUp(StylusEventArgs e)
        {
            switch(state)
            {
                case sMode.add:
                    // Add the stylus points to a StylusPointCollection 
                    // in the StylusUp event. e is a StylusEventArgs object.
                    stylusPoints.Add(e.GetStylusPoints(this));

                    // Create new stroke from the collected stylus points.
                    //myNewStroke = new MyStroke(stylusPoints, inkAttributes.Clone());
                    myNewStroke = new CustomRenderedStroke(stylusPoints, inkAttributes.Clone());

                    // <Snippet8>
                    // Handle DrawingAtributesChanged event on stroke
                    myNewStroke.DrawingAttributesChanged += new PropertyDataChangedEventHandler(myNewStroke_DrawingAttributesChanged);
                    // </Snippet8>

                    // <Snippet9>
                    // Handle DrawingAttributesReplaced event on stroke
                    myNewStroke.DrawingAttributesReplaced += new DrawingAttributesReplacedEventHandler(myNewStroke_DrawingAttributesReplaced);
                    // </Snippet9>

                    myNewStroke.StylusPointsChanged += new EventHandler(myNewStroke_StylusPointsChanged);
                    myNewStroke.StylusPointsReplaced += new StylusPointsReplacedEventHandler(myNewStroke_StylusPointsReplaced);
                    myNewStroke.StylusPoints.Changed += new EventHandler(StylusPoints_Changed);

                    //myNewStroke.MoveStylusPoints();
                    // <Snippet20>
                    // Handle PropertyDataChanged event on stroke
                    myNewStroke.PropertyDataChanged += new PropertyDataChangedEventHandler(myNewStroke_PropertyDataChanged);
                    // </Snippet20>

                    // <Snippet21>
                    // Get packets from stroke
                    //StylusPackets myStylusPackets = myNewStroke.StylusPackets;
                    // </Snippet21>

                    // This should fire a DrawingAttributesChanged event

                    // <Snippet7>
                    // Make the new stroke green.
                    myNewStroke.DrawingAttributes.Color = Colors.Green;
                    // </Snippet7>

                    // Add stroke to InkPresenter
                    //myNewStroke.DrawingAttributes = inkAttributes.Clone();
                    myNewStroke.DrawingAttributes.FitToCurve = fitToCurve;

                    myInkPresenter.Strokes.Add(myNewStroke);

                    CompareStrokePoints(myNewStroke);

                    // Add pink shadow if requested
                    if(shadow)
                    {
                        shadowStroke = myNewStroke.Clone();
                        shadowStroke.Transform(new Matrix(1, 0, 0, 1, 2, 0), false);
                        shadowStroke.DrawingAttributes.Color = Colors.Pink;
                        myInkPresenter.Strokes.Add(shadowStroke);
                    }

                    break;
                case sMode.surround:
                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(this));

                    // Disable SelectionChanged event handler when using encirclement
                    ((IncrementalLassoHitTester)myIncrementalHitTester).SelectionChanged -=
                            new LassoSelectionChangedEventHandler(myIHT_StrokeHitChanged);
                    break;
                default:
                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(this));

                    // Disable StrokeHit event handler when using stylus hits
                    ((IncrementalStrokeHitTester)myIncrementalHitTester).StrokeHit -=
                                 new StrokeHitEventHandler(myIHT_StrokeIntersectionChanged);
                    break;
            }
            
            e.Handled = true;
        }

        //<Snippet27>
        void StylusPoints_Changed(object sender, EventArgs e)
        {
            MessageBox.Show("stylus points changed");
        }
        //</Snippet27>

        //<Snippet28>
        void myNewStroke_StylusPointsChanged(object sender, EventArgs e)
        {
            MessageBox.Show("stylus points changed");
        }
        //</Snippet28>

        //<Snippet29>
        void myNewStroke_StylusPointsReplaced(object sender, StylusPointsReplacedEventArgs e)
        {
           
            MessageBox.Show("stylus points replaced");
        }
        //</Snippet29>

        void CompareStrokePoints(Stroke aStroke)
        {

        }

        void myNewStroke_PropertyDataChanged(object sender, PropertyDataChangedEventArgs e)
        { }

        void myNewStroke_DrawingAttributesReplaced(object sender, DrawingAttributesReplacedEventArgs e)
        { }

        void myNewStroke_DrawingAttributesChanged(object sender, PropertyDataChangedEventArgs e)
        { }

        // When the stylus clips a stroke,
        // delete that stroke.
        // When the stylus erases a stoke,
        // replace the stroke with the strokes returned by
        // the Stroke.Erase method.
        void myIHT_StrokeIntersectionChanged(object sender, StrokeHitEventArgs e)
        {
            Stroke thisStroke = e.HitStroke;

            // <Snippet11>
            Rect myRect = thisStroke.GetBounds();
            // </Snippet11>

            if (state == sMode.clip)
            {
                // ***Stroke.Clip***
                // <Snippet4>
                // Get the intersections when the stroke is clipped.
                // e is a StrokeIntersectionChangedEventArgs object in the
                // StrokeIntersectionChanged event handler.
                StrokeCollection clipResult = e.GetPointEraseResults();

                StrokeCollection strokesToReplace = new StrokeCollection();

                strokesToReplace.Add(thisStroke);

                // Replace the old stroke with the new one.
                if (clipResult.Count > 0)
                {
                    myInkPresenter.Strokes.Replace(strokesToReplace, clipResult);
                }
                else
                {
                    myInkPresenter.Strokes.Remove(strokesToReplace);
                }
                // </Snippet4>

                if (!gotFirstStroke)
                {
                    // <Snippet3>
                    // Create a guid for the date/timestamp.
                    Guid dtGuid = new Guid("03457307-3475-3450-3035-640435034540");

                    DateTime now = DateTime.Now;

                    // Check whether the property is already saved
                    if (thisStroke.ContainsPropertyData(dtGuid))
                    {
                        // Check whether the existing property matches the current date/timestamp
                        DateTime oldDT = (DateTime)thisStroke.GetPropertyData(dtGuid);

                        if (oldDT != now)
                        {
                            // Update the current date and time
                            thisStroke.AddPropertyData(dtGuid, now);
                        }
                    }
                    // </Snippet3>

                    // <Snippet30>
                    // Create a guid for the date/timestamp.
                    Guid dateTimeGuid = new Guid("03457307-3475-3450-3035-045430534046");

                    DateTime current = DateTime.Now;

                    // Check whether the property is already saved
                    if (thisStroke.ContainsPropertyData(dateTimeGuid))
                    {
                        DateTime oldDateTime = (DateTime)thisStroke.GetPropertyData(dateTimeGuid);

                        // Check whether the existing property matches the current date/timestamp
                        if (!(oldDateTime == current))
                        {
                            // Delete the custom property
                            thisStroke.RemovePropertyData(dateTimeGuid);
                        }
                    }
                    // </Snippet30>                    

                    // <Snippet12>
                    // Save the stroke as an array of Point objects
                    //Point[] myPoints = thisStroke.GetRenderingPoints();
                    // </Snippet12>

                    // Port to VB if I ever get this working!
                    // See if we can figure out which stroke point(s) got hit
                    //StrokeIntersection[] myStrokeIntersections = e.GetHitStrokeIntersections();

                    //Point[] myStrokeIntersectionPoints = new Point[myStrokeIntersections.Length];

                    //int p = 0;

                    //for (int k = 0; k < myStrokeIntersections.Length; k++)
                    //{
                    //    StrokeIntersection s = myStrokeIntersections[k];

                    //    if (s.HitBegin != StrokeIntersection.BeforeFirst && s.HitEnd != StrokeIntersection.        AfterLast)
                    //    {
                    //        // Get stroke point that is closest to average between HitBegin and HitEnd:
                    //        double x = s.HitBegin;
                    //        double y = s.HitEnd;

                    //        double midPoint = (x + y) / 2;

                    //        int middlePoint = (int)midPoint;

                    //        // Now add that Point from the existing stroke points
                    //        myStrokeIntersectionPoints[p] = myPoints[middlePoint];

                    //        p++;
                    //    }

                    //}

                    // Get DrawingContext for InkPresenter
                    //VisualCollection myVisuals = VisualOperations.GetChildren(myInkPresenter);

                    //DrawingVisual myVisual = new DrawingVisual();
                    //DrawingContext myContext = myVisual.RenderOpen();

                    //// Draw midpoints of stroke intersections a little green circles
                    //for (int j = 0; j < myStrokeIntersectionPoints.Length; j++)
                    //{
                    //    // Draw green circles around each point
                    //    myContext.DrawGeometry(Brushes.Green,
                    //        new Pen(Brushes.Green, 1.0),
                    //        new EllipseGeometry(myStrokeIntersectionPoints[j], 4.0, 4.0));
                    //}

                    //myContext.Close();
                    //myVisuals.Add(myVisual);


                    // Do I have to do something here to display the revised InkPresenter?


                    // Open the file to hold strokes
                    // if the file already exists, overwrite it
                    //myFile = new StreamWriter(File.Open(STROKE_FILE, FileMode.Create));

                    //Point myPoint;

                    //int xVal, yVal;

                    //for (int i = 0; i < myPoints.Length; i++)
                    //{
                    //    myPoint = myPoints[i];

                    //    xVal = (int)myPoint.X;
                    //    yVal = (int)myPoint.Y;

                    //    // Save the point to a file
                    //    myFile.WriteLine(xVal.ToString() + " " + yVal.ToString());
                    //}

                    //myFile.Flush();
                    //myFile.Close();
                    
                    //gotFirstStroke = true;
                }
            }
            else
            {
                // ***erase**
                // <Snippet10>
                // Remove the stokee that is hit.
                myInkPresenter.Strokes.Remove(e.HitStroke);
                // </Snippet10> 
            }            
        }

        // When the stylus encircles a stroke,
        // erase that stroke.
        void myIHT_StrokeHitChanged(object sender, LassoSelectionChangedEventArgs e)
        {

            foreach (MyStroke stroke in e.SelectedStrokes)
            {
                stroke.Selected = true;
                //stroke.DrawingAttributes.Color = Colors.Red;
            }

            foreach (MyStroke stroke in e.DeselectedStrokes)
            {
                stroke.Selected = false;
                //stroke.DrawingAttributes.Color = Colors.Green;
            }

            // Remove the encircled stroke.
            //if (eraseResult.Count > 0)
            //{
            //    myInkPresenter.Strokes.Remove(eraseResult);
            //}
        }

        public void ChangeDrawingMode(DrawingMode mode)
        {
            if (myInkPresenter.Strokes.Count == 0)
            {
                return;
            }

            if (!(myInkPresenter.Strokes[0] is CustomRenderedStroke))
            {
                return;
            }

            foreach (CustomRenderedStroke s in myInkPresenter.Strokes)
            {
                s.Mode = mode;
            }
        }

        private void StrokeConstructorSample()
        {

            // <Snippet2>
            DrawingAttributes drawingAttributes1 = new DrawingAttributes();
            drawingAttributes1.Color = Colors.Green;

            StylusPoint stylusPoint1 = new StylusPoint(100, 100);
            StylusPoint stylusPoint2 = new StylusPoint(100, 200);
            StylusPoint stylusPoint3 = new StylusPoint(200, 200);
            StylusPoint stylusPoint4 = new StylusPoint(200, 100);
            StylusPoint stylusPoint5 = new StylusPoint(100, 100);

            StylusPointCollection points = new StylusPointCollection(
                new StylusPoint[] { stylusPoint1, stylusPoint2, stylusPoint3, 
                                    stylusPoint4, stylusPoint5 });

            Stroke newStroke = new Stroke(points, drawingAttributes1);

            myInkPresenter.Strokes.Add(newStroke);
            // </Snippet2>

        }

        // <Snippet5>

        // <Snippet22>

        Stroke GetLittleRedStroke(Stroke theStroke)
        {
            // Copy the incoming stroke
            Stroke sCopy = theStroke.Clone();

            // Scale it by 50%
            Matrix xform = new Matrix();
            xform.Scale(0.5, 0.5);

            sCopy.Transform(xform, false);

            // Color it red
            sCopy.DrawingAttributes.Color = Colors.Red;

            // Return the new stroke
            return (sCopy);
        }
        // </Snippet22>
        
        // </Snippet5>
    }
}
