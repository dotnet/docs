Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace Microsoft.Samples.BrushExamples

	Public Class TileSizeExample
		Inherits Page


		Public Sub New()

			' Create the main panel.
			Dim mainPanel As New StackPanel()
			mainPanel.Orientation = Orientation.Horizontal
			createRelativeTileSizeExample(mainPanel)
			createAbsoluteTileSizeExample(mainPanel)
			Me.Content = mainPanel


		End Sub


		Private Sub createRelativeTileSizeExample(ByVal mainPanel As Panel)


            Dim rectangleBorder As New Border()
            With rectangleBorder
                .BorderBrush = Brushes.Black
                .BorderThickness = New Thickness(1)
                .VerticalAlignment = VerticalAlignment.Top
                .Margin = New Thickness(0, 0, 10, 0)
            End With

            ' <SnippetGraphicsMMRelativeViewportUnitsExample1>
            ' Create a rectangle.
            Dim myRectangle As New Rectangle()
            myRectangle.Width = 50
            myRectangle.Height = 100

            ' Load the image.
            Dim theImage As New BitmapImage(New Uri("sampleImages\cherries_larger.jpg", UriKind.Relative))
            Dim myImageBrush As New ImageBrush(theImage)

            ' Create tiles that are 1/4 the size of 
            ' the output area.
            myImageBrush.Viewport = New Rect(0, 0, 0.25, 0.25)
            myImageBrush.ViewportUnits = BrushMappingMode.RelativeToBoundingBox

            ' Set the tile mode to Tile.
            myImageBrush.TileMode = TileMode.Tile

            ' Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush
            ' </SnippetGraphicsMMRelativeViewportUnitsExample1>

            rectangleBorder.Child = myRectangle
            mainPanel.Children.Add(rectangleBorder)

		End Sub

		Private Sub createAbsoluteTileSizeExample(ByVal mainPanel As Panel)


            Dim rectangleBorder As New Border()
            With rectangleBorder
                .BorderBrush = Brushes.Black
                .BorderThickness = New Thickness(1)
                .VerticalAlignment = VerticalAlignment.Top
                .Margin = New Thickness(0, 0, 10, 0)
            End With

            ' <SnippetGraphicsMMAbsoluteViewportUnitsExample1>
            ' Create a rectangle.
            Dim myRectangle As New Rectangle()
            myRectangle.Width = 50
            myRectangle.Height = 100

            ' Load the image.       
            Dim theImage As New BitmapImage(New Uri("sampleImages\cherries_larger.jpg", UriKind.Relative))
            Dim myImageBrush As New ImageBrush(theImage)

            ' Create tiles that are 25 x 25, regardless of the size
            ' of the output area.
            myImageBrush.Viewport = New Rect(0, 0, 25, 25)
            myImageBrush.ViewportUnits = BrushMappingMode.Absolute

            ' Set the tile mode to Tile.
            myImageBrush.TileMode = TileMode.Tile

            ' Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush
            ' </SnippetGraphicsMMAbsoluteViewportUnitsExample1>

            rectangleBorder.Child = myRectangle
            mainPanel.Children.Add(rectangleBorder)

		End Sub

	End Class

End Namespace