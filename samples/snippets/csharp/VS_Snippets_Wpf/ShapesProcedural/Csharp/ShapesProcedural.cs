
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;

namespace ShapesProcedural
{
    public class app : Application
    {
        Border myBorder;
        System.Windows.Shapes.Rectangle myRect;
        Ellipse myEllipse;
        Line myLine;
        Path myPath;
        Polygon myPolygon;
        Polyline myPolyline;
        Grid myGrid;
        TextBlock myTextBlock;
        ColumnDefinition myColDef1;
        ColumnDefinition myColDef2;
        RowDefinition myRowDef;
        RowDefinition myRowDef1;
        RowDefinition myRowDef2;
        RowDefinition myRowDef3;
        RowDefinition myRowDef4;
        RowDefinition myRowDef5;
        RowDefinition myRowDef6;
        Window myWindow;

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        private void CreateAndShowMainWindow()
        {
            // Create the application's main window
            myWindow = new Window ();

            // Add a Border
            myBorder = new Border();
            myBorder.BorderBrush = System.Windows.Media.Brushes.Black;
            myBorder.BorderThickness = new Thickness(2);
            myBorder.Width = 400;
            myBorder.Height = 600;
            myBorder.Padding = new Thickness(15);
            myBorder.Background = System.Windows.Media.Brushes.White;

            // Create a Grid to host the Shapes
            myGrid = new Grid();
            myGrid.Margin = new Thickness(15);
            myColDef1 = new ColumnDefinition();
            myColDef1.Width = new GridLength(125);
            myColDef2 = new ColumnDefinition();
            myColDef2.Width = new GridLength(1, GridUnitType.Star);
            myGrid.ColumnDefinitions.Add(myColDef1);
            myGrid.ColumnDefinitions.Add(myColDef2);
            myRowDef = new RowDefinition();
            myRowDef1 = new RowDefinition();
            myRowDef2 = new RowDefinition();
            myRowDef3 = new RowDefinition();
            myRowDef4 = new RowDefinition();
            myRowDef5 = new RowDefinition();
            myRowDef6 = new RowDefinition();
            myGrid.RowDefinitions.Add(myRowDef);
            myGrid.RowDefinitions.Add(myRowDef1);
            myGrid.RowDefinitions.Add(myRowDef2);
            myGrid.RowDefinitions.Add(myRowDef3);
            myGrid.RowDefinitions.Add(myRowDef4);
            myGrid.RowDefinitions.Add(myRowDef5);
            myGrid.RowDefinitions.Add(myRowDef6);
            myTextBlock = new TextBlock();
            myTextBlock.FontSize = 20;
            myTextBlock.Text = "WPF Shapes Gallery";
            myTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
            myTextBlock.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myTextBlock);
            Grid.SetRow(myTextBlock, 0);
            Grid.SetColumnSpan(myTextBlock, 2);

            //<SnippetShapesProceduralRectangle>

            // Add a Rectangle Element
            myRect = new System.Windows.Shapes.Rectangle();
            myRect.Stroke = System.Windows.Media.Brushes.Black;
            myRect.Fill = System.Windows.Media.Brushes.SkyBlue;
            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;
            myRect.Height = 50;
            myRect.Width = 50;
            myGrid.Children.Add(myRect);
            //</SnippetShapesProceduralRectangle>
            Grid.SetRow(myRect, 1);
            Grid.SetColumn(myRect, 0);
            TextBlock myTextBlock1 = new TextBlock();
            myTextBlock1.FontSize = 14;
            myTextBlock1.Text = "A Rectangle Element";
            myTextBlock1.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myTextBlock1);
            Grid.SetRow(myTextBlock1, 1);
            Grid.SetColumn(myTextBlock1, 1);

            //<SnippetShapesProceduralEllipse>

