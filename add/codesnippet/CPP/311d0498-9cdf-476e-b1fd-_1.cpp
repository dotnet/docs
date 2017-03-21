        // Draw the check box in the current state.
        virtual void OnPaint(PaintEventArgs ^e) override
        {
            Control::OnPaint(e);

            CheckBoxRenderer::DrawCheckBox(e->Graphics,
                ClientRectangle.Location, this->getTextRectangle(), this->Text,
                this->Font, TextFormatFlags::HorizontalCenter,
                clicked, state);
        }


        // Draw the check box in the checked or unchecked state, alternately.
        virtual void OnMouseDown(MouseEventArgs ^e) override
        {
            Control::OnMouseDown(e);

            if (!clicked)
            {
                clicked = true;
                this->Text = "Clicked!";
                state = CheckBoxState::CheckedPressed;
                Invalidate();
            }
            else
            {
                clicked = false;
                this->Text = "Click here";
                state = CheckBoxState::UncheckedNormal;
                Invalidate();
            }
        }