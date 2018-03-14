Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class PaintWithVideoExample
		Inherits Page
		Public Sub New()
			Dim myTextBlock1 As TextBlock = ReturnTextBlockWithMedia1()
			Dim myTextBlock2 As TextBlock = ReturnTextBlockWithMedia2()
			Dim myStackPanel As New StackPanel()
			myStackPanel.Children.Add(myTextBlock1)
			myStackPanel.Children.Add(myTextBlock2)

			Me.Content = myStackPanel
		End Sub

		Private Function ReturnTextBlockWithMedia1() As TextBlock
			' <SnippetGraphicsMMVideoAsTextBackgroundInline>
			Dim myMediaElement As New MediaElement()
			myMediaElement.Source = New Uri("sampleMedia\xbox.wmv", UriKind.Relative)
			myMediaElement.IsMuted = True

			Dim myVisualBrush As New VisualBrush()
			myVisualBrush.Visual = myMediaElement

			Dim myTextBlock As New TextBlock()
			myTextBlock.FontSize = 150
			myTextBlock.Text = "Some Text"
			myTextBlock.FontWeight = FontWeights.Bold

			myTextBlock.Foreground = myVisualBrush
			' </SnippetGraphicsMMVideoAsTextBackgroundInline>
			Return myTextBlock
		End Function

		Private Function ReturnTextBlockWithMedia2() As TextBlock
			' <SnippetGraphicsMMVideoAsTextBackgroundTiledInline>
			Dim myMediaElement As New MediaElement()
			myMediaElement.Source = New Uri("sampleMedia\xbox.wmv", UriKind.Relative)
			myMediaElement.IsMuted = True

			Dim myVisualBrush As New VisualBrush()
			myVisualBrush.Viewport = New Rect(0, 0, 0.5, 0.5)
			myVisualBrush.TileMode = TileMode.Tile
			myVisualBrush.Visual = myMediaElement

			Dim myTextBlock As New TextBlock()
			myTextBlock.FontSize = 150
			myTextBlock.Text = "Some Text"
			myTextBlock.FontWeight = FontWeights.Bold

			myTextBlock.Foreground = myVisualBrush
			' </SnippetGraphicsMMVideoAsTextBackgroundTiledInline>
			Return myTextBlock
		End Function

	End Class
End Namespace