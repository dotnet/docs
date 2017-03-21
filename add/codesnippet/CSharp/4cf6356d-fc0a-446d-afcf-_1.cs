        // Handle the timer tick; draw each progressively larger rectangle.
        private void progressTimer_Tick(Object myObject, EventArgs e)
        {
            if (ticks < NumberChunks)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    ProgressBarRenderer.DrawVerticalChunks(g,
                        progressBarRectangles[ticks]);
                    ticks++;
                }
            }
            else
            {
                progressTimer.Enabled = false;
            }
        }