            // Add an Ellipse Element
            myEllipse = new Ellipse();
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            myEllipse.Fill = System.Windows.Media.Brushes.DarkBlue;
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            myEllipse.VerticalAlignment = VerticalAlignment.Center;
            myEllipse.Width = 50;
            myEllipse.Height = 75;
            myGrid.Children.Add(myEllipse);
            //</SnippetShapesProceduralEllipse>
            Grid.SetRow(myEllipse, 2);
            Grid.SetColumn(myEllipse, 0);
            TextBlock myTextBlock2 = new TextBlock();
            myTextBlock2.FontSize = 14;
            myTextBlock2.Text = "An Ellipse Element";
            myTextBlock2.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myTextBlock2);
            Grid.SetRow(myTextBlock2, 2);
            Grid.SetColumn(myTextBlock2, 1);

            //<SnippetShapesProceduralLine>

            // Add a Line Element
            myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = 1;
            myLine.X2 = 50;
            myLine.Y1 = 1;
            myLine.Y2 = 50;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
            //</SnippetShapesProceduralLine>
            Grid.SetRow(myLine, 3);
            Grid.SetColumn(myLine, 0);
            TextBlock myTextBlock3 = new TextBlock();
            myTextBlock3.FontSize = 14;
            myTextBlock3.Text = "A Line Element";
            myTextBlock3.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myTextBlock3);
            Grid.SetRow(myTextBlock3, 3);
            Grid.SetColumn(myTextBlock3, 1);

            //<SnippetShapesProceduralPath>

            //Add the Path Element
            myPath = new Path();
            myPath.Stroke = System.Windows.Media.Brushes.Black;
            myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
            myPath.StrokeThickness = 4;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new System.Windows.Point(50,50);
            myEllipseGeometry.RadiusX = 25;
            myEllipseGeometry.RadiusY = 25;
            myPath.Data = myEllipseGeometry;
            myGrid.Children.Add(myPath);
            //</SnippetShapesProceduralPath>
            Grid.SetRow(myPath, 4);
            Grid.SetColumn(myPath, 0);
            TextBlock myTextBlock4 = new TextBlock();
            myTextBlock4.FontSize = 14;
            myTextBlock4.Text = "A Path Element";
            myTextBlock4.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myTextBlock4);
            Grid.SetRow(myTextBlock4, 4);
            Grid.SetColumn(myTextBlock4, 1);

            //<SnippetShapesProceduralPolygon>

            //Add the Polygon Element
            myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(1, 50);
            System.Windows.Point Point2 = new System.Windows.Point(10,80);
            System.Windows.Point Point3 = new System.Windows.Point(50,50);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPolygon.Points = myPointCollection;
            myGrid.Children.Add(myPolygon);
            //</SnippetShapesProceduralPolygon>
            Grid.SetRow(myPolygon, 5);
            Grid.SetColumn(myPolygon, 0);
            TextBlock myTextBlock5 = new TextBlock();
            myTextBlock5.Text = "A Polygon Element";
            myTextBlock5.FontSize = 14;
            myTextBlock5.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myTextBlock5);
            Grid.SetRow(myTextBlock5, 5);
            Grid.SetColumn(myTextBlock5, 1);

            //<SnippetShapesProceduralPolyline>

            // Add the Polyline Element
            myPolyline = new Polyline();
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 2;
            myPolyline.FillRule = FillRule.EvenOdd;
            System.Windows.Point Point4 = new System.Windows.Point(1, 50);
            System.Windows.Point Point5 = new System.Windows.Point(10, 80);
            System.Windows.Point Point6 = new System.Windows.Point(20, 40);
            PointCollection myPointCollection2 = new PointCollection();
            myPointCollection2.Add(Point4);
            myPointCollection2.Add(Point5);
            myPointCollection2.Add(Point6);
            myPolyline.Points = myPointCollection2;
            myGrid.Children.Add(myPolyline);
            //</SnippetShapesProceduralPolyline>
            Grid.SetRow(myPolyline, 6);
            Grid.SetColumn(myPolyline, 0);
            TextBlock myTextBlock6 = new TextBlock();
            myTextBlock6.FontSize = 14;
            myTextBlock6.Text = "A Polyline Element";
            myTextBlock6.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myTextBlock6);
            Grid.SetRow(myTextBlock6, 6);
            Grid.SetColumn(myTextBlock6, 1);

            // Add the Grid to the Window as Content and show the Window
            myBorder.Child = myGrid;
            myWindow.Content = myBorder;
            myWindow.Background = System.Windows.Media.Brushes.LightSlateGray;
            myWindow.Title = "Shapes Sample";
            myWindow.Show();
        }
    }

    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main()
        {
            app app = new app();
            app.Run();
        }
    }
}