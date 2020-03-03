Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace Microsoft.Samples.BrushExamples

	Public Class AlignmentExample
		Inherits Page


		Public Sub New()

			' Create the main panel.
			Dim mainPanel As New StackPanel()
			mainPanel.Orientation = Orientation.Horizontal
			createTopLeftAlignmentExample(mainPanel)
			Me.Content = mainPanel


		End Sub


		Private Sub createTopLeftAlignmentExample(ByVal mainPanel As Panel)

			' <SnippetGraphicsMMTopLeftAlignmentExample>
			' Create a rectangle.
            Dim myRectangle As New Rectangle()
            With myRectangle
                .Width = 150
                .Height = 150
                .Stroke = Brushes.LimeGreen
                .StrokeThickness = 1
                .Margin = New Thickness(0, 5, 0, 0)
            End With

            ' Load the image.
            Dim theImage As New BitmapImage(New Uri("sampleImages\triangle.jpg", UriKind.Relative))
            Dim myImageBrush As New ImageBrush(theImage)

            ' Configure the brush so that it
            ' doesn't stretch its image to fill
            ' the rectangle.
            myImageBrush.Stretch = Stretch.None

            ' Align the tile to the rectangle's 
            ' top left corner.
            myImageBrush.AlignmentX = AlignmentX.Left
            myImageBrush.AlignmentY = AlignmentY.Top


            ' Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush
            ' </SnippetGraphicsMMTopLeftAlignmentExample>

            mainPanel.Children.Add(myRectangle)

		End Sub


	End Class

End Namespace