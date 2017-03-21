Namespace SDKSample
	Partial Public Class EventOvw2
		Inherits StackPanel
'<SnippetEventSetterRef>
	  Private Sub b1SetColor(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim b As Button = TryCast(e.Source, Button)
		b.Background = New SolidColorBrush(Colors.Azure)
	  End Sub

	  Private Sub HandleThis(ByVal sender As Object, ByVal e As RoutedEventArgs)
		e.Handled=True
	  End Sub
'</SnippetEventSetterRef>

'<SnippetAddHandlerHandledToo>
	  Private Sub PrimeHandledToo(ByVal sender As Object, ByVal e As EventArgs)
		  dpanel2.AddHandler(Button.ClickEvent, New RoutedEventHandler(AddressOf GetHandledToo), True)
	  End Sub
'</SnippetAddHandlerHandledToo>
	  Private Sub GetHandledToo(ByVal sender As Object, ByVal e As RoutedEventArgs)
		 Dim feSource As FrameworkElement = TryCast(e.Source, FrameworkElement)
		 MessageBox.Show(feSource.Name & " raised an event with handled=" & e.Handled.ToString())
	  End Sub
	End Class
End Namespace