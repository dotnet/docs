        // Get the sizes and offsets for the window parts as specified
        // by the visual style.
    private:
        void GetPartDetails()
        {
            // Do nothing further if visual styles are not enabled.
            if (!Application::RenderWithVisualStyles)
            {
                return;
            }

            Graphics^ g = this->CreateGraphics();

            // Get the size and offset of the close button.
            if (SetRenderer(windowElements["windowClose"]))
            {
                closeButtonSize =
                    renderer->GetPartSize(g, ThemeSizeType::True);
                closeButtonOffset =
                    renderer->GetPoint(PointProperty::Offset);
            }

            // Get the height of the window caption.
            if (SetRenderer(windowElements["windowCaption"]))
            {
                captionHeight = renderer->GetPartSize(g,
                    ThemeSizeType::True).Height;
            }

            // Get the thickness of the left, bottom,
            // and right window frame.
            if (SetRenderer(windowElements["windowLeft"]))
            {
                frameThickness = renderer->GetPartSize(g,
                    ThemeSizeType::True).Width;
            }

            // Get the size of the resizing gripper.
            if (SetRenderer(windowElements["statusGripper"]))
            {
                gripperSize = renderer->GetPartSize(g,
                    ThemeSizeType::True);
            }

        }