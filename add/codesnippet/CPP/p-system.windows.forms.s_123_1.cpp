        // Draw the scroll bar in its normal state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            // Visual styles are not enabled.
            if (!ScrollBarRenderer::IsSupported)
            {
                this->Parent->Text = "CustomScrollBar Disabled";
                return;
            }

            this->Parent->Text = "CustomScrollBar Enabled";

            // Draw the scroll bar track.
            ScrollBarRenderer::DrawRightHorizontalTrack(e->Graphics,
                ClientRectangle, ScrollBarState::Normal);

            // Draw the thumb and thumb grip in the current state.
            ScrollBarRenderer::DrawHorizontalThumb(e->Graphics,
                thumbRectangle, thumbState);
            ScrollBarRenderer::DrawHorizontalThumbGrip(e->Graphics,
                thumbRectangle, thumbState);

            // Draw the scroll arrows in the current state.
            ScrollBarRenderer::DrawArrowButton(e->Graphics,
                leftArrowRectangle, leftButtonState);
            ScrollBarRenderer::DrawArrowButton(e->Graphics,
                rightArrowRectangle, rightButtonState);

            // Draw a highlighted rectangle in the left side of the scroll
            // bar track if the user has clicked between the left arrow
            // and thumb.
            if (leftBarClicked)
            {
                clickedBarRectangle.X = thumbLeftLimit;
                clickedBarRectangle.Width = thumbRectangle.X - thumbLeftLimit;
                ScrollBarRenderer::DrawLeftHorizontalTrack(e->Graphics,
                    clickedBarRectangle, ScrollBarState::Pressed);
            }

            // Draw a highlighted rectangle in the right side of the scroll
            // bar track if the user has clicked between the right arrow
            // and thumb.
            else if (rightBarClicked)
            {
                clickedBarRectangle.X =
                    thumbRectangle.X + thumbRectangle.Width;
                clickedBarRectangle.Width =
                    thumbRightLimitRight - clickedBarRectangle.X;
                ScrollBarRenderer::DrawRightHorizontalTrack(e->Graphics,
                    clickedBarRectangle, ScrollBarState::Pressed);
            }
        }