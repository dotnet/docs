using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Ink;

public partial class Window1 : Window
{

    public Window1()
    {
        InitializeComponent();
    }

    //<Snippet2>
    // Button.Click event handler that rotates the strokes
    // and copies them to a Canvas.
    private void button_Click(object sender, RoutedEventArgs e)
    {
        StrokeCollection copiedStrokes = inkCanvas1.Strokes.Clone();
        Matrix rotatingMatrix = new Matrix();
        double canvasLeft = Canvas.GetLeft(inkCanvas1);
        double canvasTop = Canvas.GetTop(inkCanvas1);
        Point rotatePoint = new Point(canvas1.Width / 2, canvas1.Height / 2);

        rotatingMatrix.RotateAt(90, rotatePoint.X, rotatePoint.Y);
        copiedStrokes.Transform(rotatingMatrix, false);
        inkPresenter1.Strokes = copiedStrokes;

    }
    //</Snippet2>
}


