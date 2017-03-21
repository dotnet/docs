        private void RenderText7(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "This is some text.", this.Font,
                new Point(10, 10), Color.White, Color.SteelBlue, TextFormatFlags.Default);
        }