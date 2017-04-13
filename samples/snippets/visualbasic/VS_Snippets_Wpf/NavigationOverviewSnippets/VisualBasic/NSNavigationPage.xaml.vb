'<SnippetNSNavigationPageCODEBEHIND>

Namespace SDKSample
	Partial Public Class NSNavigationPage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Instantiate the page to navigate to
			Dim page As New PageWithNonDefaultConstructor("Hello!")

			' Navigate to the page, using the NavigationService
			Me.NavigationService.Navigate(page)
		End Sub
	End Class
End Namespace
'</SnippetNSNavigationPageCODEBEHIND>