'<SnippetSearchCODEBEHIND>

Namespace SDKSample
	Partial Public Class Search
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub navigationCommandSearch_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			' Can search of there is a document
			e.CanExecute = (Me.flowDocumentPageViewer.Document IsNot Nothing)
		End Sub

		Private Sub navigationCommandSearch_Executed(ByVal target As Object, ByVal e As ExecutedRoutedEventArgs)
			' Implement custom Search handling code
		End Sub
	End Class
End Namespace
'</SnippetSearchCODEBEHIND>