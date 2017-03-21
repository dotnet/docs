        private void MeasureText1(PaintEventArgs e)
        {
            String text1 = "Measure this text";
            Font arialBold = new Font("Arial", 12.0F);
            Size textSize = TextRenderer.MeasureText(text1, arialBold);
            TextRenderer.DrawText(e.Graphics, text1, arialBold, 
                new Rectangle(new Point(10, 10), textSize), Color.Red);  
        }