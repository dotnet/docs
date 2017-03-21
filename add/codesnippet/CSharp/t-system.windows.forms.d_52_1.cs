    class MyGlyph : Glyph
    {
        Control control;
        BehaviorService behaviorSvc;

        public MyGlyph(BehaviorService behaviorSvc, Control control) : 
            base(new MyBehavior())
        {
            this.behaviorSvc = behaviorSvc;
            this.control = control;
        }

        public override Rectangle Bounds
        {
            get
            {
                // Create a glyph that is 10x10 and sitting
                // in the middle of the control.  Glyph coordinates
                // are in adorner window coordinates, so we must map
                // using the behavior service.
                Point edge = behaviorSvc.ControlToAdornerWindow(control);
                Size size = control.Size;
                Point center = new Point(edge.X + (size.Width / 2), 
                    edge.Y + (size.Height / 2));

                Rectangle bounds = new Rectangle(
                    center.X - 5,
                    center.Y - 5,
                    10,
                    10);

                return bounds;
            }
        }

        public override Cursor GetHitTest(Point p)
        {
            // GetHitTest is called to see if the point is
            // within this glyph.  This gives us a chance to decide
            // what cursor to show.  Returning null from here means
            // the mouse pointer is not currently inside of the glyph.
            // Returning a valid cursor here indicates the pointer is
            // inside the glyph, and also enables our Behavior property
            // as the active behavior.
            if (Bounds.Contains(p))
            {
                return Cursors.Hand;
            }

            return null;
        }

        public override void Paint(PaintEventArgs pe)
        {
            // Draw our glyph. It is simply a blue ellipse.
            pe.Graphics.FillEllipse(Brushes.Blue, Bounds);
        }

        // By providing our own behavior we can do something interesting
        // when the user clicks or manipulates our glyph.
        class MyBehavior : Behavior
        {
            public override bool OnMouseUp(Glyph g, MouseButtons button)
            {
                MessageBox.Show("Hey, you clicked the mouse here");
                return true; // indicating we processed this event.
            }
        }
    }