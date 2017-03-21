        // Calculate and set the clipping region for the control
        // so that the corners of the title bar are rounded.
    private:
        void SetClipRegion()
        {
            if (!Application::RenderWithVisualStyles)
            {
                return;
            }

            Graphics^ g = this->CreateGraphics();
            // Get the current region for the window caption.
            if (SetRenderer(windowElements["windowCaption"]))
            {
                System::Drawing::Region^ clipRegion =
                    renderer->GetBackgroundRegion(g,
                    elementRectangles["windowCaption"]);

                // Get the client rectangle, but exclude the region
                // of the window caption.
                int height = (int)clipRegion->GetBounds(g).Height;
                System::Drawing::Rectangle nonCaptionRect = Rectangle(
                    ClientRectangle.X, ClientRectangle.Y + height,
                    ClientRectangle.Width, ClientRectangle.Height - height);

                // Add the rectangle to the caption region, and
                // make this region the form's clipping region.
                clipRegion->Union(nonCaptionRect);
                this->Region = clipRegion;
            }

        }