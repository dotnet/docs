    private void IconToBitmap(PaintEventArgs e)
    {
        // Construct an Icon.
        Icon icon1 = new Icon(SystemIcons.Exclamation, 40, 40);

        // Call ToBitmap to convert it.
        Bitmap bmp = icon1.ToBitmap();

        // Draw the bitmap.
        e.Graphics.DrawImage(bmp, new Point(30, 30));
    }