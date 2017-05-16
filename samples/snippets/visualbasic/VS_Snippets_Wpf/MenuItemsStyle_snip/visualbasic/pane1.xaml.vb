'This is a list of commonly used namespaces for a pane.

Namespace MenuStyles
	''' <summary>
	''' Interaction logic for Pane1.xaml
	''' </summary>

	Partial Public Class Pane1
		Inherits StackPanel
		Private status As String

		Private Sub StatusClick(ByVal sender As Object, ByVal e As RoutedEventArgs)

			Dim menu As MenuItem = CType(sender, MenuItem)

			status = CStr(menu.Header)
			Select Case status
				Case "Online"
					mi1.IsChecked = True
					mi2.IsChecked = False
					mi3.IsChecked = False
					mi4.IsChecked = False

				Case "Busy"
					mi1.IsChecked = False
					mi2.IsChecked = True
					mi3.IsChecked = False
					mi4.IsChecked = False

				Case "Be Right Back"
					mi1.IsChecked = False
					mi2.IsChecked = False
					mi3.IsChecked = True
					mi4.IsChecked = False

				Case "Away"
					mi1.IsChecked = False
					mi2.IsChecked = False
					mi3.IsChecked = False
					mi4.IsChecked = True
			End Select
		End Sub

		'<SnippetMenuItemsCheckedEvent>
		Private Sub OnChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If mi1.IsChecked = True Then
				textBlock1.Text = "Item is checked."
			End If
		End Sub
		'</SnippetMenuItemsCheckedEvent>

		'<SnippetMenuItemsUncheckedEvent>
		Private Sub OnUnchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If mi1.IsChecked = False Then
				textBlock1.Text = "Item is unchecked."
			End If
		End Sub
		'</SnippetMenuItemsUncheckedEvent>


	End Class


End Namespace