using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Reflection;

using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
    
namespace AdvancedInkInputSemples
{
    // <Snippet1>
    // EventArgs for the StrokeRendered event.
    public class StrokeRenderedEventArgs : EventArgs
    {
        StylusPointCollection strokePoints;

        public StrokeRenderedEventArgs(StylusPointCollection points)
        {
            strokePoints = points;
        }

        public StylusPointCollection StrokePoints
        {
            get
            {
                return strokePoints;
            }
        }
    }

    // EventHandler for the StrokeRendered event.
    public delegate void StrokeRenderedEventHandler(object sender, StrokeRenderedEventArgs e);

    // A StylusPlugin that restricts the input area
    class FilterPlugin : StylusPlugIn
    {
        StylusPointCollection collectedPoints;
        int currentStylus = -1;
        public event StrokeRenderedEventHandler StrokeRendered;

        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusDown(rawStylusInput);

            if (currentStylus == -1)
            {
                StylusPointCollection pointsFromEvent = rawStylusInput.GetStylusPoints();

                // Create an emtpy StylusPointCollection to contain the filtered
                // points.
                collectedPoints = new StylusPointCollection(pointsFromEvent.Description);
                
                // Restrict the stylus input and add the filtered 
                // points to collectedPoints. 
                StylusPointCollection points = FilterPackets(pointsFromEvent);
                rawStylusInput.SetStylusPoints(points);
                collectedPoints.Add(points);

                currentStylus = rawStylusInput.StylusDeviceId;
            }
        }

        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusMove(rawStylusInput);

