        // Draw the large or small button, depending on the current state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            // Draw the smaller pressed button image
            if (state == PushButtonState::Pressed)
            {
                // Set the background color to the parent if visual styles
                // are disabled, because DrawParentBackground will only paint
                // over the control background if visual styles are enabled.
                if (Application::RenderWithVisualStyles)
                {
                    this->BackColor = Color::Azure;
                }
                else
                {
                    this->BackColor = this->Parent->BackColor;
                }


                // If you comment out the call to DrawParentBackground,
                // the background of the control will still be visible
                // outside the pressed button, if visual styles are enabled.
                ButtonRenderer::DrawParentBackground(e->Graphics,
                    ClientRectangle, this);
                ButtonRenderer::DrawButton(e->Graphics, ClickRectangle,
                    this->Text, this->Font, true, state);
            }

            // Draw the bigger unpressed button image.
            else
            {
                ButtonRenderer::DrawButton(e->Graphics, ClientRectangle,
                    this->Text, this->Font, false, state);
            }
        }

        // Draw the smaller pressed button image.
    protected:
        virtual void OnMouseDown(MouseEventArgs^ e) override
        {
            __super::OnMouseDown(e);
            this->Text = "Clicked!";
            state = PushButtonState::Pressed;
            Invalidate();
        }

        // Draw the button in the hot state.
    protected:
        virtual void OnMouseEnter(EventArgs^ e) override
        {
            __super::OnMouseEnter(e);
            this->Text = "Click here";
            state = PushButtonState::Hot;
            Invalidate();
        }

        // Draw the button in the unpressed state.
    protected:
        virtual void OnMouseLeave(EventArgs^ e) override
        {
            __super::OnMouseLeave(e);
            this->Text = "Click here";
            state = PushButtonState::Normal;
            Invalidate();
        }