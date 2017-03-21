        // Provide a design-time border style for the panel.
        public override Style FrameStyle
        {
            get
            {
                Style styleOfFrame = base.FrameStyle;

                // If no border style is defined, define one.
                if (styleOfFrame.BorderStyle == BorderStyle.NotSet ||
                    styleOfFrame.BorderStyle == BorderStyle.None)
                    styleOfFrame.BorderStyle = BorderStyle.Outset;

                return styleOfFrame;
            }
        } // FrameStyle