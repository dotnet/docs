        private static void DrawALineOfText(PaintEventArgs e)
        {
            // Declare strings to render on the form.
            string[] stringsToPaint = { "Tail", "Spin", " Toys" };

            // Declare fonts for rendering the strings.
            Font[] fonts = { new Font("Arial", 14, FontStyle.Regular), 
                new Font("Arial", 14, FontStyle.Italic), 
                new Font("Arial", 14, FontStyle.Regular) };

            Point startPoint = new Point(10, 10);

            // Set TextFormatFlags to no padding so strings are drawn together.
            TextFormatFlags flags = TextFormatFlags.NoPadding;

            // Declare a proposed size with dimensions set to the maximum integer value.
            Size proposedSize = new Size(int.MaxValue, int.MaxValue);

            // Measure each string with its font and NoPadding value and 
            // draw it to the form.
            for (int i = 0; i < stringsToPaint.Length; i++)
            {
                Size size = TextRenderer.MeasureText(e.Graphics, stringsToPaint[i], 
                    fonts[i], proposedSize, flags);
                Rectangle rect = new Rectangle(startPoint, size);
                TextRenderer.DrawText(e.Graphics, stringsToPaint[i], fonts[i],
                    startPoint, Color.Black, flags);
                startPoint.X += size.Width;
            }
            
        }