'<SnippetNSRefreshNavigationPageCODEBEHIND1>

Namespace SDKSample
	Partial Public Class NSRefreshNavigationPage
		Inherits Page
		'</SnippetNSRefreshNavigationPageCODEBEHIND1>
		Public Sub New()
			InitializeComponent()
		End Sub

		'<SnippetNSRefreshNavigationPageCODEBEHIND2>
		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Force WPF to download this page again
			Me.NavigationService.Refresh()
		End Sub
	End Class
End Namespace
'</SnippetNSRefreshNavigationPageCODEBEHIND2>