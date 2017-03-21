
    // By providing our own behavior we can do something
    // interesting when the user clicks or manipulates our glyph.
    public  ref class DemoBehavior : public Behavior
    {
    public:
        bool OnMouseUp(Glyph^ g, MouseButtons^ button)
        {
            MessageBox::Show("Hey, you clicked the mouse here");

            // indicating we processed this event.
            return true;
        }
    };

    public ref class DemoGlyph : public Glyph
    {
        Control^ control;
        BehaviorService^ behavior;

    public:
        DemoGlyph(BehaviorService^ behavior, Control^ control):
          Glyph(gcnew BehaviorServiceSample::DemoBehavior)
          {
              this->behavior = behavior;
              this->control = control;
          }

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

    public:
        virtual Cursor^ GetHitTest(Point p) override
        {
            // GetHitTest is called to see if the point is
            // within this glyph.  This gives us a chance to decide
            // what cursor to show.  Returning null from here means
            // the mouse pointer is not currently inside of the
            // glyph.  Returning a valid cursor here indicates the
            // pointer is inside the glyph, and also enables our
            // Behavior property as the active behavior.
            if (Bounds.Contains(p))
            {
                return Cursors::Hand;
            }
            return nullptr;
        }

    public:
        virtual void Paint(PaintEventArgs^ pe) override
        {
            // Draw our glyph.  Our's is simple:  a blue ellipse.
            pe->Graphics->FillEllipse(Brushes::Blue, Bounds);
        }
    };
