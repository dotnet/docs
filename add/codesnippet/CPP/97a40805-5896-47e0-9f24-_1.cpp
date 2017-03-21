    public:
        virtual void Paint(PaintEventArgs^ pe) override
        {
            // Draw our glyph.  Our's is simple:  a blue ellipse.
            pe->Graphics->FillEllipse(Brushes::Blue, Bounds);
        }