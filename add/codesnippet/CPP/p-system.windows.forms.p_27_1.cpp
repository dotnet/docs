        // Draw the progress bar in its normal state.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            if (ProgressBarRenderer::IsSupported)
            {
                ProgressBarRenderer::DrawVerticalBar(e->Graphics, 
                    ClientRectangle);
                this->Parent->Text = "VerticalProgressBar Enabled";
            }
            else
            {
                this->Parent->Text = "VerticalProgressBar Disabled";
            }
        }