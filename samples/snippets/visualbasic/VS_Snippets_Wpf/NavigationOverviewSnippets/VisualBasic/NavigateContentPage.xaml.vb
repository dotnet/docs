Namespace SDKSample
	Partial Public Class NavigateContentPage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		'<SnippetNavigationServiceContentCODE>
		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Causes NavigationService to navigate to specified page object.
			' From a navigation history perspective, navigating to an object 
			' has the same effect as navigating via URI ie the page navigating
			' from is added to navigation history.
			Dim ns As NavigationService = NavigationService.GetNavigationService(Me)
			ns.Content = New AnotherPage()
		End Sub
		'</SnippetNavigationServiceContentCODE>
	End Class
End Namespace