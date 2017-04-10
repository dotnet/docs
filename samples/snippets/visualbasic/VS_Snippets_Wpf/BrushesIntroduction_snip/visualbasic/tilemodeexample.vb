' <SnippetGraphicsMMDrawingBrushTileModeExample>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace BrushesIntroduction
	Public Class TileModeExample
		Inherits Page

		Public Sub New()
			Background = Brushes.White
			Margin = New Thickness(20)
			Dim mainPanel As New StackPanel()
			mainPanel.HorizontalAlignment = HorizontalAlignment.Left

			'
			' Create a Drawing. This will be the DrawingBrushes' content.
			'
			Dim triangleLinesSegment As New PolyLineSegment()
			triangleLinesSegment.Points.Add(New Point(50, 0))
			triangleLinesSegment.Points.Add(New Point(0, 50))
			Dim triangleFigure As New PathFigure()
			triangleFigure.IsClosed = True
			triangleFigure.StartPoint = New Point(0, 0)
			triangleFigure.Segments.Add(triangleLinesSegment)
			Dim triangleGeometry As New PathGeometry()
			triangleGeometry.Figures.Add(triangleFigure)

			Dim triangleDrawing As New GeometryDrawing()
			triangleDrawing.Geometry = triangleGeometry
			triangleDrawing.Brush = New SolidColorBrush(Color.FromArgb(255, 204, 204, 255))
			Dim trianglePen As New Pen(Brushes.Black, 2)
			triangleDrawing.Pen = trianglePen
			trianglePen.MiterLimit = 0
			triangleDrawing.Freeze()

			'
			' Create the first TileBrush. Its content is not tiled.
			'
			Dim tileBrushWithoutTiling As New DrawingBrush()
			tileBrushWithoutTiling.Drawing = triangleDrawing
			tileBrushWithoutTiling.TileMode = TileMode.None

			' Create a rectangle and paint it with the DrawingBrush.
			Dim noTileExampleRectangle As Rectangle = createExampleRectangle()
			noTileExampleRectangle.Fill = tileBrushWithoutTiling

			' Add a header and the rectangle to the main panel.
			mainPanel.Children.Add(createExampleHeader("None"))
			mainPanel.Children.Add(noTileExampleRectangle)

			'
			' Create another TileBrush, this time with tiling.
			'
			Dim tileBrushWithTiling As New DrawingBrush()
			tileBrushWithTiling.Drawing = triangleDrawing
			tileBrushWithTiling.TileMode = TileMode.Tile

			' Specify the brush's Viewport. Otherwise,
			' a single tile will be produced that fills
			' the entire output area and its TileMode will
			' have no effect.
			' This setting uses realtive values to
			' creates four tiles. 
			tileBrushWithTiling.Viewport = New Rect(0, 0, 0.5, 0.5)

			' Create a rectangle and paint it with the DrawingBrush.
			Dim tilingExampleRectangle As Rectangle = createExampleRectangle()
			tilingExampleRectangle.Fill = tileBrushWithTiling
			mainPanel.Children.Add(createExampleHeader("Tile"))
			mainPanel.Children.Add(tilingExampleRectangle)

			'
			' Create a TileBrush with FlipX tiling.
			' The brush's content is flipped horizontally as it is
			' tiled in this example
			'
			Dim tileBrushWithFlipXTiling As New DrawingBrush()
			tileBrushWithFlipXTiling.Drawing = triangleDrawing
			tileBrushWithFlipXTiling.TileMode = TileMode.FlipX

			' Specify the brush's Viewport.
			tileBrushWithFlipXTiling.Viewport = New Rect(0, 0, 0.5, 0.5)

			' Create a rectangle and paint it with the DrawingBrush.
			Dim flipXTilingExampleRectangle As Rectangle = createExampleRectangle()
			flipXTilingExampleRectangle.Fill = tileBrushWithFlipXTiling
			mainPanel.Children.Add(createExampleHeader("FlipX"))
			mainPanel.Children.Add(flipXTilingExampleRectangle)

			'
			' Create a TileBrush with FlipY tiling.
			' The brush's content is flipped vertically as it is
			' tiled in this example
			'
			Dim tileBrushWithFlipYTiling As New DrawingBrush()
			tileBrushWithFlipYTiling.Drawing = triangleDrawing
			tileBrushWithFlipYTiling.TileMode = TileMode.FlipX

			' Specify the brush's Viewport.
			tileBrushWithFlipYTiling.Viewport = New Rect(0, 0, 0.5, 0.5)

			' Create a rectangle and paint it with the DrawingBrush.
			Dim flipYTilingExampleRectangle As Rectangle = createExampleRectangle()
			flipYTilingExampleRectangle.Fill = tileBrushWithFlipYTiling
			mainPanel.Children.Add(createExampleHeader("FlipY"))
			mainPanel.Children.Add(flipYTilingExampleRectangle)

			'
			' Create a TileBrush with FlipXY tiling.
			' The brush's content is flipped vertically as it is
			' tiled in this example
			'
			Dim tileBrushWithFlipXYTiling As New DrawingBrush()
			tileBrushWithFlipXYTiling.Drawing = triangleDrawing
			tileBrushWithFlipXYTiling.TileMode = TileMode.FlipXY

			' Specify the brush's Viewport.
			tileBrushWithFlipXYTiling.Viewport = New Rect(0, 0, 0.5, 0.5)

			' Create a rectangle and paint it with the DrawingBrush.
			Dim flipXYTilingExampleRectangle As Rectangle = createExampleRectangle()
			flipXYTilingExampleRectangle.Fill = tileBrushWithFlipXYTiling
			mainPanel.Children.Add(createExampleHeader("FlipXY"))
			mainPanel.Children.Add(flipXYTilingExampleRectangle)

			Content = mainPanel
		End Sub

		'
		' Helper method that creates rectangle elements.
		'
		Private Shared Function createExampleRectangle() As Rectangle
			Dim exampleRectangle As New Rectangle()
			exampleRectangle.Width = 50
			exampleRectangle.Height = 50
			exampleRectangle.Stroke = Brushes.Black
			exampleRectangle.StrokeThickness = 1
			Return exampleRectangle
		End Function

		'
		' Helper method that creates headers for the examples. 
		'
		Private Shared Function createExampleHeader(ByVal text As String) As TextBlock
			Dim header As New TextBlock()
			header.Margin = New Thickness(0, 10, 0, 0)
			header.Text = text
			Return header
		End Function
	End Class
End Namespace
' </SnippetGraphicsMMDrawingBrushTileModeExample>

