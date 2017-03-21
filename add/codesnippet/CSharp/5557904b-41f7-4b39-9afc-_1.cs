        private void RenderText4(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text.", this.Font,
                new Rectangle(10, 10, 70, 70), SystemColors.ControlText, 
                SystemColors.ControlDark);
        }