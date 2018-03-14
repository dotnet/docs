using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Imaging;


public class SystemDrawingRecoloringImages
{

    // 2106fb9a-4d60-4dcf-9220-9f189a6c4d19
    // How to: Translate Image Colors

    private void Method11(PaintEventArgs e)
    {
        // <snippet11>
        Image image = new Bitmap("ColorBars.bmp");
        ImageAttributes imageAttributes = new ImageAttributes();
        int width = image.Width;
        int height = image.Height;

        float[][] colorMatrixElements = { 
           new float[] {1,  0,  0,  0, 0},
           new float[] {0,  1,  0,  0, 0},
           new float[] {0,  0,  1,  0, 0},
           new float[] {0,  0,  0,  1, 0},
           new float[] {.75f, 0, 0, 0, 1}};

        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        imageAttributes.SetColorMatrix(
           colorMatrix,
           ColorMatrixFlag.Default,
           ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(image, 10, 10, width, height);

        e.Graphics.DrawImage(
           image,
           new Rectangle(150, 10, width, height),  // destination rectangle 
           0, 0,        // upper-left corner of source rectangle 
           width,       // width of source rectangle
           height,      // height of source rectangle
           GraphicsUnit.Pixel,
           imageAttributes);
        // </snippet11>
    }
    // 44df4556-a433-49c0-ac0f-9a12063a5860
    // How to: Use a Color Matrix to Transform a Single Color

    private void Method21(PaintEventArgs e)
    {
        // <snippet21>
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
        // </snippet21>
    }
    // 977df1ce-8665-42d4-9fb1-ef7f0ff63419
    // How to: Use a Color Remap Table

    private void Method31(PaintEventArgs e)
    {
        // <snippet31>
        Image image = new Bitmap("RemapInput.bmp");
        ImageAttributes imageAttributes = new ImageAttributes();
        int width = image.Width;
        int height = image.Height;
        ColorMap colorMap = new ColorMap();

        colorMap.OldColor = Color.FromArgb(255, 255, 0, 0);  // opaque red
        colorMap.NewColor = Color.FromArgb(255, 0, 0, 255);  // opaque blue

        ColorMap[] remapTable = { colorMap };

        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(image, 10, 10, width, height);

        e.Graphics.DrawImage(
           image,
           new Rectangle(150, 10, width, height),  // destination rectangle 
           0, 0,        // upper-left corner of source rectangle 
           width,       // width of source rectangle
           height,      // height of source rectangle
           GraphicsUnit.Pixel,
           imageAttributes);
        // </snippet31>
    }
    // df23c887-7fd6-4b15-ad94-e30b5bd4b849
    // Using Transformations to Scale Colors

    private void Method41(PaintEventArgs e)
    {
        // <snippet41>
        Image image = new Bitmap("ColorBars2.bmp");
        ImageAttributes imageAttributes = new ImageAttributes();
        int width = image.Width;
        int height = image.Height;

        float[][] colorMatrixElements = { 
           new float[] {1,  0,  0,  0, 0},
           new float[] {0,  1,  0,  0, 0},
           new float[] {0,  0,  2,  0, 0},
           new float[] {0,  0,  0,  1, 0},
           new float[] {0, 0, 0, 0, 1}};

        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        imageAttributes.SetColorMatrix(
           colorMatrix,
           ColorMatrixFlag.Default,
           ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(image, 10, 10, width, height);

        e.Graphics.DrawImage(
           image,
           new Rectangle(150, 10, width, height),  // destination rectangle 
           0, 0,        // upper-left corner of source rectangle 
           width,       // width of source rectangle
           height,      // height of source rectangle
           GraphicsUnit.Pixel,
           imageAttributes);
        // </snippet41>
    }
    private void Method42(PaintEventArgs e)
    {
        // <snippet42>
        Image image = new Bitmap("ColorBars.bmp");
        ImageAttributes imageAttributes = new ImageAttributes();
        int width = image.Width;
        int height = image.Height;

        float[][] colorMatrixElements = { 
           new float[] {.75F,  0,  0,  0, 0},
           new float[] {0,  .65F,  0,  0, 0},
           new float[] {0,  0,  .5F,  0, 0},
           new float[] {0,  0,  0,  1F, 0},
           new float[] {0, 0, 0, 0, 1F}};

        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        imageAttributes.SetColorMatrix(
           colorMatrix,
           ColorMatrixFlag.Default,
           ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(image, 10, 10, width, height);

        e.Graphics.DrawImage(
           image,
           new Rectangle(150, 10, width, height),  // destination rectangle 
           0, 0,        // upper-left corner of source rectangle 
           width,       // width of source rectangle
           height,      // height of source rectangle
           GraphicsUnit.Pixel,
           imageAttributes);
        // </snippet42>
    }
}

