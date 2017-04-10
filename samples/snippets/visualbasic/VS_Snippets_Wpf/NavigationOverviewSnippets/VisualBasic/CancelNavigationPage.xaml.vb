'<SnippetCancelNavigationPageCODEBEHIND>

Namespace SDKSample
	Partial Public Class CancelNavigationPage
		Inherits Page
		Public Sub New()
			InitializeComponent()

			' Can only access the NavigationService when the page has been loaded
			AddHandler Loaded, AddressOf CancelNavigationPage_Loaded
			AddHandler Unloaded, AddressOf CancelNavigationPage_Unloaded
		End Sub

		Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Force WPF to download this page again
			Me.NavigationService.Navigate(New Uri("AnotherPage.xaml", UriKind.Relative))
		End Sub

		Private Sub CancelNavigationPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			AddHandler NavigationService.Navigating, AddressOf NavigationService_Navigating
		End Sub

		Private Sub CancelNavigationPage_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			RemoveHandler NavigationService.Navigating, AddressOf NavigationService_Navigating
		End Sub

		Private Sub NavigationService_Navigating(ByVal sender As Object, ByVal e As NavigatingCancelEventArgs)
			' Does the user really want to navigate to another page?
			Dim result As MessageBoxResult
			result = MessageBox.Show("Do you want to leave this page?", "Navigation Request", MessageBoxButton.YesNo)

			' If the user doesn't want to navigate away, cancel the navigation
			If result = MessageBoxResult.No Then
				e.Cancel = True
			End If
		End Sub
	End Class
End Namespace
'</SnippetCancelNavigationPageCODEBEHIND>