// This sample can go in TrackBarRenderer class overview.
// - Snippet2 can go in GetTopPointingThumbSize, and possibly other Gets
// - Snippet4 can go in IsSupported, DrawHorizontalTrack, and DrawTopPointingThumb
// - Snippet6 can go in DrawVerticalTick; see below about bug in the meantime, though

//<Snippet0>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

namespace TrackBarRendererSample
{
    ref class CustomTrackBar : public Control
    {
    private:
        int numberTicks;
        Rectangle trackRectangle;
        Rectangle ticksRectangle;
        Rectangle thumbRectangle;
        int currentTickPosition;
        float tickSpace;
        bool thumbClicked;
        TrackBarThumbState thumbState;

    public:
        CustomTrackBar(int ticks, System::Drawing::Size trackBarSize)
        {
            this->Location = Point(10, 10);
            this->Size = trackBarSize;
            this->numberTicks = ticks;
            this->BackColor = Color::DarkCyan;
            this->DoubleBuffered = true;
            numberTicks = 10;
            thumbState = TrackBarThumbState::Normal;

            // Calculate the initial sizes of the bar,
            // thumb and ticks.
            SetupTrackBar();
        }

        //<Snippet2>
        //<Snippet6>
        // Calculate the sizes of the bar, thumb, and ticks rectangle.
    private:
        void SetupTrackBar()
        {
            if (!TrackBarRenderer::IsSupported)
            {
                return;
            }

            Graphics^ g = this->CreateGraphics();

            // Calculate the size of the track bar.
            trackRectangle.X = ClientRectangle.X + 2;
            trackRectangle.Y = ClientRectangle.Y + 28;
            trackRectangle.Width = ClientRectangle.Width - 4;
            trackRectangle.Height = 4;

            // Calculate the size of the rectangle in which to
            // draw the ticks.
            ticksRectangle.X = trackRectangle.X + 4;
            ticksRectangle.Y = trackRectangle.Y - 8;
            ticksRectangle.Width = trackRectangle.Width - 8;
            ticksRectangle.Height = 4;

            tickSpace = ((float)ticksRectangle.Width - 1) /
                ((float)numberTicks - 1);

            // Calculate the size of the thumb.
            thumbRectangle.Size =
                TrackBarRenderer::GetTopPointingThumbSize(g,
                TrackBarThumbState::Normal);

            thumbRectangle.X = CurrentTickXCoordinate();
            thumbRectangle.Y = trackRectangle.Y - 8;
        }
        //</Snippet2>

    private:
        int CurrentTickXCoordinate()
        {
            if (tickSpace == 0)
            {
                return 0;
            }
            else
            {
                return ((int)Math::Round(tickSpace) *
                    currentTickPosition);
            }
        }

        //<Snippet4>
        // Draw the track bar.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            if (!TrackBarRenderer::IsSupported)
            {
                this->Parent->Text = "CustomTrackBar Disabled";
                return;
            }

            this->Parent->Text = "CustomTrackBar Enabled";
            TrackBarRenderer::DrawHorizontalTrack(e->Graphics,
                trackRectangle);
            TrackBarRenderer::DrawTopPointingThumb(e->Graphics,
                thumbRectangle, thumbState);
            TrackBarRenderer::DrawHorizontalTicks(e->Graphics,
                ticksRectangle, numberTicks, EdgeStyle::Raised);
        }
        //</Snippet6>

        // Determine whether the user has clicked the track bar thumb.
    protected:
        virtual void OnMouseDown(MouseEventArgs^ e) override
        {
            if (!TrackBarRenderer::IsSupported)
            {
                return;
            }
            if (this->thumbRectangle.Contains(e->Location))
            {
                thumbClicked = true;
                thumbState = TrackBarThumbState::Pressed;
            }

            this->Invalidate();
        }
        //</Snippet4>

        // Redraw the track bar thumb if the user has moved it.
    protected:
        virtual void OnMouseUp(MouseEventArgs^ e) override
        {
            if (!TrackBarRenderer::IsSupported)
            {
                return;
            }
            if (thumbClicked == true)
            {
                if (e->Location.X > trackRectangle.X &&
                    e->Location.X < (trackRectangle.X +
                    trackRectangle.Width - thumbRectangle.Width))
                {
                    thumbClicked = false;
                    thumbState = TrackBarThumbState::Hot;
                    this->Invalidate();
                }

                thumbClicked = false;
            }
        }

        // Track cursor movements.
    protected:
        virtual void OnMouseMove(MouseEventArgs^ e) override
        {
            if (!TrackBarRenderer::IsSupported)
            {
                return;
            }
            // The user is moving the thumb.
            if (thumbClicked == true)
            {
                // Track movements to the next tick to the right, if
                // the cursor has moved halfway to the next tick.
                if (currentTickPosition < numberTicks - 1 &&
                    e->Location.X > CurrentTickXCoordinate() +
                    (int)(tickSpace))
                {
                    currentTickPosition++;
                }

                // Track movements to the next tick to the left, if
                // cursor has moved halfway to the next tick.
                else if (currentTickPosition > 0 &&
                    e->Location.X < CurrentTickXCoordinate() -
                    (int)(tickSpace / 2))
                {
                    currentTickPosition--;
                }

                thumbRectangle.X = CurrentTickXCoordinate();
            }

            // The cursor is passing over the track.
            else
            {
                if (thumbRectangle.Contains(e->Location))
                {
                    thumbState = TrackBarThumbState::Hot;
                }
                else
                {
                    thumbState = TrackBarThumbState::Normal;
                }
            }

            Invalidate();
        }
    };

    ref class Form1 : public Form
    {
    public:
        Form1()
        {
            CustomTrackBar^ TrackBar1 = gcnew CustomTrackBar(19,
                System::Drawing::Size(300, 50));
            this->Width = 500;
            this->Controls->Add(TrackBar1);
        }
    };
}

[STAThread]
int main()
{
    // Note that the call to EnableVisualStyles below does
    // not affect whether TrackBarRenderer.IsSupported is true;
    // as long as visual styles are enabled by the operating system,
    // IsSupported is true.
    Application::EnableVisualStyles();
    Application::Run(gcnew TrackBarRendererSample::Form1());
    return 0;
}
//</Snippet0>
