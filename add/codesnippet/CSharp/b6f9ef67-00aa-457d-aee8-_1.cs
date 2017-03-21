        // Define the text bounds so that the text rectangle 
        // does not include the radio button.
        public Rectangle TextRectangle
        {
            get
            {
                using (Graphics g = this.CreateGraphics())
                {
                    textRectangleValue.X = ClientRectangle.X +
                        RadioButtonRenderer.GetGlyphSize(g,
                        RadioButtonState.UncheckedNormal).Width;
                    textRectangleValue.Y = ClientRectangle.Y;
                    textRectangleValue.Width = ClientRectangle.Width -
                        RadioButtonRenderer.GetGlyphSize(g,
                        RadioButtonState.UncheckedNormal).Width;
                    textRectangleValue.Height = ClientRectangle.Height;
                }

                return textRectangleValue;
            }
        }