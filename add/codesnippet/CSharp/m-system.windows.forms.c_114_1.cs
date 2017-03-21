    // Demonstrates SetImage, ContainsImage, and GetImage.
    public System.Drawing.Image SwapClipboardImage(
        System.Drawing.Image replacementImage)
    {
        System.Drawing.Image returnImage = null;
        if (Clipboard.ContainsImage())
        {
            returnImage = Clipboard.GetImage();
            Clipboard.SetImage(replacementImage);
        }
        return returnImage;
    }