            if (currentStylus == rawStylusInput.StylusDeviceId)
            {
                StylusPointCollection pointsFromEvent = rawStylusInput.GetStylusPoints();

                // Restrict the stylus input and add the filtered 
                // points to collectedPoints. 
                StylusPointCollection points = FilterPackets(pointsFromEvent);
                rawStylusInput.SetStylusPoints(points);
                collectedPoints.Add(points);
            }
        }

        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusUp(rawStylusInput);

            if (currentStylus == rawStylusInput.StylusDeviceId)
            {
                StylusPointCollection pointsFromEvent = rawStylusInput.GetStylusPoints();

                // Restrict the stylus input and add the filtered 
                // points to collectedPoints. 
                StylusPointCollection points = FilterPackets(pointsFromEvent);
                rawStylusInput.SetStylusPoints(points);
                collectedPoints.Add(points);

                // Subscribe to the OnStylusUpProcessed method.
                rawStylusInput.NotifyWhenProcessed(collectedPoints);

                currentStylus = -1;
            }
        }

        private StylusPointCollection FilterPackets(StylusPointCollection stylusPoints)
        {
            // Modify the (X,Y) data to move the points 
            // inside the acceptable input area, if necessary
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                if (sp.X < 50) sp.X = 50;
                if (sp.X > 250) sp.X = 250;
                if (sp.Y < 50) sp.Y = 50;
                if (sp.Y > 250) sp.Y = 250;
                stylusPoints[i] = sp;
            }

            // Return the modified StylusPoints.
            return stylusPoints;
        }

        // This is called on the application thread.  
        protected override void OnStylusUpProcessed(object callbackData, bool targetVerified)
        {
            // Check that the element actually receive the OnStylusUp input.
            if (targetVerified)
            {
                StylusPointCollection strokePoints = callbackData as StylusPointCollection;

                if (strokePoints == null)
                {
                    return;
                }

                // Raise the StrokeRendered event so the consumer of the plugin can
                // add the filtered stroke to its StrokeCollection.
                StrokeRenderedEventArgs e = new StrokeRenderedEventArgs(strokePoints);
                OnStrokeRendered(e);
            }

        }

        protected virtual void OnStrokeRendered(StrokeRenderedEventArgs e)
        {
            if (StrokeRendered != null)
            {
                StrokeRendered(this, e);
            }
        }
    }
    // </Snippet1>

    class PacketTracer
    {
        static public void WriteDescriptionInfo(StylusPointCollection points)
        {
            StylusPointDescription pointsDescription = points.Description;
            ReadOnlyCollection<StylusPointPropertyInfo> properties =
                pointsDescription.GetStylusPointProperties();

            Debug.WriteLine("Property Count:" + pointsDescription.PropertyCount.ToString());

            foreach (StylusPointPropertyInfo property in properties)
            {
                // GetStylusPointPropertyName is defined below and returns the
                // name of the property.
                Debug.WriteLine("  name = " + GetStylusPointPropertyName(property));

                //Debug.WriteLine += "  Guid = " + property.Id + "\r\n";
                //Debug.WriteLine += "  IsButton = " + property.IsButton;
                //Debug.WriteLine += "  Min = " + property.Minimum;
                //Debug.WriteLine += "  Max = " + property.Maximum;
                //Debug.WriteLine += "  Unit = " + property.Unit;
                //Debug.WriteLine += "  Res = " + property.Resolution + "\r\n";
            }
        }

        // Use reflection to get the name of currentProperty.
        private static string GetStylusPointPropertyName(StylusPointProperty currentProperty)
        {
            Guid guid = currentProperty.Id;

            // Iterate through the StylusPointProperties to find the StylusPointProperty
            // that matches currentProperty, then return the name.
            foreach (FieldInfo theFieldInfo
                in typeof(StylusPointProperties).GetFields())
            {
                StylusPointProperty property = (StylusPointProperty)theFieldInfo.GetValue(currentProperty);
                if (property.Id == guid)
                {
                    return theFieldInfo.Name;
                }
            }
            return "Not found";
        }

    }

    class CustomPluginSamples : StylusPlugIn
    {
        //<Snippet8>
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusDown(rawStylusInput);

            // Get the StylusPoints that have come in
            StylusPointCollection stylusPoints = rawStylusInput.GetStylusPoints();

            // Modify the (X,Y) data to move the points 
            // inside the acceptable input area, if necessary
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                if (sp.X < 50) sp.X = 50;
                if (sp.X > 250) sp.X = 250;
                if (sp.Y < 50) sp.Y = 50;
                if (sp.Y > 250) sp.Y = 250;
                stylusPoints[i] = sp;
            }

            // Copy the modified StylusPoints back to the RawStylusInput
            rawStylusInput.SetStylusPoints(stylusPoints);
        }
        //</Snippet8>

        //<Snippet9>
        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusMove(rawStylusInput);

            // Get the StylusPoints that have come in
            StylusPointCollection stylusPoints = rawStylusInput.GetStylusPoints();

            // Modify the (X,Y) data to move the points 
            // inside the acceptable input area, if necessary
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                if (sp.X < 50) sp.X = 50;
                if (sp.X > 250) sp.X = 250;
                if (sp.Y < 50) sp.Y = 50;
                if (sp.Y > 250) sp.Y = 250;
                stylusPoints[i] = sp;
            }

            // Copy the modified StylusPoints back to the RawStylusInput
            rawStylusInput.SetStylusPoints(stylusPoints);
        }
        //</Snippet9>

        //<Snippet10>
        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusUp(rawStylusInput);

            // Get the StylusPoints that have come in
            StylusPointCollection stylusPoints = rawStylusInput.GetStylusPoints();

            // Modify the (X,Y) data to move the points 
            // inside the acceptable input area, if necessary
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                if (sp.X < 50) sp.X = 50;
                if (sp.X > 250) sp.X = 250;
                if (sp.Y < 50) sp.Y = 50;
                if (sp.Y > 250) sp.Y = 250;
                stylusPoints[i] = sp;
            }

            // Copy the modified StylusPoints back to the RawStylusInput
            rawStylusInput.SetStylusPoints(stylusPoints);
        }
        //</Snippet10>

    }
}
