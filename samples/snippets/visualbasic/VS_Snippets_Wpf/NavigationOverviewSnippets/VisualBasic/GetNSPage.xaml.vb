

Namespace SDKSample
	Partial Public Class GetNSPage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetGetNSCODEBEHIND2>
' Get a reference to the NavigationService that navigated to this Page
Dim ns As NavigationService = NavigationService.GetNavigationService(Me)
'</SnippetGetNSCODEBEHIND2>
		End Sub
	End Class
End Namespace