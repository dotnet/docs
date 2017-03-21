    public bool ThumbnailCallback()
    {
        return false;
    }
    public void Example_GetThumb(PaintEventArgs e)
    {
        Image.GetThumbnailImageAbort myCallback =
        new Image.GetThumbnailImageAbort(ThumbnailCallback);
        Bitmap myBitmap = new Bitmap("Climber.jpg");
        Image myThumbnail = myBitmap.GetThumbnailImage(
        40, 40, myCallback, IntPtr.Zero);
        e.Graphics.DrawImage(myThumbnail, 150, 75);
    }