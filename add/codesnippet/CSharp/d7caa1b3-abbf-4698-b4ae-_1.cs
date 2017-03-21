        private void RenderText3(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text", this.Font,
                new Point(10, 10), Color.Red, Color.PowderBlue);
        }