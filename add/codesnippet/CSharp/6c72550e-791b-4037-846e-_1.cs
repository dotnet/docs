        private void AddStringExample(PaintEventArgs e)
        {
                     
            // Create a GraphicsPath object.
            GraphicsPath myPath = new GraphicsPath();
                     
            // Set up all the string parameters.
            string stringText = "Sample Text";
            FontFamily family = new FontFamily("Arial");
            int fontStyle = (int)FontStyle.Italic;
            int emSize = 26;
            Point origin = new Point(20, 20);
            StringFormat format = StringFormat.GenericDefault;
                     
            // Add the string to the path.
            myPath.AddString(stringText,
                family,
                fontStyle,
                emSize,
                origin,
                format);
                     
            //Draw the path to the screen.
            e.Graphics.FillPath(Brushes.Black, myPath);
        }