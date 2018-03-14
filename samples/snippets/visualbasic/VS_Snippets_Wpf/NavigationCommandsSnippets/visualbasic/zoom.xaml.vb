'<SnippetZoomCODEBEHIND>

Namespace SDKSample
	Partial Public Class Zoom
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub navigationCommandZoom_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			Dim canExecute As Boolean

			' Can zoom if there is a document
			canExecute = (Me.flowDocumentPageViewer.Document IsNot Nothing)

			' Can zoom if the current zoom is not the same as the desired zoom
			If e.Parameter IsNot Nothing Then
				Dim desiredZoom As Double = Double.Parse(e.Parameter.ToString())
				canExecute = (Me.flowDocumentPageViewer.Zoom <> desiredZoom)
			End If

			e.CanExecute = canExecute
		End Sub

		Private Sub navigationCommandZoom_Executed(ByVal target As Object, ByVal e As ExecutedRoutedEventArgs)
			' Change zoom
			Dim desiredZoom As Double = Double.Parse(e.Parameter.ToString())
			Me.flowDocumentPageViewer.Zoom = desiredZoom
		End Sub
	End Class
End Namespace
'</SnippetZoomCODEBEHIND>