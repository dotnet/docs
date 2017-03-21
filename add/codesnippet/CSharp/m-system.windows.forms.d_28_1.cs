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