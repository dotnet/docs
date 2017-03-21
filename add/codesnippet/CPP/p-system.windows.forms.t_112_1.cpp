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