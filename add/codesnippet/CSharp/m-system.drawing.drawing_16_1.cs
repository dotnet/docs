        protected override void OnPaint(PaintEventArgs e)
        {
                     
            //Draw ellipse using ColorBlend.
            Point startPoint2 = new Point(20, 110);
            Point endPoint2 = new Point(140, 110);
            Color[] myColors = {Color.Green,
                                   Color.Yellow,
                                   Color.Yellow,
                                   Color.Blue,
                                   Color.Red,
                                   Color.Red};
            float[] myPositions = {0.0f,.20f,.40f,.60f,.80f,1.0f};
            ColorBlend myBlend = new ColorBlend();
            myBlend.Colors = myColors;
            myBlend.Positions = myPositions;
            LinearGradientBrush lgBrush2 = new LinearGradientBrush(startPoint2,
                endPoint2,
                Color.Green,
                Color.Red);
            lgBrush2.InterpolationColors = myBlend;
            Rectangle ellipseRect2 = new Rectangle(20, 110, 120, 80);
            e.Graphics.FillEllipse(lgBrush2, ellipseRect2);
        }