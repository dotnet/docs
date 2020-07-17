Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace Microsoft.Samples.BrushExamples

	Public Class StretchExample
		Inherits Page


		Public Sub New()

			' Create the main panel.
			Dim mainPanel As New StackPanel()
			mainPanel.Orientation = Orientation.Horizontal
			createNoStretchExample(mainPanel)
			Me.Content = mainPanel


		End Sub


		Private Sub createNoStretchExample(ByVal mainPanel As Panel)

            ' <SnippetGraphicsMMNoStretchExample>
            ' Create a rectangle.
            Dim myRectangle As New Rectangle()
            With myRectangle
                .Width = 125
                .Height = 175
                .Stroke = Brushes.Black
                .StrokeThickness = 1
                .Margin = New Thickness(0, 5, 0, 0)
            End With

            ' Load the image.
            Dim theImage As New BitmapImage(New Uri("sampleImages\testImage.gif", UriKind.Relative))
            Dim myImageBrush As New ImageBrush(theImage)

            ' Configure the brush so that it
            ' doesn't stretch its image to fill
            ' the rectangle.
            myImageBrush.Stretch = Stretch.None

            ' Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush
            ' </SnippetGraphicsMMNoStretchExample>

            mainPanel.Children.Add(myRectangle)

		End Sub


	End Class

End Namespace