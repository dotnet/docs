using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

public class class1
{
    // 06088b31-bac9-4ef3-9ebe-06c2c764d6df
    // How to: Fill a Shape with a Solid Color

    public void Method11(PaintEventArgs e)
    {
        // <snippet11>
        SolidBrush solidBrush = new SolidBrush(
           Color.FromArgb(255, 255, 0, 0));
        e.Graphics.FillEllipse(solidBrush, 0, 0, 100, 60);
        // </snippet11>
    }
    // 508da5a6-2433-4d2b-9680-eaeae4e96e3b
    // How to: Fill a Shape with an Image Texture

    public void Method21(PaintEventArgs e)
    {
        // <snippet21>
        Image image = new Bitmap("ImageFile.jpg");
        TextureBrush tBrush = new TextureBrush(image);
        tBrush.Transform = new Matrix(
           75.0f / 640.0f,
           0.0f,
           0.0f,
           75.0f / 480.0f,
           0.0f,
           0.0f);
        e.Graphics.FillEllipse(tBrush, new Rectangle(0, 150, 150, 250));
        // </snippet21>
    }
    // 6d407891-6e5c-4495-a546-3da5604e9fb8
    // How to: Tile a Shape with an Image

    public void Method31(PaintEventArgs e)
    {
        // <snippet31>
        Image image = new Bitmap("HouseAndTree.gif");
        TextureBrush tBrush = new TextureBrush(image);
        Pen blackPen = new Pen(Color.Black);
        e.Graphics.FillRectangle(tBrush, new Rectangle(0, 0, 200, 200));
        e.Graphics.DrawRectangle(blackPen, new Rectangle(0, 0, 200, 200));
        // </snippet31>
    }
    public void Method32(PaintEventArgs e)
    {
        // <snippet32>
        Image image = new Bitmap("HouseAndTree.gif");
        TextureBrush tBrush = new TextureBrush(image);
        Pen blackPen = new Pen(Color.Black);
        tBrush.WrapMode = WrapMode.TileFlipX;
        e.Graphics.FillRectangle(tBrush, new Rectangle(0, 0, 200, 200));
        e.Graphics.DrawRectangle(blackPen, new Rectangle(0, 0, 200, 200));
        // </snippet32>
    }
    public void Method33(PaintEventArgs e)
    {
        // <snippet33>
        Image image = new Bitmap("HouseAndTree.gif");
        TextureBrush tBrush = new TextureBrush(image);
        Pen blackPen = new Pen(Color.Black);
        tBrush.WrapMode = WrapMode.TileFlipY;
        e.Graphics.FillRectangle(tBrush, new Rectangle(0, 0, 200, 200));
        e.Graphics.DrawRectangle(blackPen, new Rectangle(0, 0, 200, 200));
        // </snippet33>
    }
    public void Method34(PaintEventArgs e)
    {
        // <snippet34>
        Image image = new Bitmap("HouseAndTree.gif");
        TextureBrush tBrush = new TextureBrush(image);
        Pen blackPen = new Pen(Color.Black);
        tBrush.WrapMode = WrapMode.TileFlipXY;
        e.Graphics.FillRectangle(tBrush, new Rectangle(0, 0, 200, 200));
        e.Graphics.DrawRectangle(blackPen, new Rectangle(0, 0, 200, 200));
        // </snippet34>
    }
    // 9c8300ff-187b-404f-af1f-ebd499f5b16f
    // How to: Fill a Shape with a Hatch Pattern

    public void Method41(PaintEventArgs e)
    {
        // <snippet41>
        HatchBrush hBrush = new HatchBrush(
           HatchStyle.Horizontal,
           Color.Red,
           Color.FromArgb(255, 128, 255, 255));
        e.Graphics.FillEllipse(hBrush, 0, 0, 100, 60);
        // </snippet41>
    }
}

