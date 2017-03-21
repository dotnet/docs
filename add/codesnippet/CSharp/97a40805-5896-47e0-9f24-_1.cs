        public override void Paint(PaintEventArgs pe)
        {
            // Draw our glyph. It is simply a blue ellipse.
            pe.Graphics.FillEllipse(Brushes.Blue, Bounds);
        }