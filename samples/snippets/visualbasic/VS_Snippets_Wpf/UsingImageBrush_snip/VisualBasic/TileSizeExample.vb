Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace Microsoft.Samples.Graphics.UsingImageBrush
	Public Class TileSizeExample
		Inherits Page
		Public Sub New()

			' <SnippetRelativeTileSizeExample>

			'
			' Create an ImageBrush and set the size of each
			' tile to 50% by 50% of the area being painted. 
			' 
			Dim relativeTileSizeImageBrush As New ImageBrush()
			relativeTileSizeImageBrush.ImageSource = New BitmapImage(New Uri("sampleImages\cherries_larger.jpg", UriKind.Relative))
			relativeTileSizeImageBrush.TileMode = TileMode.Tile

			' Specify the size of the base tile. 
			' By default, the size of the Viewport is
			' relative to the area being painted,
			' so a value of 0.5 indicates 50% of the output
			' area.
			relativeTileSizeImageBrush.Viewport = New Rect(0, 0, 0.5, 0.5)

			' Create a rectangle and paint it with the ImageBrush.
            Dim relativeTileSizeExampleRectangle As New Rectangle()
            With relativeTileSizeExampleRectangle
                .Width = 200
                .Height = 150
                .Stroke = Brushes.LimeGreen
                .StrokeThickness = 1
                .Fill = relativeTileSizeImageBrush
            End With
            ' </SnippetRelativeTileSizeExample>

            ' <SnippetAbsoluteTileSizeExample>

            '
            ' Create an ImageBrush and set the size of each
            ' tile to 25 by 25 pixels. 
            ' 
            Dim absoluteTileSizeImageBrush As New ImageBrush()
            absoluteTileSizeImageBrush.ImageSource = New BitmapImage(New Uri("sampleImages\cherries_larger.jpg", UriKind.Relative))
            absoluteTileSizeImageBrush.TileMode = TileMode.Tile

            ' Specify that the Viewport is to be interpreted as
            ' an absolute value. 
            absoluteTileSizeImageBrush.ViewportUnits = BrushMappingMode.Absolute

            ' Set the size of the base tile. Had we left ViewportUnits set
            ' to RelativeToBoundingBox (the default value), 
            ' each tile would be 25 times the size of the area being
            ' painted. Because ViewportUnits is set to Absolute,
            ' the following line creates tiles that are 25 by 25 pixels.
            absoluteTileSizeImageBrush.Viewport = New Rect(0, 0, 25, 25)

            ' Create a rectangle and paint it with the ImageBrush.
            Dim absoluteTileSizeExampleRectangle As New Rectangle()
            With absoluteTileSizeExampleRectangle
                .Width = 200
                .Height = 150
                .Stroke = Brushes.LimeGreen
                .StrokeThickness = 1
                .Fill = absoluteTileSizeImageBrush
            End With
            ' </SnippetAbsoluteTileSizeExample>

            Dim mainPanel As New StackPanel()
            mainPanel.Children.Add(relativeTileSizeExampleRectangle)
            mainPanel.Children.Add(absoluteTileSizeExampleRectangle)
            Content = mainPanel

            Title = "Tile Size Example"
            Background = Brushes.White
            Margin = New Thickness(20)

		End Sub
	End Class
End Namespace
