Imports System.Text

Namespace SDKSample
	''' <summary>
	''' Interaction logic for AnotherPage.xaml
	''' </summary>

	Partial Public Class AnotherPage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

'<SnippetNavigationServiceRefreshCODE>
Private Sub refreshHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
	' Reload the current page.
	Me.NavigationService.Refresh()
End Sub
'</SnippetNavigationServiceRefreshCODE>
	End Class
End Namespace