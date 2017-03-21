using System;   
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HitTestSample_CS
{
    class HitTestSampleApp : Application
    {
        Window myWindow;
        Canvas myCanvas;
        InkCanvas inkCanvas1;
        Point[] myPoints;
        StackPanel buttonPanel;
        RadioButton rbClipWithRect;
        RadioButton rbclipWithPoints;
        RadioButton rbEraseWithRect;
        RadioButton rbEraseWithPoints;
        RadioButton rbEraseWithStylusShape;
        RadioButton rbChangeColorAtPoint;
        RadioButton rbChangeColorWithPoints;
        RadioButton rbChangeColorWithRect;
        RadioButton rbChangeColorWithStylusShape;

        protected override void OnStartup(StartupEventArgs e)
        {
            myWindow = new Window();
            myCanvas = new Canvas();
            myWindow.Content = myCanvas;

            inkCanvas1 = new InkCanvas();

            inkCanvas1.StrokeCollected +=
                new InkCanvasStrokeCollectedEventHandler(myIC_StrokeCollected);

            inkCanvas1.Background = Brushes.LightGray;

            inkCanvas1.SetValue(Canvas.TopProperty, 30d);
            inkCanvas1.SetValue(Canvas.LeftProperty, 30d);
            inkCanvas1.SetValue(Canvas.WidthProperty, 450d);
            inkCanvas1.SetValue(Canvas.HeightProperty, 400d);

            myCanvas.Children.Add(inkCanvas1);

            Rectangle box = new Rectangle();
            box.Height = 100;
            box.Width = 100;
            box.Stroke = Brushes.Black;
            InkCanvas.SetLeft(box, 100);
            InkCanvas.SetTop(box, 100);
            inkCanvas1.Children.Add(box);

            //add the stack panel and radio buttons;
            buttonPanel = new StackPanel();
            buttonPanel.Width = 200;
            buttonPanel.Height = 400;
            Canvas.SetLeft(buttonPanel, 500);
            Canvas.SetTop(buttonPanel, 30);

            myCanvas.Children.Add(buttonPanel);

            rbclipWithPoints = new RadioButton();
            rbclipWithPoints.Content = "ClipWithPoints";
            rbclipWithPoints.Click += new RoutedEventHandler(rbclipWithPoints_Click);
            buttonPanel.Children.Add(rbclipWithPoints);

            rbClipWithRect = new RadioButton();
            rbClipWithRect.Content = "ClipWithRect";
            rbClipWithRect.Click += new RoutedEventHandler(rbClipWithRect_Click);
            buttonPanel.Children.Add(rbClipWithRect);

            rbChangeColorWithStylusShape = new RadioButton();
            rbChangeColorWithStylusShape.Content = "ChangeColorWithStylusShape";
            rbChangeColorWithStylusShape.Click += new RoutedEventHandler(rbChangeColorWithStylusShape_Click);
            buttonPanel.Children.Add(rbChangeColorWithStylusShape);

            rbChangeColorWithRect = new RadioButton();
            rbChangeColorWithRect.Content = "ChangeColorWithRect";
            rbChangeColorWithRect.Click += new RoutedEventHandler(rbChangeColorWithRect_Click);
            buttonPanel.Children.Add(rbChangeColorWithRect);

            rbChangeColorWithPoints = new RadioButton();
            rbChangeColorWithPoints.Content = "ChangeColorWithPoints";
            rbChangeColorWithPoints.Click += new RoutedEventHandler(rbChangeColorWithPoints_Click);
            buttonPanel.Children.Add(rbChangeColorWithPoints);

            rbChangeColorAtPoint = new RadioButton();
            rbChangeColorAtPoint.Content = "ChangeColorAtPoint";
            rbChangeColorAtPoint.Click += new RoutedEventHandler(rbChangeColorAtPoint_Click);
            buttonPanel.Children.Add(rbChangeColorAtPoint);

            rbEraseWithStylusShape = new RadioButton();
            rbEraseWithStylusShape.Content = "EraseWithStylusShape";
            rbEraseWithStylusShape.Click += new RoutedEventHandler(rbEraseWithStylusShape_Click);
            buttonPanel.Children.Add(rbEraseWithStylusShape);

            rbEraseWithPoints = new RadioButton();
            rbEraseWithPoints.Content = "EraseWithPoints";
            rbEraseWithPoints.Click += new RoutedEventHandler(rbEraseWithPoints_Click);
            buttonPanel.Children.Add(rbEraseWithPoints);

            rbEraseWithRect = new RadioButton();
            rbEraseWithRect.Content = "EraseWithRect";
            rbEraseWithRect.Click += new RoutedEventHandler(rbEraseWithRect_Click);
            buttonPanel.Children.Add(rbEraseWithRect);

            myWindow.Show();
        }

        void rbEraseWithRect_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.EraseWithRect;
        }

        void rbEraseWithPoints_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.EraseWithPoints;
        }

        void rbEraseWithStylusShape_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.EraseWithStylusShape;
        }

        void rbChangeColorAtPoint_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.ChangeColorAtPoint;
        }

        void rbChangeColorWithPoints_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.ChangeColorWithPoints;
        }

        void rbChangeColorWithRect_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.ChangeColorWithRect;
        }

        void rbChangeColorWithStylusShape_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.ChangeColorWithStylusShape;
        }

        void rbclipWithPoints_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.ClipWithPoints;
        }

        void rbClipWithRect_Click(object sender, RoutedEventArgs e)
        {
            _hMode = hMode.ClipWithRect;
        }

         public enum hMode
         {
             ClipWithRect,
             ClipWithPoints,
             EraseWithRect,
             EraseWithPoints,
             EraseWithStylusShape,
             ChangeColorAtPoint,
             ChangeColorWithPoints,
             ChangeColorWithRect,
             ChangeColorWithStylusShape
         }

        hMode _hMode = hMode.ClipWithRect;

        void myIC_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            switch (_hMode)
            {
                case hMode.ChangeColorAtPoint:
                    ChangeColorAtPoint(e.Stroke);
                    break;

                case hMode.ChangeColorWithPoints:
                    ChangeColorWithPoints(e.Stroke);
                    break;

                case hMode.ChangeColorWithRect:
                    ChangeColorWithRect(e.Stroke);
                    break;

                case hMode.ChangeColorWithStylusShape:
                    ChangeColorWithStylusShape(e.Stroke);
                    break;

                case hMode.ClipWithPoints:
                    ClipWithPoints(e.Stroke);
                    break;

                case hMode.ClipWithRect:
                    ClipWithRect(e.Stroke);
                    break;

                case hMode.EraseWithPoints:
                    EraseWithPoints(e.Stroke);
                    break;

                case hMode.EraseWithRect:
                    EraseWithRect(e.Stroke);
                    break;

                case hMode.EraseWithStylusShape:
                    EraseWithStylusShape(e.Stroke);
                    break;
            }
        }


        private void ClipWithRect(Stroke aStroke)
        {
            //<Snippet5>
            Rect myRect = new Rect(100, 100, 100, 100);

            StrokeCollection clipResults = aStroke.GetClipResult(myRect);

            // inkCanvas1 is the InkCanvas on which we update the strokes
            inkCanvas1.Strokes.Remove(aStroke);
            inkCanvas1.Strokes.Add(clipResults);
            //</Snippet5>
        }

        void ClipWithPoints(Stroke aStroke)
        {
            //<Snippet6>
            Point[] myPoints = new Point[] {
                new Point(100, 100),
                new Point(200, 100),
                new Point(200, 200),
                new Point(100, 200)};

            StrokeCollection clipResults = aStroke.GetClipResult(myPoints);

            // inkCanvas1 is the InkCanvas on which we update the strokes
            inkCanvas1.Strokes.Remove(aStroke);
            inkCanvas1.Strokes.Add(clipResults);
            //</Snippet6>
        }

        void EraseWithRect(Stroke aStroke)
        {
            //<Snippet4>
            Rect myRect = new Rect(100, 100, 100, 100);

            StrokeCollection eraseResults = aStroke.GetEraseResult(myRect);

            // inkCanvas1 is the InkCanvas on which we update the strokes
            inkCanvas1.Strokes.Remove(aStroke);
            inkCanvas1.Strokes.Add(eraseResults);
            //</Snippet4>
        }

        void EraseWithPoints(Stroke aStroke)
        {
            // <Snippet1>
            Point[] myPoints = new Point[] {
                new Point(100, 100),
                new Point(200, 100),
                new Point(200, 200),
                new Point(100, 200)};

            StrokeCollection eraseResults = aStroke.GetEraseResult(myPoints);

            // inkCanvas1 is the InkCanvas on which we update the strokes
            inkCanvas1.Strokes.Remove(aStroke);
            inkCanvas1.Strokes.Add(eraseResults);
            //</Snippet1>
        }

        void EraseWithStylusShape(Stroke aStroke)
        {
            // <Snippet2>
            Point[] myPoints = new Point[] {
                new Point(100, 100),
                new	Point(200, 100),
                new	Point(200, 200),
                new	Point(100, 200)};

            EllipseStylusShape myStylus = new EllipseStylusShape(5.0, 5.0, 0.0);

            StrokeCollection eraseResults = aStroke.GetEraseResult(myPoints, myStylus);

            // inkCanvas1 is the InkCanvas on which we update the strokes
            inkCanvas1.Strokes.Remove(aStroke);
            inkCanvas1.Strokes.Add(eraseResults);
            // </Snippet2>
        }

        void ChangeColorAtPoint(Stroke myStroke)
        {
            // <Snippet3>
            Point myPoint = new Point(100, 100);

            if (myStroke.HitTest(myPoint, 10))
            {
                myStroke.DrawingAttributes.Color = Colors.Red;
            }
            // </Snippet3>
        }

        void ChangeColorWithPoints(Stroke aStroke)
        {
            //<Snippet7>
            Point[] myPoints = new Point[] {
                new Point(100, 100),
                new Point(200, 100),
                new Point(200, 200),
                new Point(100, 200)};

            if (aStroke.HitTest(myPoints, 80))
            {
                aStroke.DrawingAttributes.Color = Colors.Purple;
            }
            //</Snippet7>
        }

        void ChangeColorWithRect(Stroke aStroke)
        {

            //<Snippet8>
            Rect rect1 = new Rect(100, 100, 100, 100);

            if (aStroke.HitTest(rect1, 80))
            {
                aStroke.DrawingAttributes.Color = Colors.Purple;
            }
            //</Snippet8>
        }

        void ChangeColorWithStylusShape(Stroke aStroke)
        {
            //<Snippet9>
            Point[] myPoints = new Point[] {
                new Point(100, 100),
                new	Point(200, 100),
                new	Point(200, 200),
                new	Point(100, 200)};

            EllipseStylusShape myStylus = new EllipseStylusShape(5.0, 5.0, 0.0);

            if (aStroke.HitTest(myPoints, myStylus))
            {
                aStroke.DrawingAttributes.Color = Colors.Purple;
            }
            //</Snippet9>
        }

        [System.STAThread()]
        static void Main(string[] args)
        {
            new HitTestSampleApp().Run();
        }
    }
}
