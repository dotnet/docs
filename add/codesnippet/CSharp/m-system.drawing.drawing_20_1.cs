        public void BlendConstExample(PaintEventArgs e)
        {
                     
            //Draw ellipse using Blend.
            Point startPoint2 = new Point(20, 110);
            Point endPoint2 = new Point(140, 110);
            float[] myFactors = {.2f,.4f,.8f,.8f,.4f,.2f};
            float[] myPositions = {0.0f,.2f,.4f,.6f,.8f,1.0f};
            Blend myBlend = new Blend();
            myBlend.Factors = myFactors;
            myBlend.Positions = myPositions;
            LinearGradientBrush lgBrush2 = new LinearGradientBrush(
                startPoint2,
                endPoint2,
                Color.Blue,
                Color.Red);
            lgBrush2.Blend = myBlend;
            Rectangle ellipseRect2 = new Rectangle(20, 110, 120, 80);
            e.Graphics.FillEllipse(lgBrush2, ellipseRect2);
                     
            // End example.
        }