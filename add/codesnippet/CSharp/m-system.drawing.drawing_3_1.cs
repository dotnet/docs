        public void MatrixShearExample(PaintEventArgs e)
        {
            Matrix myMatrix = new Matrix();
            myMatrix.Shear(2, 0);
            e.Graphics.DrawRectangle(new Pen(Color.Green), 0, 0, 100, 50);
            e.Graphics.MultiplyTransform(myMatrix);
            e.Graphics.DrawRectangle(new Pen(Color.Red), 0, 0, 100, 50);
            e.Graphics.DrawEllipse(new Pen(Color.Blue), 0, 0, 100, 50);
        }