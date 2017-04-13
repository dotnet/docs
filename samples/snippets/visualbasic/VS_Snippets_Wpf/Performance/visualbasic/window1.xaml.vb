Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		' Handle the Click event for the button.
		Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
			Stub01()
		End Sub

		' <SnippetPerformanceSnippet1>
		Private Sub OnBuildTreeTopDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim textBlock As New TextBlock()
			textBlock.Text = "Default"

			Dim parentPanel As New DockPanel()
			Dim childPanel As DockPanel

			myCanvas.Children.Add(parentPanel)
			myCanvas.Children.Add(textBlock)

			For i As Integer = 0 To 149
				textBlock = New TextBlock()
				textBlock.Text = "Default"
				parentPanel.Children.Add(textBlock)

				childPanel = New DockPanel()
				parentPanel.Children.Add(childPanel)
				parentPanel = childPanel
			Next i
		End Sub
		' </SnippetPerformanceSnippet1>

		Public Sub Stub01()
			Dim myBrush As Brush = Brushes.Blue
			Dim rectangle_1 As New Rectangle()
			Dim rectangle_2 As New Rectangle()
			Dim rectangle_3 As New Rectangle()
			Dim rectangle_10 As New Rectangle()

			' <SnippetPerformanceSnippet2>
			rectangle_1.Fill = myBrush
			rectangle_2.Fill = myBrush
			rectangle_3.Fill = myBrush
			' ...
			rectangle_10.Fill = myBrush
			' </SnippetPerformanceSnippet2>
		End Sub

		Public Sub Stub02()
			' <SnippetPerformanceSnippet3>
			Dim frozenBrush As Brush = New SolidColorBrush(Colors.Blue)
			frozenBrush.Freeze()
			Dim nonFrozenBrush As Brush = New SolidColorBrush(Colors.Blue)

			For i As Integer = 0 To 9
				' Create a Rectangle using a non-frozed Brush.
				Dim rectangleNonFrozen As New Rectangle()
				rectangleNonFrozen.Fill = nonFrozenBrush

				' Create a Rectangle using a frozed Brush.
				Dim rectangleFrozen As New Rectangle()
				rectangleFrozen.Fill = frozenBrush
			Next i
			' </SnippetPerformanceSnippet3>
		End Sub

		Public Sub Stub03()
			' <SnippetPerformanceSnippet4>
			Dim myBrush As Brush = New SolidColorBrush(Colors.Red)
			Dim myRectangle As New Rectangle()
			myRectangle.Fill = myBrush
			' </SnippetPerformanceSnippet4>

			' <SnippetPerformanceSnippet5>
			myRectangle = Nothing
			' </SnippetPerformanceSnippet5>

			' <SnippetPerformanceSnippet6>
			myRectangle.Fill = Nothing
			myRectangle = Nothing
			' </SnippetPerformanceSnippet6>
		End Sub
	End Class
End Namespace