Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace Microsoft.Samples.BrushExamples

	Public Class ViewboxExample
		Inherits Page


		Public Sub New()

			' Create the main panel.
			Dim mainPanel As New StackPanel()
			mainPanel.Orientation = Orientation.Horizontal
			createViewboxExample(mainPanel)
			Me.Content = mainPanel
		End Sub


		Private Sub createViewboxExample(ByVal mainPanel As Panel)


            Dim rectangleBorder As New Border()
            With rectangleBorder
                .BorderBrush = Brushes.Black
                .BorderThickness = New Thickness(1)
                .VerticalAlignment = VerticalAlignment.Top
                .Margin = New Thickness(0, 0, 10, 0)
            End With

            ' <SnippetGraphicsMMTileBrushViewboxWithStretchTiling>
            ' Create a rectangle.
            Dim myRectangle As New Rectangle()
            myRectangle.Width = 100
            myRectangle.Height = 100

            ' Load the image.
            Dim theImage As New BitmapImage(New Uri("sampleImages\testImage.gif", UriKind.Relative))
            Dim myImageBrush As New ImageBrush(theImage)
            With myImageBrush
                .Viewbox = New Rect(0.5, 0.25, 0.25, 0.5)
                .ViewboxUnits = BrushMappingMode.RelativeToBoundingBox
                .Viewport = New Rect(0, 0, 0.25, 0.25)
                .ViewportUnits = BrushMappingMode.RelativeToBoundingBox
                .TileMode = TileMode.Tile
                .Stretch = Stretch.Fill
                .AlignmentX = AlignmentX.Center
                .AlignmentY = AlignmentY.Center
            End With

            ' Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush
            ' </SnippetGraphicsMMTileBrushViewboxWithStretchTiling>

            rectangleBorder.Child = myRectangle
            mainPanel.Children.Add(rectangleBorder)

		End Sub


	End Class

End Namespace