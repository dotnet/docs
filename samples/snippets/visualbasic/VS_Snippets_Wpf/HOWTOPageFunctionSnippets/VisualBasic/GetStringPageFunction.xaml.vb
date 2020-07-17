Namespace UsingPageFunctionsSample
	'<SnippetPageFunctionReturnAResultCODEBEHIND>
	Partial Public Class GetStringPageFunction
		Inherits PageFunction(Of String)
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal initialValue As String)
			Me.New()
			Me.stringTextBox.Text = initialValue
		End Sub

		Private Sub okButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Page function is accepted, so return a result
			OnReturn(New ReturnEventArgs(Of String)(Me.stringTextBox.Text))
		End Sub

		Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Page function is cancelled, so don't return a result
			OnReturn(New ReturnEventArgs(Of String)(Nothing))
		End Sub
	End Class
	'</SnippetPageFunctionReturnAResultCODEBEHIND>
End Namespace