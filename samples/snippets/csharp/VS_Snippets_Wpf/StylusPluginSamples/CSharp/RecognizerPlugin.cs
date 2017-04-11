using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Diagnostics;

namespace AdvancedInkInputSemples
{
    //<Snippet12>
    class RecognizerPlugin : StylusPlugIn
    {
        GestureRecognizer recognizer;
        
        //<Snippet20>
        // StylusPointCollection that contains the stylus points of the current
        // stroke.
        StylusPointCollection points;

        // Keeps track of the stylus to check whether two styluses are used on the
        // digitizer.
        int currentStylus;
        //</Snippet20>

        public RecognizerPlugin()
            : base()
        {
            recognizer = new GestureRecognizer();
        }

        // <Snippet15>
        // Collect the points as the user draws the stroke.
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            // If points is not null, there is already a stroke taking place
            // on the digitizer, so don't create a new StylusPointsCollection.
            if (points == null)
            {
                points = new StylusPointCollection(rawStylusInput.GetStylusPoints().Description);
                points.Add(rawStylusInput.GetStylusPoints());
                currentStylus = rawStylusInput.StylusDeviceId;
            }
        }

        // Collect the points as the user draws the stroke.
        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            // Check whether the stylus that started the stroke is the same, and
            // that the element hasn't lost focus since the stroke began.
                if (points != null && currentStylus == rawStylusInput.StylusDeviceId)
            {
                points.Add(rawStylusInput.GetStylusPoints());
            }
        }

        // Collect the points as the user draws the stroke.
        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            // Check whether the stylus that started the stroke is the same, and
            // that the element hasn't lost focus since the stroke began.
            if (points != null && currentStylus == rawStylusInput.StylusDeviceId)
            {
                points.Add(rawStylusInput.GetStylusPoints());

                // Subscribe to the OnStylusUpProcessed method.
                rawStylusInput.NotifyWhenProcessed(points);
            }

            points = null;
            currentStylus = 0;
        }
        // </Snippet15>
            
        //<Snippet14>
        // If the element loses focus, stop collecting the points and don't
        // perform gesture recognition.
        protected override void OnStylusLeave(RawStylusInput rawStylusInput, bool confirmed)
        {
            if (confirmed)
            {
                // Clear the StylusPointCollection
                points = null;
                currentStylus = 0;
            }
        }
        //</Snippet14>

        // This method is called on the application thread.
        protected override void OnStylusUpProcessed(object callbackData, bool targetVerified)
        {
            // Check that the element actually receive the OnStylusUp input.
            if (targetVerified && recognizer.IsRecognizerAvailable)
            {
                StylusPointCollection strokePoints = callbackData as StylusPointCollection;

                if (strokePoints == null)
                {
                    return;
                }

                // Create a StrokeCollection to pass to the GestureRecognizer.
                Stroke newStroke = new Stroke(strokePoints);
                StrokeCollection strokes = new StrokeCollection();
                strokes.Add(newStroke);

                ReadOnlyCollection<GestureRecognitionResult> results = recognizer.Recognize(strokes);

                // If the GestureRecognizer recognizes the stroke as a Down
                // gesture with strong confidence, raise an event.
                if (results[0].ApplicationGesture == ApplicationGesture.Down &&
                    results[0].RecognitionConfidence == RecognitionConfidence.Strong)
                {
                    //raise event
                }
            }
        }
    }
    //</Snippet12>
}
