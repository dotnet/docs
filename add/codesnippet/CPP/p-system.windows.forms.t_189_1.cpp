        // Draw the tab page and the tab items.
    protected:
        virtual void OnPaint(PaintEventArgs^ e) override
        {
            __super::OnPaint(e);

            if (!TabRenderer::IsSupported)
            {
                this->Parent->Text = "CustomTabControl Disabled";
                return;
            }

            TabRenderer::DrawTabPage(e->Graphics, tabPageRectangle);
            TabRenderer::DrawTabItem(e->Graphics, tabItemRectangle1,
                tab1Text, this->Font, tab1Focused, tab1State);
            TabRenderer::DrawTabItem(e->Graphics, tabItemRectangle2,
                tab2Text, this->Font, tab2Focused, tab2State);

            this->Parent->Text = "CustomTabControl Enabled";
        }