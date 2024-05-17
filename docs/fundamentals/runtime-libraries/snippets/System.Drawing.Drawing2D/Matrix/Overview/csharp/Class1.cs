using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    Pen myPen = Pens.Red;

    // 0659fe00-9e0c-41c4-9118-016f2404c905
    // Matrix Representation of Transformations

    public void Method11()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet11>
        Matrix myMatrix = new Matrix();
        myMatrix.Rotate(30);
        myMatrix.Scale(1, 2, MatrixOrder.Append);
        myMatrix.Translate(5, 0, MatrixOrder.Append);
        // </snippet11>
    }
    // b601d66d-d572-4f11-9d2e-92f0dc8893f3
    // Global and Local Transformations

    public void Method21()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet21>
        myGraphics.DrawEllipse(myPen, 0, 0, 100, 50);
        myGraphics.ScaleTransform(1, 0.5f);
        myGraphics.TranslateTransform(50, 0, MatrixOrder.Append);
        myGraphics.RotateTransform(30, MatrixOrder.Append);
        myGraphics.DrawEllipse(myPen, 0, 0, 100, 50);
        // </snippet21>
    }
    public void Method22()
    {
        Graphics myGraphics = this.CreateGraphics();
        GraphicsPath myGraphicsPath = new GraphicsPath();
        // <snippet22>
        Matrix myMatrix = new Matrix();
        myMatrix.Rotate(45);
        myGraphicsPath.Transform(myMatrix);
        myGraphics.DrawRectangle(myPen, 10, 10, 100, 50);
        myGraphics.DrawPath(myPen, myGraphicsPath);
        // </snippet22>
    }
    public void Method23()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet23>
        Matrix myMatrix = new Matrix(1, 0, 0, -1, 0, 0);
        myGraphics.Transform = myMatrix;
        myGraphics.TranslateTransform(200, 150, MatrixOrder.Append);
        // </snippet23>
    }
    public void Method24()
    {
        Graphics myGraphics = this.CreateGraphics();
        SolidBrush mySolidBrush1 = new SolidBrush(Color.Red);
        SolidBrush mySolidBrush2 = new SolidBrush(Color.Black);
        // <snippet24>
        // Create the path.
        GraphicsPath myGraphicsPath = new GraphicsPath();
        Rectangle myRectangle = new Rectangle(0, 0, 60, 60);
        myGraphicsPath.AddRectangle(myRectangle);

        // Fill the path on the new coordinate system.
        // No local transformation
        myGraphics.FillPath(mySolidBrush1, myGraphicsPath);

        // Set the local transformation of the GraphicsPath object.
        Matrix myPathMatrix = new Matrix();
        myPathMatrix.Scale(2, 1);
        myPathMatrix.Rotate(30, MatrixOrder.Append);
        myGraphicsPath.Transform(myPathMatrix);

        // Fill the transformed path on the new coordinate system.
        myGraphics.FillPath(mySolidBrush2, myGraphicsPath);
        // </snippet24>
    }
    // c61ff50a-eb1d-4e6c-83cd-f7e9764cfa9f
    // Types of Coordinate Systems

    public void Method31()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet31>
        myGraphics.TranslateTransform(100, 50);
        myGraphics.DrawLine(myPen, 0, 0, 160, 80);
        // </snippet31>
    }
    public void Method32()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet32>
        myGraphics.PageUnit = GraphicsUnit.Inch;
        myGraphics.DrawLine(myPen, 0, 0, 2, 1);
        // </snippet32>
    }
    public void Method33()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet33>
        Pen myPen = new Pen(Color.Black, 1 / myGraphics.DpiX);
        // </snippet33>
    }
    public void Method34()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet34>
        myGraphics.TranslateTransform(2, 0.5f);
        myGraphics.PageUnit = GraphicsUnit.Inch;
        myGraphics.DrawLine(myPen, 0, 0, 2, 1);
        // </snippet34>
    }
}
