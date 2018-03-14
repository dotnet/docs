Namespace HOWTONavigationSnippets
	''' <summary>
	''' Interaction logic for HomePage.xaml
	''' </summary>

	Partial Public Class HomePage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub HomePage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetManipulatePageHostWindowProperties>
			' Set host window's Title, Width, and Height
			Me.WindowTitle = "New Title Set by a Page!"
			Me.WindowWidth = 500
			Me.WindowHeight = 500
			'</SnippetManipulatePageHostWindowProperties>
		End Sub

		'<SnippetNavigateBackCODE>
		Private Sub navigateBackButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Navigate back one page from this page, if there is an entry
			' in back navigation history
			If Me.NavigationService.CanGoBack Then
				Me.NavigationService.GoBack()
			Else
				MessageBox.Show("No entries in back navigation history.")
			End If
		End Sub
		'</SnippetNavigateBackCODE>

		'<SnippetNavigateForwardCODE>
		Private Sub navigateForwardButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Navigate forward one page from this page, if there is an entry
			' in forward navigation history
			If Me.NavigationService.CanGoForward Then
				Me.NavigationService.GoForward()
			Else
				MessageBox.Show("No entries in forward navigation history.")
			End If
		End Sub
		'</SnippetNavigateForwardCODE>
	End Class
End Namespace