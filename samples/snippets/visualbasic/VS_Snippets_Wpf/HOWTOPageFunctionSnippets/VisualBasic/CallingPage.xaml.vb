Namespace UsingPageFunctionsSample
	Partial Public Class CallingPage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub callPageFunctionLikeAPage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetNavigateToAPageFunctionLikeAPageCODEBEHIND>
			' Navigate to a page function like a page
			Dim pageFunctionUri As New Uri("GetStringPageFunction.xaml", UriKind.Relative)
			Me.NavigationService.Navigate(pageFunctionUri)
			'</SnippetNavigateToAPageFunctionLikeAPageCODEBEHIND>
		End Sub

		'<SnippetCallAPageFunctionCODEBEHIND>
		Private Sub callPageFunctionHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Call a page function
			Dim pageFunction As New GetStringPageFunction("initialValue")
			Me.NavigationService.Navigate(pageFunction)
		End Sub
		'</SnippetCallAPageFunctionCODEBEHIND>

		'<SnippetGetPageFunctionResultCODEBEHIND>
		Private Sub callPageFunctionAndReturnHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Call a page function and hook up page function's return event to get result
			Dim pageFunction As New GetStringPageFunction()
			AddHandler pageFunction.Return, AddressOf GetStringPageFunction_Returned
			Me.NavigationService.Navigate(pageFunction)
		End Sub
		Private Sub GetStringPageFunction_Returned(ByVal sender As Object, ByVal e As ReturnEventArgs(Of String))
			' Get the result, if a result was passed.
			If e.Result IsNot Nothing Then
				Console.WriteLine(e.Result)
			End If
		End Sub
		'</SnippetGetPageFunctionResultCODEBEHIND>
	End Class
End Namespace