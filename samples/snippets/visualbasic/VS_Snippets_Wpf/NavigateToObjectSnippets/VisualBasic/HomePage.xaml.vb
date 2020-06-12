'<SnippetPageThatNavsToObjectCODEBEHIND>

Namespace SDKSample
	Partial Public Class HomePage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub hyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim person As New Person("Nancy Davolio", Colors.Yellow)
			Me.NavigationService.Navigate(person)
		End Sub
	End Class
End Namespace
'</SnippetPageThatNavsToObjectCODEBEHIND>