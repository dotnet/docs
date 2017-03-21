        // Draw the group box in the current state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override 
        {
            __super::OnPaint(e);

            GroupBoxRenderer::DrawGroupBox(e->Graphics, ClientRectangle,
                this->Text, this->Font, state);

            // Draw an additional inner border if visual styles are enabled.
            if (Application::RenderWithVisualStyles)
            {
                GroupBoxRenderer::DrawGroupBox(e->Graphics, innerRectangle,
                    state);
            }
        }