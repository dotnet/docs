'<SnippetNSUriNavigationPageCODEBEHIND>

Namespace SDKSample
	Partial Public Class NSUriNavigationPage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Create a pack URI
			Dim uri As New Uri("AnotherPage.xaml", UriKind.Relative)

			' Get the navigation service that was used to 
			' navigate to this page, and navigate to 
			' AnotherPage.xaml
			Me.NavigationService.Navigate(uri)
		End Sub
	End Class
End Namespace
'</SnippetNSUriNavigationPageCODEBEHIND>