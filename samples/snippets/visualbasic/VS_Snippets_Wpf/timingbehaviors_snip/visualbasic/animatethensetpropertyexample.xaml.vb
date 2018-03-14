Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation.TimingBehaviors


	Partial Public Class AnimateThenSetPropertyExample
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		' <SnippetGraphicsMMButton1Handler> 
		Private Sub setButton1BackgroundBrushColor(ByVal sender As Object, ByVal e As EventArgs)

			' Does not appear to have any effect:
			' the brush remains yellow.
			Button1BackgroundBrush.Color = Colors.Blue
		End Sub
		' </SnippetGraphicsMMButton1Handler> 

		' <SnippetGraphicsMMButton2Handler> 
		Private Sub setButton2BackgroundBrushColor(ByVal sender As Object, ByVal e As EventArgs)

			' This appears to work:
			' the brush changes to blue.
			Button2BackgroundBrush.Color = Colors.Blue
		End Sub
		' </SnippetGraphicsMMButton2Handler> 

		' <SnippetGraphicsMMButton3Handler> 
		Private Sub setButton3BackgroundBrushColor(ByVal sender As Object, ByVal e As EventArgs)

			 ' This appears to work:
			' the brush changes to blue.
			MyStoryboard.Remove(Button3)
			Button3BackgroundBrush.Color = Colors.Blue
		End Sub
		' </SnippetGraphicsMMButton3Handler> 

		' <SnippetGraphicsMMButton4Handler> 
		Private Sub setButton4BackgroundBrushColor(ByVal sender As Object, ByVal e As EventArgs)

			 ' This appears to work:
			' the brush changes to blue.
			Button4BackgroundBrush.BeginAnimation(SolidColorBrush.ColorProperty, Nothing)
			Button4BackgroundBrush.Color = Colors.Blue
		End Sub
		' </SnippetGraphicsMMButton4Handler>         


	End Class
End Namespace
