Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.BrushExamples
	Public Class TileBrushAlignmentExample
		Inherits Page

		Public Sub New()
			' <SnippetTileBrushTopLeftAlignmentInline>
			'
			' Create a TileBrush and align its
			' content to the top-left of its tile.
			'
			Dim topLeftAlignedTileBrush As New DrawingBrush()
			topLeftAlignedTileBrush.AlignmentX = AlignmentX.Left
			topLeftAlignedTileBrush.AlignmentY = AlignmentY.Top

			' Set Stretch to None so that the brush's
			' content doesn't automatically expand to
			' fill the entire tile. 
			topLeftAlignedTileBrush.Stretch = Stretch.None

			' Define the brush's content.
			Dim ellipses As New GeometryGroup()
			ellipses.Children.Add(New EllipseGeometry(New Point(50, 50), 20, 45))
			ellipses.Children.Add(New EllipseGeometry(New Point(50, 50), 45, 20))
			Dim drawingPen As New Pen(Brushes.Gray, 10)
			Dim ellipseDrawing As New GeometryDrawing(Brushes.Blue, drawingPen, ellipses)
			topLeftAlignedTileBrush.Drawing = ellipseDrawing

			' Use the brush to paint a rectangle.
            Dim rectangle1 As New Rectangle()
            With rectangle1
                .Width = 150
                .Height = 150
                .Stroke = Brushes.Red
                .StrokeThickness = 2
                .Margin = New Thickness(20)
                .Fill = topLeftAlignedTileBrush
            End With

            ' </SnippetTileBrushTopLeftAlignmentInline>

            ' <SnippetTileBrushBottomRightAlignmentInline>
            '
            ' Create a TileBrush and align its
            ' content to the bottom-right of its tile.
            '
            Dim bottomRightAlignedTileBrush As New DrawingBrush()
            With bottomRightAlignedTileBrush
                .AlignmentX = AlignmentX.Right
                .AlignmentY = AlignmentY.Bottom
                .Stretch = Stretch.None

                ' Define the brush's content.
                .Drawing = ellipseDrawing
            End With

            ' Use the brush to paint a rectangle.
            Dim rectangle2 As New Rectangle()
            With rectangle2
                .Width = 150
                .Height = 150
                .Stroke = Brushes.Red
                .StrokeThickness = 2
                .Margin = New Thickness(20)
                .Fill = bottomRightAlignedTileBrush
            End With

            ' </SnippetTileBrushBottomRightAlignmentInline>

            ' <SnippetTileBrushTopLeftAlignmentTiledInline>
            '
            ' Create a TileBrush that generates a 
            ' tiled pattern and align its
            ' content to the top-left of its tile.
            '
            Dim tiledTopLeftAlignedTileBrush As New DrawingBrush()
            With tiledTopLeftAlignedTileBrush
                .AlignmentX = AlignmentX.Left
                .AlignmentY = AlignmentY.Top
                .Stretch = Stretch.Uniform

                ' Set the brush's Viewport and TileMode to produce a 
                ' tiled pattern.
                .Viewport = New Rect(0, 0, 0.25, 0.5)
                .TileMode = TileMode.Tile

                ' Define the brush's content.
                .Drawing = ellipseDrawing
            End With

            ' Use the brush to paint a rectangle.
            Dim rectangle3 As New Rectangle()
            With rectangle3
                .Width = 150
                .Height = 150
                .Stroke = Brushes.Black
                .StrokeThickness = 2
                .Margin = New Thickness(20)
                .Fill = tiledTopLeftAlignedTileBrush
            End With

            ' </SnippetTileBrushTopLeftAlignmentTiledInline>

            ' <SnippetTileBrushBottomRightAlignmentTiledInline>
            '
            ' Create a TileBrush that generates a 
            ' tiled pattern and align its
            ' content to the bottom-right of its tile.
            '
            Dim tiledBottomRightAlignedTileBrush As New DrawingBrush()
            With tiledBottomRightAlignedTileBrush
                .AlignmentX = AlignmentX.Right
                .AlignmentY = AlignmentY.Bottom
                .Stretch = Stretch.Uniform

                ' Set the brush's Viewport and TileMode to produce a 
                ' tiled pattern.
                .Viewport = New Rect(0, 0, 0.25, 0.5)
                .TileMode = TileMode.Tile

                ' Define the brush's content.
                .Drawing = ellipseDrawing
            End With

            ' Use the brush to paint a rectangle.
            Dim rectangle4 As New Rectangle()
            With rectangle4
                .Width = 150
                .Height = 150
                .Stroke = Brushes.Black
                .StrokeThickness = 2
                .Margin = New Thickness(20)
                .Fill = tiledBottomRightAlignedTileBrush
            End With

            ' </SnippetTileBrushBottomRightAlignmentTiledInline>


            Dim mainPanel As New StackPanel()
            mainPanel.Children.Add(rectangle1)
            mainPanel.Children.Add(rectangle2)
            mainPanel.Children.Add(rectangle3)
            mainPanel.Children.Add(rectangle4)
            Content = mainPanel
            Background = Brushes.White
            Margin = New Thickness(20)
            Title = "Alignment Example"

		End Sub

	End Class
End Namespace
