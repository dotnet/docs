'<SnippetFavoritesCODEBEHIND>

Namespace SDKSample
	Partial Public Class Favorites
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub navigationCommandFavorites_CanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			' Can always handle favorites
			e.CanExecute = True
		End Sub

		Private Sub navigationCommandFavorites_Executed(ByVal target As Object, ByVal e As ExecutedRoutedEventArgs)
			' Implement custom Favorites handling code
		End Sub
	End Class
End Namespace
'</SnippetFavoritesCODEBEHIND>