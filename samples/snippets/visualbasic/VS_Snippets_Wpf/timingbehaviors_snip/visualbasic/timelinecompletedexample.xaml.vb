' <!-- <SnippetTimelineCompletedExampleCodeBehindUsingWholePage> -->
' TimelineCompletedExample.xaml.vb
' Handles the ZoomOutStoryboard's Completed event.
' See the TimelienCompletedExample.xaml file
' for the markup that creates the images and storyboards.


Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation


Namespace SDKSample

	Partial Public Class TimelineCompletedExample
		Inherits Page

		Private zoomInStoryboard As Storyboard
		Private currentImageSource As ImageSource
		Private nextImageSource As ImageSource

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub exampleLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Cache the zoom-out storyboard resource.
			zoomInStoryboard = CType(Me.Resources("ZoomInStoryboardResource"), Storyboard)

			' Cache the ImageSource resources.
			currentImageSource = CType(Me.Resources("RectangleDrawingImage"), ImageSource)
			nextImageSource = CType(Me.Resources("CircleDrawingImage"), ImageSource)

			' Display the current image source.
			AnimatedImage.Source = currentImageSource
		End Sub

		' Handles the zoom-out storyboard's completed event. 
		Private Sub zoomOutStoryboardCompleted(ByVal sender As Object, ByVal e As EventArgs)
			AnimatedImage.Source = nextImageSource
			nextImageSource = currentImageSource
			currentImageSource = AnimatedImage.Source
			zoomInStoryboard.Begin(AnimatedImage, HandoffBehavior.SnapshotAndReplace)
		End Sub

	End Class
End Namespace
' <!-- </SnippetTimelineCompletedExampleCodeBehindUsingWholePage> -->