        private void RenderText6(PaintEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Bottom | TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(e.Graphics, "This is some text that will be clipped at the end.", this.Font,
                new Rectangle(10, 10, 100, 50), SystemColors.ControlText, flags);
        }