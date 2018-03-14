using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace StrokeCollectionShadow
{

    //<Snippet1>
    class ShadowedStroke : Stroke
    {

        // Be sure to pass in the DrawingAttributes when you create the stroke to
        // subscribe to the PropertyDataChaned event.
        public ShadowedStroke(StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes)
            : base(stylusPoints, drawingAttributes)
        {
            this.DrawingAttributes.PropertyDataChanged += new PropertyDataChangedEventHandler(DrawingAttributes_PropertyDataChanged);
        }

        Guid shadow = new Guid("12345678-9012-3456-7890-123456789012");

        public bool Shadowed
        {
            // Return the value of the custom property, shadow.
            // If there is no custom property, return false.
            get
            {
                if (!this.DrawingAttributes.ContainsPropertyData(shadow))
                {
                    return false;
                }

                object propertyData = this.DrawingAttributes.GetPropertyData(shadow);

                if (propertyData is bool)
                {
                    return (bool)propertyData;
                }
                else
                {
                    return false;
                }
            }

            // Set the value of the custom property.
            set
            {
                this.DrawingAttributes.AddPropertyData(shadow, value);

            }
        }

        void DrawingAttributes_PropertyDataChanged(object sender, PropertyDataChangedEventArgs e)
        {
             this.OnInvalidated(new EventArgs());
        }

        protected override void DrawCore(System.Windows.Media.DrawingContext context, DrawingAttributes overrides)
        {
            // create a drop shadow
            //
            if (this.Shadowed)
            {
                Geometry pathGeometry = this.GetGeometry(overrides).Clone();
                pathGeometry.Transform = new TranslateTransform(5, 0);
                try
                {
                    context.PushOpacity(0.5);
                    context.DrawGeometry(Brushes.DarkGray, null, pathGeometry);
                }
                finally
                {
                    context.Pop();
                }

            }
            base.DrawCore(context, overrides);
        }
    }
    //</Snippet1>
}
