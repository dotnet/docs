    private void Button2_Click(System.Object sender, System.EventArgs e)
    {

        Bitmap bitmap1 = Bitmap.FromHicon(SystemIcons.Hand.Handle);
        Graphics formGraphics = this.CreateGraphics();
        GraphicsUnit units = GraphicsUnit.Point;

        RectangleF bmpRectangleF = bitmap1.GetBounds(ref units);
        Rectangle bmpRectangle = Rectangle.Round(bmpRectangleF);
        formGraphics.DrawRectangle(Pens.Blue, bmpRectangle);
        formGraphics.Dispose();
    }