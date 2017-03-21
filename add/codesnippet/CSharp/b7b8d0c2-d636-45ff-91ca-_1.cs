        private void RenderText2(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text", this.Font,
                new Rectangle(10, 10, 100, 100), SystemColors.ControlText);

        }