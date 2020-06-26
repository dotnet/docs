

Namespace SDKSample
	Partial Public Class GetNSPageShortCut
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetGetNSShortcutCODEBEHIND2>
' Get a reference to the NavigationService that navigated to this Page
Dim ns As NavigationService = Me.NavigationService
'</SnippetGetNSShortcutCODEBEHIND2>
		End Sub
	End Class
End Namespace