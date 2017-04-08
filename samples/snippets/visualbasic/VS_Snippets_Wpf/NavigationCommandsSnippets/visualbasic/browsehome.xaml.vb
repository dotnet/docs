'<SnippetBrowseHomeCODEBEHIND>

Namespace SDKSample
	Partial Public Class BrowseHome
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub navigationCommandBrowseHome_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			' Can always navigate home
			e.CanExecute = True
		End Sub

		Private Sub navigationCommandBrowseHome_Executed(ByVal target As Object, ByVal e As ExecutedRoutedEventArgs)
			' Implement custom BrowseHome handling code
		End Sub
	End Class
End Namespace
'</SnippetBrowseHomeCODEBEHIND>