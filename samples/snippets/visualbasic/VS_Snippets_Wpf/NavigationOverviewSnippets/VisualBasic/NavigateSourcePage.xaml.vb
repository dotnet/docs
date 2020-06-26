Namespace SDKSample
	Partial Public Class NavigateSourcePage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub
		'<SnippetNavigationServiceSourceCODE>
		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Causes NavigationService to navigate to page at specified URI.
			' NavigationService.CurrentSource will have the URI of the page being
			' navigate from until the navigation is complete.
			Dim ns As NavigationService = NavigationService.GetNavigationService(Me)
			ns.Source = New Uri("AnotherPage.xaml", UriKind.Relative)
		End Sub
		'</SnippetNavigationServiceSourceCODE>
	End Class
End Namespace