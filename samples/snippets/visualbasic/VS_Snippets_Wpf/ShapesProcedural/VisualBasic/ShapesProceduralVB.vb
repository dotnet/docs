Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation
Imports System.Threading

Namespace SDKSample

    Public Class ShapesProceduralVB
        Inherits Page

        Public Sub New()

            WindowTitle = "Shapes Sample"
            Background = Brushes.LightSlateGray

            ' Add a Border
            Dim myBorder As New Border()
            myBorder.BorderBrush = Brushes.Black
            myBorder.BorderThickness = New Thickness(2)
            myBorder.Width = 400
            myBorder.Height = 600
            myBorder.Padding = New Thickness(15)
            myBorder.Background = Brushes.White

            ' Create a Grid to host the Shapes
            Dim myGrid As New Grid()
            myGrid.Margin = New Thickness(2)
            Dim myColDef1 As New ColumnDefinition()
            myColDef1.Width = New GridLength(125)
            Dim myColDef2 As New ColumnDefinition()
            myColDef2.Width = New GridLength(1, GridUnitType.Star)
            myGrid.ColumnDefinitions.Add(myColDef1)
            myGrid.ColumnDefinitions.Add(myColDef2)
            Dim myRowDef As New RowDefinition()
            Dim myRowDef1 As New RowDefinition()
            Dim myRowDef2 As New RowDefinition()
            Dim myRowDef3 As New RowDefinition()
            Dim myRowDef4 As New RowDefinition()
            Dim myRowDef5 As New RowDefinition()
            Dim myRowDef6 As New RowDefinition()
            myGrid.RowDefinitions.Add(myRowDef)
            myGrid.RowDefinitions.Add(myRowDef1)
            myGrid.RowDefinitions.Add(myRowDef2)
            myGrid.RowDefinitions.Add(myRowDef3)
            myGrid.RowDefinitions.Add(myRowDef4)
            myGrid.RowDefinitions.Add(myRowDef5)
            myGrid.RowDefinitions.Add(myRowDef6)
            Dim myTextBlock As New TextBlock()
            myTextBlock.FontSize = 20
            myTextBlock.Text = "WPF Shapes Gallery"
            myTextBlock.HorizontalAlignment = Windows.HorizontalAlignment.Left
            myTextBlock.VerticalAlignment = Windows.VerticalAlignment.Center
            myGrid.Children.Add(myTextBlock)
            Grid.SetRow(myTextBlock, 0)
            Grid.SetColumnSpan(myTextBlock, 2)

            '<SnippetShapesProceduralRectangle>

            'Add a Rectangle Element
            Dim myRect As New Rectangle()
            myRect.Stroke = Brushes.Black
            myRect.Stroke = Brushes.Black
            myRect.Fill = Brushes.SkyBlue
            myRect.HorizontalAlignment = HorizontalAlignment.Left
            myRect.VerticalAlignment = VerticalAlignment.Center
            myRect.Height = 50
            myRect.Width = 50
            myGrid.Children.Add(myRect)
            '</SnippetShapesProceduralRectangle>
            Grid.SetRow(myRect, 1)
            Grid.SetColumn(myRect, 0)
            Dim myTextBlock1 As New TextBlock()
            myTextBlock1.FontSize = 14
            myTextBlock1.Text = "A Rectangle Element"
            myTextBlock1.VerticalAlignment = VerticalAlignment.Center
            myGrid.Children.Add(myTextBlock1)
            Grid.SetRow(myTextBlock1, 1)
            Grid.SetColumn(myTextBlock1, 1)

            '<SnippetShapesProceduralEllipse>

            ' Add an Ellipse
            Dim myEllipse As New Ellipse()
            myEllipse.Stroke = Brushes.Black
            myEllipse.Fill = Brushes.DarkBlue
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left
            myEllipse.VerticalAlignment = VerticalAlignment.Center
            myEllipse.Width = 50
            myEllipse.Height = 75
            myGrid.Children.Add(myEllipse)
            '</SnippetShapesProceduralEllipse>
            Grid.SetRow(myEllipse, 2)
            Grid.SetColumn(myEllipse, 0)
            Dim myTextBlock2 As New TextBlock()
            myTextBlock2.FontSize = 14
            myTextBlock2.Text = "An Ellipse Element"
            myTextBlock2.VerticalAlignment = VerticalAlignment.Center
            myGrid.Children.Add(myTextBlock2)
            Grid.SetRow(myTextBlock2, 2)
            Grid.SetColumn(myTextBlock2, 1)


            '<SnippetShapesProceduralLine>

            ' Add a Line Element
            Dim myLine As New Line()
            myLine.Stroke = Brushes.LightSteelBlue
            myLine.X1 = 1
            myLine.X2 = 50
            myLine.Y1 = 1
            myLine.Y2 = 50
            myLine.HorizontalAlignment = HorizontalAlignment.Left
            myLine.VerticalAlignment = VerticalAlignment.Center
            myLine.StrokeThickness = 2
            myGrid.Children.Add(myLine)
            '</SnippetShapesProceduralLine>
            Grid.SetRow(myLine, 3)
            Grid.SetColumn(myLine, 0)
            Dim myTextBlock3 As New TextBlock()
            myTextBlock3.FontSize = 14
            myTextBlock3.Text = "A Line Element"
            myTextBlock3.VerticalAlignment = VerticalAlignment.Center
            myGrid.Children.Add(myTextBlock3)
            Grid.SetRow(myTextBlock3, 3)
            Grid.SetColumn(myTextBlock3, 1)

            '<SnippetShapesProceduralPath>

            ' Add a Path Element
            Dim myPath As New Path()
            myPath.Stroke = Brushes.Black
            myPath.Fill = Brushes.MediumSlateBlue
            myPath.StrokeThickness = 4
            myPath.HorizontalAlignment = HorizontalAlignment.Left
            myPath.VerticalAlignment = VerticalAlignment.Center
            Dim myEllipseGeometry As New EllipseGeometry()
            myEllipseGeometry.Center = New System.Windows.Point(50, 50)
            myEllipseGeometry.RadiusX = 25
            myEllipseGeometry.RadiusY = 25
            myPath.Data = myEllipseGeometry
            myGrid.Children.Add(myPath)
            '</SnippetShapesProceduralPath>
            Grid.SetRow(myPath, 4)
            Grid.SetColumn(myPath, 0)
            Dim myTextBlock4 As New TextBlock()
            myTextBlock4.FontSize = 14
            myTextBlock4.Text = "A Path Element"
            myTextBlock4.VerticalAlignment = VerticalAlignment.Center
            myGrid.Children.Add(myTextBlock4)
            Grid.SetRow(myTextBlock4, 4)
            Grid.SetColumn(myTextBlock4, 1)

            '<SnippetShapesProceduralPolygon>

            ' Add a Polygon Element
            Dim myPolygon As New Polygon()
            myPolygon.Stroke = Brushes.Black
            myPolygon.Fill = Brushes.LightSeaGreen
            myPolygon.StrokeThickness = 2
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left
            myPolygon.VerticalAlignment = VerticalAlignment.Center
            Dim Point1 As New System.Windows.Point(1, 50)
            Dim Point2 As New System.Windows.Point(10, 80)
            Dim Point3 As New System.Windows.Point(50, 50)
            Dim myPointCollection As New PointCollection()
            myPointCollection.Add(Point1)
            myPointCollection.Add(Point2)
            myPointCollection.Add(Point3)
            myPolygon.Points = myPointCollection
            myGrid.Children.Add(myPolygon)
            '</SnippetShapesProceduralPolygon>
            Grid.SetRow(myPolygon, 5)
            Grid.SetColumn(myPolygon, 0)
            Dim myTextBlock5 As New TextBlock()
            myTextBlock5.Text = "A Polygon Element"
            myTextBlock5.FontSize = 14
            myTextBlock5.VerticalAlignment = VerticalAlignment.Center
            myGrid.Children.Add(myTextBlock5)
            Grid.SetRow(myTextBlock5, 5)
            Grid.SetColumn(myTextBlock5, 1)

            '<SnippetShapesProceduralPolyline>

            ' Add a Polyline Element
            Dim myPolyline As New Polyline()
            myPolyline.Stroke = Brushes.SlateGray
            myPolyline.StrokeThickness = 2
            myPolyline.FillRule = FillRule.EvenOdd
            Dim Point4 As New System.Windows.Point(1, 50)
            Dim Point5 As New System.Windows.Point(10, 80)
            Dim Point6 As New System.Windows.Point(20, 40)
            Dim myPointCollection2 As New PointCollection()
            myPointCollection2.Add(Point4)
            myPointCollection2.Add(Point5)
            myPointCollection2.Add(Point6)
            myPolyline.Points = myPointCollection2
            myGrid.Children.Add(myPolyline)
            '</SnippetShapesProceduralPolyline>
            Grid.SetRow(myPolyline, 6)
            Grid.SetColumn(myPolyline, 0)
            Dim myTextBlock6 As New TextBlock()
            myTextBlock6.FontSize = 14
            myTextBlock6.Text = "A Polyline Element"
            myTextBlock6.VerticalAlignment = VerticalAlignment.Center
            myGrid.Children.Add(myTextBlock6)
            Grid.SetRow(myTextBlock6, 6)
            Grid.SetColumn(myTextBlock6, 1)

            ' Add the Grid as the single child of the Border
            myBorder.Child = myGrid
            ' Add the Border as the Window Content
            Me.Content = myBorder
        End Sub
    End Class
    'Displays the Sample
    Public Class app
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()
        End Sub

        Private Sub CreateAndShowMainWindow()
            ' Create the application's main window.
            Dim myWindow As New NavigationWindow()
            ' Display the sample
            Dim myContent As New ShapesProceduralVB()
            myWindow.Navigate(myContent)
            MainWindow = myWindow
            myWindow.Show()
        End Sub
    End Class
    ' Starts the application.
    Public NotInheritable Class EntryClass

        Public Shared Sub Main()
            Dim app As New app()
            app.Run()
        End Sub
    End Class
End Namespace

