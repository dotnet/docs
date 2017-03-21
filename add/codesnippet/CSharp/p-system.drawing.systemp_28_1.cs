        private void DrawWithInactiveCaptionTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.InactiveCaptionText, rectangle1);
        }