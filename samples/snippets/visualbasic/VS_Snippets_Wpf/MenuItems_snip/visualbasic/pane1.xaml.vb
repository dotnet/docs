'This is a list of commonly used namespaces for a pane.

Namespace Menus

	Partial Public Class Pane1
		Inherits Canvas
		Private menu As Menu
		Private mi, mia, mib, mic As MenuItem

		Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<Snippet2>
			menu = New Menu()
			menu.Background = Brushes.LightBlue
			'<Snippet4>
			menu.Width = SystemParameters.CaptionWidth
			'</Snippet4>
			mi = New MenuItem()
			mi.Width = 50
			mi.Header = "File"
			menu.Items.Add(mi)

			'<Snippet7>
			mia = New MenuItem()
			mia.Header = "Cut"
			mia.InputGestureText = "Ctrl+X"
			mi.Items.Add(mia)
			'</Snippet7>

			'<Snippet9>
			mib = New MenuItem()
			mib.Command = ApplicationCommands.Copy
			mi.Items.Add(mib)

			mic = New MenuItem()
			mic.Command = ApplicationCommands.Paste
			mi.Items.Add(mic)
			'</Snippet9>
			cv2.Children.Add(menu)
			'</Snippet2>
		End Sub

		'<SnippetIsSubMenuOpen>
		Private Sub FileMenu_Opened(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If sender Is e.Source Then
				recentFiles.IsSubmenuOpen = True
				Keyboard.Focus(recentFiles)
			End If
		End Sub
		'</SnippetIsSubMenuOpen>

		'<SnippetSubmenuEventOpened2>
		Private Sub OnSubmenuOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)

			If sender Is e.Source Then
				textBlock1.Text = "Submenu is open."
			End If
		End Sub
		'</SnippetSubmenuEventOpened2>

		'<SnippetSubmenuEventClosed2> 
		Private Sub OnSubmenuClosed(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If sender Is e.Source Then
				textBlock1.Text = "Submenu is closed."
			End If
		End Sub
		'</SnippetSubmenuEventClosed2>

		'<SnippetMenuItemIsHighlighted>
		Private Sub Highlight(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If item1.IsHighlighted = True Then
				hlbtn.Content = "Item is highlighted."
			End If
		End Sub
		'</SnippetMenuItemIsHighlighted>
	End Class
End Namespace