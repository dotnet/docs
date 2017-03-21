        Image image = new Bitmap("InputColor.bmp");
        ImageAttributes imageAttributes = new ImageAttributes();
        int width = image.Width;
        int height = image.Height;

        float[][] colorMatrixElements = { 
           new float[] {2,  0,  0,  0, 0},        // red scaling factor of 2
           new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
           new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
           new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
           new float[] {.2f, .2f, .2f, 0, 1}};    // three translations of 0.2

        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        imageAttributes.SetColorMatrix(
           colorMatrix,
           ColorMatrixFlag.Default,
           ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(image, 10, 10);

        e.Graphics.DrawImage(
           image,
           new Rectangle(120, 10, width, height),  // destination rectangle 
           0, 0,        // upper-left corner of source rectangle 
           width,       // width of source rectangle
           height,      // height of source rectangle
           GraphicsUnit.Pixel,
           imageAttributes);