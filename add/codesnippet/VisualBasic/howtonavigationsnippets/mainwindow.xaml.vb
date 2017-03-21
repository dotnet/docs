Namespace HOWTONavigationSnippets
	Partial Public Class MainWindow
		Inherits NavigationWindow
		Public Sub New()
			InitializeComponent()

            '<SnippetNavigateToPageCODE>
            '<SnippetNavigateToPageSrcCODE>
			' Navigate to URI using the Source property
			'<SnippetNavigateAndCancelCODE1>
			Me.Source = New Uri("HomePage.xaml", UriKind.Relative)
            '</SnippetNavigateAndCancelCODE1>
            '</SnippetNavigateToPageSrcCODE>

            '<SnippetNavigateToPageNavCODE>
			' Navigate to URI using the Navigate method
			Me.Navigate(New Uri("HomePage.xaml", UriKind.Relative))
            '</SnippetNavigateToPageNavCODE>

            '<SnippetNavigateToPageObjCODE>
			' Navigate to object using the Navigate method
            Me.Navigate(New HomePage())
            '</SnippetNavigateToPageObjCODE>
			'</SnippetNavigateToPageCODE>        

			Dim navigateRefreshButton As New Button()
			AddHandler navigateRefreshButton.Click, AddressOf navigateRefreshButton_Click

			Dim navigateStopButton As New Button()
			AddHandler navigateStopButton.Click, AddressOf navigateStopButton_Click
		End Sub

		'<SnippetNavigateStopLoadingCODE>
		Private Sub navigateStopButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.StopLoading()
		End Sub
		'</SnippetNavigateStopLoadingCODE>

		'<SnippetNavigateRefreshCODE>
		Private Sub navigateRefreshButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.Refresh()
		End Sub
		'</SnippetNavigateRefreshCODE>

	End Class
End Namespace