    public:
        virtual property Rectangle Bounds
        {
            Rectangle get() override
            {
                // Create a glyph that is 10x10 and sitting
                // in the middle of the control.  Glyph coordinates
                // are in adorner window coordinates, so we must map
                // using the behavior service.
                Point edge = behavior->ControlToAdornerWindow(control);
                Size size = control->Size;
                Point center = Point(edge.X + (size.Width / 2),
                    edge.Y + (size.Height / 2));

                Rectangle bounds = Rectangle(center.X - 5,
                    center.Y - 5, 10, 10);

                return bounds;
            }
        }