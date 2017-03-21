        private void AddSizes(PaintEventArgs e)
        {
            Size size1 = new Size(100, 100);
            Size size2 = new Size(50,50);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(10,10), size1));
            size1 = Size.Add(size1, size2);
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(new Point(10, 10), size1));
        }