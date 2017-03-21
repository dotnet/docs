        // Initialize the rectangles used to paint the states of the
        // progress bar.
    private:
        void SetupProgressBar()
        {
            if (!ProgressBarRenderer::IsSupported)
            {
                return;
            }

            // Determine the size of the progress bar frame.
            this->Size = System::Drawing::Size(ClientRectangle.Width,
                (NumberChunks * (ProgressBarRenderer::ChunkThickness + 
                (2 * ProgressBarRenderer::ChunkSpaceThickness))) + 6);

            // Initialize the rectangles to draw each step of the
            // progress bar.
            progressBarRectangles = gcnew array<Rectangle>(NumberChunks);

            for (int i = 0; i < NumberChunks; i++)
            {
                // Use the thickness defined by the current visual style
                // to calculate the height of each rectangle. The size
                // adjustments ensure that the chunks do not paint over
                // the frame.

                int filledRectangleHeight = 
					((i + 1) * (ProgressBarRenderer::ChunkThickness +
					(2 * ProgressBarRenderer::ChunkSpaceThickness)));

                progressBarRectangles[i] = Rectangle(
                    ClientRectangle.X + 3,
                    ClientRectangle.Y + ClientRectangle.Height - 3
					- filledRectangleHeight,
                    ClientRectangle.Width - 6,
                    filledRectangleHeight);
            }
        }