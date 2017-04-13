using System;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestureSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        Canvas canvas1 = new Canvas();
        public Window1()
            : base()
        {
            InitializeComponent();
            inkCanvas1.StylusSystemGesture += new StylusSystemGestureEventHandler(inkCanvas1_StylusSystemGesture);

            //<Snippet2>
            Stylus.SetIsFlicksEnabled(canvas1, false);
            //</Snippet2>

            //<Snippet4>
            Stylus.SetIsTapFeedbackEnabled(canvas1, false);
            //</Snippet4>

            //<Snippet5>
            bool tapFeedbackEnabled = Stylus.GetIsTapFeedbackEnabled(canvas1);
            //</Snippet5>

            //<Snippet6>
            bool flicksEnabled = Stylus.GetIsFlicksEnabled(canvas1);
            //</Snippet6>

            canvas1.StylusSystemGesture += new StylusSystemGestureEventHandler(canvas1_StylusSystemGesture);

           
        }

        private void TouchFeedbackSnippets()
        {
            //<Snippet8>
            Stylus.SetIsTouchFeedbackEnabled(inkCanvas1, true);
            //</Snippet8>

            //<Snippet7>
            bool touchFeedbackEnabled = Stylus.GetIsTouchFeedbackEnabled(inkCanvas1);
            //</Snippet7>
        }

        void inkCanvas1_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            if (e.SystemGesture == SystemGesture.Flick)
            {
                Title = e.SystemGesture.ToString();
            }
        }

        void canvas1_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            Title = e.SystemGesture.ToString();
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        private void OnLoad(object sender, EventArgs e) 
        {
            //<Snippet3>
            // Add this code to the contstructor or OnLoaded method.
            if (inkCanvas1.IsGestureRecognizerAvailable)
            {
                inkCanvas1.EditingMode = InkCanvasEditingMode.InkAndGesture;
                inkCanvas1.Gesture += new InkCanvasGestureEventHandler(inkCanvas1_Gesture);
                inkCanvas1.SetEnabledGestures(new ApplicationGesture[] 
                                {ApplicationGesture.Down, 
                                 ApplicationGesture.ArrowDown,
                                 ApplicationGesture.Circle});
            }
            //</Snippet3>
        }

        // Sample event handler:  
        private void button1_click(object sender, RoutedEventArgs e) {}



        //<Snippet1>
        void inkCanvas1_Gesture(object sender, InkCanvasGestureEventArgs e)
        {
            ReadOnlyCollection<GestureRecognitionResult> gestureResults = 
                e.GetGestureRecognitionResults();

            // Check the first recognition result for a gesture.
            if (gestureResults[0].RecognitionConfidence == 
                RecognitionConfidence.Strong)
            {
                switch (gestureResults[0].ApplicationGesture)
                {
                    case ApplicationGesture.Down:
                        // Do something.
                        break;
                    case ApplicationGesture.ArrowDown:
                        // Do something.
                        break;
                    case ApplicationGesture.Circle:
                        // Do something.
                        break;
                }

            }
        }
        //</Snippet1>
    }
}