        public void IsOutlineVisibleExample(PaintEventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            Rectangle rect = new Rectangle(20, 20, 100, 100);
            myPath.AddRectangle(rect);
            Pen testPen = new Pen(Color.Black, 20);
            myPath.Widen(testPen);
            e.Graphics.FillPath(Brushes.Black, myPath);
            bool visible = myPath.IsOutlineVisible(100, 50, testPen,
                e.Graphics);
            MessageBox.Show("visible = " + visible.ToString());
        }