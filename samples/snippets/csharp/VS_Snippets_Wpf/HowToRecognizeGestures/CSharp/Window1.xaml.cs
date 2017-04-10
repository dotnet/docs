//<Snippet1>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Collections.ObjectModel;

public partial class Window1 : Window
{
    public Window1()
    {
        InitializeComponent();

        if (inkCanvas1.IsGestureRecognizerAvailable)
        {
            inkCanvas1.EditingMode = InkCanvasEditingMode.InkAndGesture;
            inkCanvas1.Gesture += new InkCanvasGestureEventHandler(inkCanvas1_Gesture);
            inkCanvas1.SetEnabledGestures(
                new ApplicationGesture[] { ApplicationGesture.ScratchOut });
        }
    }

    void inkCanvas1_Gesture(object sender, InkCanvasGestureEventArgs e)
    {
        ReadOnlyCollection<GestureRecognitionResult> gestureResults =
            e.GetGestureRecognitionResults();

        // Check the first recognition result for a gesture.
        if ((gestureResults[0].RecognitionConfidence ==
            RecognitionConfidence.Strong) &&
           (gestureResults[0].ApplicationGesture ==
            ApplicationGesture.ScratchOut))
        {
            StrokeCollection hitStrokes = inkCanvas1.Strokes.HitTest(
                                            e.Strokes.GetBounds(), 10);

            if (hitStrokes.Count > 0)
            {
                inkCanvas1.Strokes.Remove(hitStrokes);
            }
        }
    }
}
//</Snippet1>