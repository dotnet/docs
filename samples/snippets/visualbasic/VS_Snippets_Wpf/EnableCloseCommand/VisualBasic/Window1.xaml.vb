Namespace WCSamples

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

			'<SnippetCloseCommandBindingCodeBehind>
			' Create ui elements.
			Dim CloseCmdStackPanel As New StackPanel()
			Dim CloseCmdButton As New Button()
			CloseCmdStackPanel.Children.Add(CloseCmdButton)

			' Set Button's properties.
			CloseCmdButton.Content = "Close File"
			CloseCmdButton.Command = ApplicationCommands.Close

			' Create the CommandBinding.
			Dim CloseCommandBinding As New CommandBinding(ApplicationCommands.Close, AddressOf CloseCommandHandler, AddressOf CanExecuteHandler)

			' Add the CommandBinding to the root Window.
			RootWindow.CommandBindings.Add(CloseCommandBinding)
			'</SnippetCloseCommandBindingCodeBehind>

			MainStackPanel.Children.Add(CloseCmdStackPanel)
		End Sub

		'<SnippetCloseCommandHandler>
		' Executed event handler.
		Private Sub CloseCommandHandler(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			' Calls a method to close the file and release resources.
			CloseFile()
		End Sub

		' CanExecute event handler.
		Private Sub CanExecuteHandler(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			' Call a method to determine if there is a file open.
			' If there is a file open, then set CanExecute to true.
			If IsFileOpened() Then
				e.CanExecute = True
			' if there is not a file open, then set CanExecute to false.
			Else
				e.CanExecute = False
			End If
		End Sub
		'</SnippetCloseCommandHandler>

		Public Sub CloseFile()
			MessageBox.Show("File is Closed")
		End Sub

		Public Function IsFileOpened() As Boolean
			Return True
		End Function


	End Class
End Namespace