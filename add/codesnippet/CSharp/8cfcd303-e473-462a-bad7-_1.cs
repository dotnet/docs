        public void ConstructAdjArrowCap2(PaintEventArgs e)
        {     
            AdjustableArrowCap myArrow = new AdjustableArrowCap(6, 6, false);
            Pen capPen = new Pen(Color.Black);
            capPen.CustomStartCap = myArrow;
            capPen.CustomEndCap = myArrow;
            e.Graphics.DrawLine(capPen, 50, 50, 200, 50);
        }