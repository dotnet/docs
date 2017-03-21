        private void RenderText1(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text", this.Font, 
                new Point(10, 10), SystemColors.ControlText);

        }