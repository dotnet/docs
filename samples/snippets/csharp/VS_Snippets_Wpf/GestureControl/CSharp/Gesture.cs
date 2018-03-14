//<Snippet1>
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Input.StylusPlugIns;

namespace GestureControl
{
    class RealTimeInkControl : Border
    {
        InkPresenter presenter;
        GestureRecognizer recognizer;
        DynamicRenderer renderer;
        StylusPointCollection stylusPoints;

        public RealTimeInkControl()
            : base()
        {
            recognizer = new GestureRecognizer();

            ClipToBoundsProperty.OverrideMetadata(typeof(RealTimeInkControl),
                new FrameworkPropertyMetadata(true));

            // Use an InkPresenter to display the strokes on the custom control.
            presenter = new InkPresenter();
            this.Child = presenter;

            renderer = new DynamicRenderer();
            this.StylusPlugIns.Add(renderer);
            presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes);
        }

        // Begin collecting stylus packets.
        protected override void OnStylusDown(StylusDownEventArgs e)
        {
            base.OnStylusDown(e);
            Stylus.Capture(this);

            StylusPointCollection eventPoints = e.GetStylusPoints(this);
            stylusPoints = new StylusPointCollection(eventPoints.Description);
            stylusPoints.Add(eventPoints);

        }

        // Collect the stylus packets as the stylus moves.
        protected override void OnStylusMove(StylusEventArgs e)
        {
            base.OnStylusMove(e);
            stylusPoints.Add(e.GetStylusPoints(this));
        }

        //<Snippet3>
        // Create a stroke from the packets and check if it is a gesture.
        protected override void OnStylusUp(StylusEventArgs e)
        {
            base.OnStylusUp(e);
            
            stylusPoints.Add(e.GetStylusPoints(this));
            Stroke stroke = new Stroke(stylusPoints);

            // If the stroke was a gesture, put the name of the gesture
            // in the title bar.  Otherwise, add the stroke to the control.
            if (recognizer.IsRecognizerAvailable)
            {
                StrokeCollection gestureStrokes = new StrokeCollection();
                gestureStrokes.Add(stroke);
                
                ReadOnlyCollection<GestureRecognitionResult> results =
                                recognizer.Recognize(gestureStrokes);

                if (results.Count > 0 &&
                    results[0].ApplicationGesture != ApplicationGesture.NoGesture &&
                    results[0].RecognitionConfidence == RecognitionConfidence.Strong)
                {
                    Application.Current.Windows[0].Title =
                        results[0].ApplicationGesture.ToString();
                }
                else
                {
                    presenter.Strokes.Add(stroke);
                    Application.Current.Windows[0].Title = "";
                }
            }
            else
            {
                Application.Current.Windows[0].Title = "Recognizer not available";
                presenter.Strokes.Add(stroke);
            }
            
            Stylus.Capture(null);
        }
        //</Snippet3>
        
        //</Snippet1>

        private void ConstructorSnippet()
        {
            //<Snippet4>
            ApplicationGesture[] gestures = {ApplicationGesture.Down,
                ApplicationGesture.Right, ApplicationGesture.ScratchOut};

            GestureRecognizer recognizer = new GestureRecognizer(gestures);
            //</Snippet4>
        }

        private void SetApplicationGestures()
        {
            //<Snippet5>
            ApplicationGesture[] gestures = {ApplicationGesture.Down,
                ApplicationGesture.Right, ApplicationGesture.ScratchOut};

            GestureRecognizer recognizer = new GestureRecognizer();

            recognizer.SetEnabledGestures(gestures);
            //</Snippet5>

            //<Snippet6>
            ReadOnlyCollection<ApplicationGesture> enableGestures = recognizer.GetEnabledGestures();
            //</Snippet6>
        }

        //<Snippet8>
        private bool InterpretScratchoutGesture(Stroke stroke)
        {
            // Attempt to instantiate a recognizer for scratchout gestures.
            ApplicationGesture[] gestures = {ApplicationGesture.ScratchOut};
            GestureRecognizer recognizer = new GestureRecognizer(gestures);

            if (!recognizer.IsRecognizerAvailable)
                return false;

            // Determine if the stroke was a scratchout gesture.
            StrokeCollection gestureStrokes = new StrokeCollection();
            gestureStrokes.Add(stroke);

            ReadOnlyCollection<GestureRecognitionResult> results = recognizer.Recognize(gestureStrokes);

            if (results.Count == 0)
                return false;

            // Results are returned sorted in order strongest-to-weakest; 
            // we need only analyze the first (strongest) result.
            if (results[0].ApplicationGesture == ApplicationGesture.ScratchOut &&
                  results[0].RecognitionConfidence == RecognitionConfidence.Strong)
            {
                // Use the scratchout stroke to perform hit-testing and 
                // erase existing strokes, as necessary.
                return true;
            }
            else
            {
                // Not a gesture: display the stroke normally.
                return false;
            }
        }
        //</Snippet8>


    //<Snippet2>
    } //end class
    //</Snippet2>
    class Program : Application
    {
        Window win;
        RealTimeInkControl inkControl;
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);
            win = new Window();
            inkControl = new RealTimeInkControl();
            inkControl.Background = Brushes.Beige;
            win.Content = inkControl;
            win.Show();
        }

        [STAThread]
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
//<Snippet7>
} //end namespace
//</Snippet7>