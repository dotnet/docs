Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace Microsoft.Samples.BrushExamples

	Public Class TilingExample
		Inherits Page


		Public Sub New()

			' Create the main panel.
			Dim mainPanel As New StackPanel()
			mainPanel.Orientation = Orientation.Horizontal
			createTilingExample(mainPanel)
			Me.Content = mainPanel


		End Sub


		Private Sub createTilingExample(ByVal mainPanel As Panel)


            Dim rectangleBorder As New Border()
            With rectangleBorder
                .BorderBrush = Brushes.Black
                .BorderThickness = New Thickness(1)
                .VerticalAlignment = VerticalAlignment.Top
                .Margin = New Thickness(0, 0, 10, 0)
            End With

            ' <SnippetGraphicsMMFlipXYExample>
            ' Create a rectangle.
            Dim myRectangle As New Rectangle()
            myRectangle.Width = 100
            myRectangle.Height = 100

            ' Load the image.
            Dim theImage As New BitmapImage(New Uri("sampleImages\triangle.jpg", UriKind.Relative))
            Dim myImageBrush As New ImageBrush(theImage)

            ' Create tiles that are 1/4 the size of 
            ' the output area.
            myImageBrush.Viewport = New Rect(0, 0, 0.25, 0.25)

            ' Set the tile mode to FlipXY.
            myImageBrush.TileMode = TileMode.FlipXY

            ' Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush
            ' </SnippetGraphicsMMFlipXYExample>

            rectangleBorder.Child = myRectangle
            mainPanel.Children.Add(rectangleBorder)

		End Sub


	End Class

End Namespace