' <SnippetGraphicsMMImageBrushAsCanvasBackgroundExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace Microsoft.Samples.BrushExamples

	Public Class ImageBrushExample
		Inherits Page

		Public Sub New()

			Dim mainPanel As New StackPanel()
			canvasBackgroundExample(mainPanel)
			Me.Content = mainPanel

		End Sub


		' <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample>
		Private Sub canvasBackgroundExample(ByVal mainPanel As Panel)

			' <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample1>
			Dim theImage As New BitmapImage(New Uri("sampleImages\Waterlilies.jpg", UriKind.Relative))
			' </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample1>

			' <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample2>
			Dim myImageBrush As New ImageBrush(theImage)
			' </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample2>

			' <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample3>
			Dim myCanvas As New Canvas()
			myCanvas.Width = 300
			myCanvas.Height = 200
			myCanvas.Background = myImageBrush
			' </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample3>

			mainPanel.Children.Add(myCanvas)


		End Sub
		' </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample>

	End Class

End Namespace
' </SnippetGraphicsMMImageBrushAsCanvasBackgroundExampleWholePage>